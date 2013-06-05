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
				{"idorder","96785"}

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
			string res_dot_key_query_str = "kvl.0.f=service_wd_f_get_order_num_year&"+
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

		private t _f_store_order(t args)
		{

			DataSet ds = args["ds"].f_val<DataSet>();
			string kibicom_order_id = args["kibicom_order_id"].f_def("").f_str();

			DataRow o_dr = ds.Tables["orders"].Select("deleted is null")[0];

			dbconn._db.command.CommandText = 
				"select * from view_kibicom_wd_order where idorder=" + o_dr["idorder"].ToString();

			DataTable tab_wd_o=null;

			dbconn._db.adapter.Fill(tab_wd_o);

			//string idseller = o_dr["idseller"].ToString();
			string order_name = o_dr["name"].ToString();
			string order_dtcre = t_uti.f_mssql_dt(o_dr["dtcre"].ToString());
			string order_comment = o_dr["comment"].ToString();
			string order_guid = o_dr["guid"].ToString();

			DataRow c_dr = ds.Tables["customer"].
							Select("deleted is null and idcustomer="+o_dr["idcustomer"].ToString())[0];
			string idcustomer=c_dr["idcustomer"].ToString();
			string customer_name = c_dr["name"].ToString();
			string address_name = c_dr["name"].ToString();
			string customer_guid = c_dr["guid"].ToString();

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
			string manager_people_guid = "";
			if (odp_manager_dr != null && odp_manager_dr.Length > 0)
			{
				manager_idpeople = odp_manager_dr[0]["idpeople"].ToString();
				manager_people_guid = odp_manager_dr[0]["guid"].ToString();
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
			string tech_people_guid = "";
			if (odp_tech_dr != null && odp_tech_dr.Length > 0)
			{
				tech_idpeople = odp_tech_dr[0]["idpeople"].ToString();
				tech_people_guid = odp_manager_dr[0]["guid"].ToString();
			}

			/*** продавец ***/

			DataRow[] s_dr = ds.Tables["seller"].
							Select("deleted is null and idseller=" + o_dr["idseller"].ToString());
			
			string idseller="";
			string seller_guid="";
			if (s_dr != null && s_dr.Length > 0)
			{
				idseller = s_dr[0]["idseller"].ToString();
				//string customer_name = c_dr["name"].ToString();
				//string address_name = c_dr["name"].ToString();
				seller_guid = s_dr[0]["guid"].ToString();
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
				{"id",kibicom_order_id},
				{"name",order_name},
				{"dt_make",order_dtcre},
				{"is_credit",""},
				{"is_vip",""},
				{"discount_zp",""},
				{"terminal",""},
				{"comment",order_comment},
				{"wd_order_guid",order_guid},
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
							//{"wd_idseller", idseller},
							{"dw_seller_guid", seller_guid},
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
							//{"wd_idcustomer", idcustomer},
							{"wd_customer_guid", customer_guid}
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
							//{"wd_idaddress", idcustomer},
							{"wd_customer_guid", customer_guid}
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
									//{"wd_idpeople", manager_idpeople},
									{"wd_people_guid", manager_people_guid},
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
										//{"wd_idpeople", tech_idpeople},
										{"wd_people_guid", tech_people_guid},
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
				}
				/*,
				{
					"tab_wd_prof_sys", new t()
					{
						new t()
						{
							//_update_if_empty:true,
							{"_no_update",true},
							{"id",""},
							{"name",""},
							//{"wd_idprofsys", ""},
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
				}*/
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
				{"f_fail",args["f_fail"].f_f()},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return new t();

		}

		private t _f_store_order_3(t args)
		{

			DataSet ds = args["ds"].f_val<DataSet>();
			string kibicom_order_id = args["kibicom_order_id"].f_def("").f_str();

			DataRow o_dr = ds.Tables["orders"].Select("deleted is null")[0];

			//dbconn._db.command.CommandText =
			//	"select * from view_kibicom_wd_order where idorder=" + o_dr["idorder"].ToString();

			DataTable tab_wd_o = dbconn._db.GetDataTable
				("select * from view_kibicom_wd_order where idorder=" + o_dr["idorder"].ToString());

			//dbconn._db.adapter.Fill(tab_wd_o);

			if (tab_wd_o.Rows.Count == 0)
			{

				t.f_f("f_fail", args);

				return new t();
			}

			DataRow wd_o_dr = tab_wd_o.Rows[0];

			//string idseller = o_dr["idseller"].ToString();
			string order_name = wd_o_dr["order_name"].ToString();
			string order_dtcre = t_uti.f_mssql_dt(wd_o_dr["order_dtcre"].ToString());
			string order_comment = wd_o_dr["order_comment"].ToString();
			string order_guid = wd_o_dr["order_guid"].ToString();

			string customer_name = wd_o_dr["customer_name"].ToString();
			string customer_guid = wd_o_dr["customer_guid"].ToString();

			string address_name = wd_o_dr["address_name"].ToString();
			string address_guid = wd_o_dr["address_guid"].ToString();

			string man_name = wd_o_dr["man_name"].ToString();
			string man_guid = wd_o_dr["man_guid"].ToString();

			string tech_name = wd_o_dr["tech_name"].ToString();
			string tech_guid = wd_o_dr["tech_guid"].ToString();

			/*** продавец ***/
			string seller_name = wd_o_dr["seller_name"].ToString();
			string seller_guid = wd_o_dr["seller_guid"].ToString();


			/*** профиль фурнитура***/
			string profsys_name = wd_o_dr["profsys_name"].ToString();
			string furnsys_name = wd_o_dr["furnsys_name"].ToString();

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
								"tab_adv_type",
								"tab_concerned_people"
							}
						}
					}
				},
				{"id",kibicom_order_id},
				{"name",order_name},
				{"dt_make",order_dtcre},
				{"is_credit",""},
				{"is_vip",""},
				{"discount_zp",""},
				{"terminal",""},
				{"comment",order_comment},
				{"wd_order_guid",order_guid},
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
							//{"wd_idseller", idseller},
							{"dw_seller_guid", seller_guid},
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
							//{"wd_idcustomer", idcustomer},
							{"wd_customer_guid", customer_guid}
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
							{"name",address_name},
							//{"wd_idaddress", idcustomer},
							{"wd_address_guid", address_guid}
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
									new t()
									{
										{"_update_if_empty",true},
										//{"_no_update",true},
										{"id",""},
										{"name",man_name},
										//{"wd_idpeople", manager_idpeople},
										{"wd_people_guid", man_guid},
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
										{"_update_if_empty",true},
										//{"_no_update",true},
										{"id",""},
										{"name",tech_name},
										//{"wd_idpeople", tech_idpeople},
										{"wd_people_guid", tech_guid},
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
							{"_update_if_empty",true},
							//{"_no_update",true},
							{"id",""},
							{"name",profsys_name},
							//{"wd_idprofsys", ""},
						}
					}
				}
				,
				{
					"tab_order_sign", new t()
					{
						new t()
						{
							{"_no_update",true},
							//{"_update_if_empty",true},
							{"id",""},
							{"name","Заказчик"}
						}
					}
				}
				/*,
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
				}*/
			};


			string order_json = order.f_json()["json_str"].f_str();

			//MessageBox.Show(order_json);

			//return new t();

			//выполняем запрос
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				//{"debug_group", "tstore_relat_one_to_many"},
				//{"debug_group", "tstore_sql"},
				{"method", "POST"},
				{
					"put_tab_arr", new t()
					{
						{"tab_order", new t(){order}}
					}
				},
				{"f_done",args["f_done"].f_f()},
				{"f_fail",args["f_fail"].f_f()},
				{"encode_json",true},
				{"cancel_prev",false},
				{"needs", new t(){"is_auth_done","authenticated"}}		//когда выполниться процесс авторизации
			});

			return new t();

		}

		public t f_put_order(t args)
		{

			DataSet ds = args["ds"].f_val<DataSet>();
			DataRow o_dr = ds.Tables["orders"].Select("deleted is null")[0];

			string order_guid = o_dr["guid"].ToString();

			t order_get = new t()
			{
				{"id",""},
				{"wd_order_guid",order_guid}
			};

			//MessageBox.Show(order_guid);

			//выполняем запрос kibicom id заказа по guid
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				{"method", "POST"},
				//{"debug_group", "tstore_sql"},
				{
					"get_tab_arr", new t()
					{
						{"tab_order", new t(){order_get}}
					}
				},
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_done", new t_f<t,t>(delegate(t args1)
					{
						string kibicom_order_id = "";
						if (args1["resp_str"].f_str().Contains("id"))
						{
							kibicom_order_id = t_dot.f_get_val_from_json_obj
							(
								args1["resp_json"].f_val(),
								"tab_order.0.id"
							).ToString();
						}

						//выполняем сохранение текущей информации по заказу
						_f_store_order_3(new t().f_add(true,args).f_add(true, new t() 
						{ 
							{ "kibicom_order_id", kibicom_order_id },
							{
								"f_done", new t_f<t,t>(delegate(t args2)
								{
									
									//MessageBox.Show("done");

									t.f_f("f_done", args);

									return new t();
								})
							},
							{
								"f_fail", new t_f<t,t>(delegate(t args2)
								{

									//MessageBox.Show("fail");

									t.f_f("f_fail", args);

									return new t();
								})
							}
						}));

						return new t();
					})
				},
				{"f_fail",args["f_fail"]},
				{"encode_json",true},
				{"cancel_prev",false},
				{"needs", new t(){"is_auth_done","authenticated"}}		//когда выполниться процесс авторизации
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
