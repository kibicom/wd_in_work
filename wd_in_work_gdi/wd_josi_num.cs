using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using kibicom.josi;
using kibicom.tlib;

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
				{"login_name",login_name}, 
				{"pass",pass},
				{"login_on_cre", true},		//логинимся
				{"f_done", args["f_done"].f_f()}
			});

			this["login_name"] = new t(login_name);
			this["pass"]=new t(pass);
			this["josi_end_point"] = new t(josi_end_point);
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
				//когда возвращен ответ зовем callback
				{"f_done",args["f_done"].f_f()},
				{"encode_json",true},
				{"cancel_prev",false},
				//{"when_login",true},
				{"needs", new t(){"is_auth"}}
			});

			return new t();
		}

		public t f_put_order(t args)
		{

			string idseller = args["idseller"].f_def(0).f_str();
			//string idseller = args["idseller"].f_def(0).f_str();

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
