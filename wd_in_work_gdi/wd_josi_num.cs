using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using kibicom.josi;
using kibicom.tlib;
using System.Windows.Forms;
using kibicom.wd;
using kibicom;
using Atechnology.DBConnections2;

namespace wd_in_work_gdi
{
	public class t_wd_josi_num:t
	{

		t_store josi_store;


		public t_wd_josi_num()
		{
			josi_store = new t_store(new t()
			{
				{"josi_end_point","https://192.168.1.139/webproj/git/kibicom_venta/index.php"},
				//{"josi_end_point","http://kibicom.com/order_store_33/order_store/index.php"},
				{"login_name","dnclive"}, 
				{"pass","135"},
				{"login_on_cre", true},		//не логиниться при создании
			});
		}

		public t_wd_josi_num(t args)
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_end_point"].
				f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();

			josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},
				{"req_timeout", args["req_timeout"].f_def(5000).f_int()},
				{"login_name",login_name}, 
				{"pass",pass},
				{"login_on_cre", true},		//логинимся
				{"auth_try_count", args["auth_try_count"].f_def(3).f_int()},	//количество попыток авторизации
				{"f_done", args["f_done"].f_f()},
				{"f_fail", args["f_fail"].f_f()}
			});

			this["login_name"] = new t(login_name);
			this["pass"]=new t(pass);
			this["josi_end_point"] = new t(josi_end_point);
		}

		public t f_load_wd_order_ds(t args)
		{

			t_wd wd = new t_wd();

			//инициализация соединения с базой
			wd.f_init(new t());

			//получение строки заказа
			DataTable tab_order = wd.f_tab_order(new t()
			{
				{"idorder","95740"}

			})["tab_order"].f_val<DataTable>();

			//инициализация расчета заказа
			//при этом будет сформирован dataset заказа
			//это наша цель
			torder order = new torder(dbconn._db, tab_order.Rows[0]);//, pb);

			//забираем сформированный dataset
			this["ds"].f_set(order.args.ds);

			return new t();
		}

		public t f_get_num(t args)
		{

			string idseller = args["idseller"].f_def(0).f_str();

			//запрос номера
			string res_dot_key_query_str = "kvl.0.f=service_wd_f_get_order_num&"+
											"kvl.1.wd_idseller="+idseller;

			//выполняем запрос
			josi_store.f_query(new t 
			{
				{"res_dot_key_query_str",res_dot_key_query_str},
				{"f_done",args["f_done"].f_f()},	//когда возвращен ответ зовем callback
				{"f_fail",args["f_fail"].f_f()},	//когда возвращен ответ зовем callback
				{"encode_json",true},
				{"cancel_prev",false},
				{"is_need_auth",true},
				{"needs", new t(){"is_auth_done"}}		//когда выполниться процесс авторизации
			});

			return new t();
		}

		public t f_put_order(t args)
		{

			
			DataSet ds = args["ds"].f_val<DataSet>();
			//string idseller = args["idseller"].f_def(0).f_str();

			DataRow o_dr = ds.Tables["orders"].Select("deleted is null")[0];

			string idseller = o_dr["idseller"].ToString();
			string order_name = o_dr["name"].ToString();
			string order_dtcre = o_dr["dtcre"].ToString();
			string order_comment = o_dr["comment"].ToString();

			DataRow c_dr = ds.Tables["customer"].
							Select("deleted is null and idcustomer="+o_dr["idcustomer"].ToString())[0];
			string idcustomer=c_dr["idcustomer"].ToString();
			string customer_name = c_dr["name"].ToString();
			string address_name = c_dr["name"].ToString();

			/*** менеджер ***/
			DataRow[] od_manager_dr = ds.Tables["orderdiraction"].
				Select("deleted is null and diraction_name like 'Менеджер' and idorder=" + o_dr["idorder"].ToString());

			DataRow[] odp_manager_dr = null;
			if (od_manager_dr.Length > 0)
			{
				odp_manager_dr = ds.Tables["orderdiractionpeople"].
							Select("deleted is null and idorder=" + o_dr["idorder"].ToString() +
									" and idorderdiraction=" + od_manager_dr[0]["idorderdiraction"].ToString());
			}

			string manager_idpeople = "";
			if (odp_manager_dr != null && odp_manager_dr.Length > 0)
			{
				manager_idpeople = odp_manager_dr[0]["idpeople"].ToString();
			}

			/*** технолог ***/
			DataRow[] od_tech_dr = ds.Tables["orderdiraction"].
				Select("deleted is null and diraction_name like 'Технолог' and idorder=" + o_dr["idorder"].ToString());

			DataRow[] odp_tech_dr = null;
			if (od_tech_dr.Length > 0)
			{
				odp_tech_dr = ds.Tables["orderdiractionpeople"].
							Select("deleted is null and idorder=" + o_dr["idorder"].ToString() +
									" and idorderdiraction=" + od_tech_dr[0]["idorderdiraction"].ToString());
			}

			string tech_idpeople = "";
			if (odp_tech_dr != null && odp_tech_dr.Length > 0)
			{
				tech_idpeople = odp_tech_dr[0]["idpeople"].ToString();
			}

			/*** профиль ***/


			
			
			/*** структура заказа ***/

			t order = new t()
			{
				
				{
					"_relat",new t()
					{
						{
							"one_to_many",new t()
							{
								"tab_org_unit",
								"tab_sale_office",
								"tab_customer",
								"tab_address",
								"tab_wd_prof_sys",
								"tab_order_sign",
								"tab_adv_type"
								//"tab_concerned_people",
							}
						}
					}
				},
				{"id",""},
				{"name",order_name},
				{"dt_make",order_dtcre},
				{"is_credit",""},
				{"is_vip",""},
				{"discount_zp",""},
				{"terminal",""},
				{"comment",order_comment},
			
				{
					"tab_org_unit",new t()
					{
						new t()
						{
							{"id",""},
							{"name","Пластик"},
							{"_no_update",true}
						}
				
					}
				},
				{
					"tab_sale_office", new t()
					{
						new t()
						{
							{"_no_update",true},
							//_update_if_empty:true,
							{"id",""},
							{"name",""},
							{"wd_idseller", idseller}
						}
					}
				},
				{
					"tab_customer", new t()
					{
						new t()
						{
							{"_update_if_empty",true},
							{"id",""},
							{"name",customer_name},
							{"fio",""},
							{"phone",""},
							{"email",""},
							{"wd_idcustomer", idcustomer}
						}
					}
				},
				{
					"tab_address",new t()
					{
						new t()
						{
							{"_update_if_empty",true},
							{"id",""},
							{"name",customer_name},
							{"wd_idaddress", idcustomer}
						}
					}
				},
						
				{
					"tab_concerned_people", new t()
					{
						new t()
						{
							//_update_if_empty:true,
							{"id",""},
							{
								"tab_people_prof", new t()
								{
									new t()
									{
										{"_update_if_empty",true},
										//_no_update:true,
										{"id",""},
										{"name","Менеджер"}
									}
								}
							},
							{
								"tab_people", new t()
								{
									//_update_if_empty:true,
									{"_no_update",true},
									{"id",""},
									{"name",""},
									{"wd_idpeople", manager_idpeople},
									{
										"tab_people_prof", new t()
										{
											new t()
											{
												{"_update_if_empty",true},
												//_no_update:true,
												{"id",""},
												{"name","Менеджер"}
											}
										}
									}
								}
							}
						},
						new t()
						{
							//_update_if_empty:true,
							{"id",""},
							{
								"tab_people_prof", new t()
								{
									new t()
									{
										{"_update_if_empty",true},
										//_no_update:true,
										{"id",""},
										{"name","Технолог"}
									}
								}
							},
							{
								"tab_people", new t()
								{
									new t()
									{
										//_update_if_empty:true,
										{"_no_update",true},
										{"id",""},
										{"name",""},
										{"wd_idpeople", tech_idpeople},
										{
											"tab_people_prof", new t()
											{
												new t()
												{
													{"_update_if_empty",true},
													//_no_update:true,
													{"id",""},
													{"name","Технолог"}
												}
											}
										}
									}
								}
							}
						}
					}
				},
				{
					"tab_wd_prof_sys", new t()
					{
						new t()
						{
							//_update_if_empty:true,
							{"_no_update",true},
							{"id",""},
							{"name",""},
							{"wd_idprofsys", ""},
						}
					}
				},
				{
					"tab_order_sign", new t()
					{
						new t()
						{
							//_no_update:true,
							{"_update_if_empty",true},
							{"id",""},
							{"name",""}
						}
					}
				},
				{
					"tab_adv_type", new t()
					{
						new t()
						{
							{"_no_update",true},
							//_update_if_empty:true,
							{"id",""},
							{"name",""}
						}
					}
				}
			};


			

			//return new t();

			//выполняем запрос
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				{"method", "POST"},
				{
					"put_tab_arr", new t()
					{
						{"tab_order", new t(){order}}
					}
				},
				{"f_done",args["f_done"].f_f()},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return new t();

		}

		public t f_put_order_diraction(t args)
		{

			string idseller = args["idseller"].f_def(0).f_str();
			string login_name = args["login_name"].f_def(this["login_name"].f_val()).f_def("dnclive").f_str();
			string pass = args["pass"].f_def(this["pass"].f_val()).f_def("135").f_str();

			//авторизуемся
			josi_store.f_login(new t()
			{
				{"login_name",login_name}, 
				{"pass",pass},
				{	
					//если и когда войти удалось
					"f_done", new t_f<t,t>(delegate(t args1)
					{
						//запрос номера
						string res_dot_key_query_str = "kvl.0.f=service_wd_f_get_order_num&"+
														"kvl.1.wd_idseller="+idseller;

						//выполняем запрос
						josi_store.f_query(new t 
						{
							{"res_dot_key_query_str",res_dot_key_query_str},
							//когда возвращен ответ
							{"f_done",args["f_done"].f_f()},
							{"encode_json",true},
							{"cancel_prev",false},
						});

						return new t();
					})
				}
			});

			return new t();
		}

		public t f_get_order_diraction(t args)
		{

			string idseller = args["idseller"].f_def(0).f_str();
			string login_name = args["login_name"].f_def(this["login_name"].f_val()).f_def("dnclive").f_str();
			string pass = args["pass"].f_def(this["pass"].f_val()).f_def("135").f_str();

			//авторизуемся
			josi_store.f_login(new t()
			{
				{"login_name",login_name}, 
				{"pass",pass},
				{	
					//если и когда войти удалось
					"f_done", new t_f<t,t>(delegate(t args1)
					{
						//запрос номера
						string res_dot_key_query_str = "kvl.0.f=service_wd_f_get_order_num&"+
														"kvl.1.wd_idseller="+idseller;

						//выполняем запрос
						josi_store.f_query(new t 
						{
							{"res_dot_key_query_str",res_dot_key_query_str},
							//когда возвращен ответ
							{"f_done",args["f_done"].f_f()},
							{"encode_json",true},
							{"cancel_prev",false},
						});

						return new t();
					})
				}
			});

			return new t();
		}
	

	}
}
