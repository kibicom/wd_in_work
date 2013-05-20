using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;


using kibicom.tlib;
using kibicom.josi;

namespace my_helper
{
	public class t_kwj:t
	{

		public t_kwj()
		{

		}

		public t_kwj(t args)
		{
			f_cre_josi_store(args["josi_store"]);

			f_cre_local_db(args["local_store"]);

		}

		public t f_cre_local_db(t args)
		{
			string file_name = args["file_name"].f_str();

			//создаем клиента, подключаемся
			t_sqlite_cli cli = new t_sqlite_cli(new t()
			{
				{"location", file_name},
				{"conn_keep_open", true}
			});

			this["sqlite_cli"].f_set(cli);

			return this;
		}

		public t f_cre_josi_store(t args)
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_end_point"].
				f_def("http://kibicom.com/order_store_339/index.php").f_str();
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				//f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();
		
			t_store josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},		//точка подключения josi
				{"req_timeout", args["req_timeout"].f_def(5000).f_int()},	//таймаут запроса
				{"login_name",login_name},				//имя для входа
				{"pass",pass},							//пароль для входа
				{"login_on_cre", true},					//логинимся
				{"auth_try_count", args["auth_try_count"].f_def(3).f_int()},	//количество попыток авторизации
				{"f_done", args["f_done"].f_f()},		//вызываем когда авторизуемся успешно
				{"f_fail", args["f_fail"].f_f()}		//вызываем если авторизация не удалась
			});

			this["josi_store"] = josi_store;

			return this;
		}

		public t f_kwj_cre(t args)
		{

			string file_name = args["local_store"]["file_name"].f_str();

			File.Delete(file_name);

			t_sqlite_cli cli=this["sqlite_cli"].f_val<t_sqlite_cli>();

			if (cli==null)
			{
				cli = f_cre_local_db(args["local_store"])["sqlite_cli"].f_val<t_sqlite_cli>();
			}

			//создаем таблицу tab_customer
			cli.f_exec_cmd(new t()
			{
				{"cmd",@"CREATE TABLE IF NOT EXISTS tab_customer (
						id_tab INTEGER PRIMARY KEY AUTOINCREMENT,
						  id INTEGER,
						  dtcre INTEGER,
						  deleted INTEGER,
						  id_login INTEGER,
						  name TEXT,
						  fio TEXT,
						  phone TEXT,
						  email TEXT,
						  site TEXT,
						  wd_idcustomer INTEGER,
							wd_customer_guid TEXT,
							_nocase_search TEXT
						)"},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						

						return new t();
					})
				}
			});

			//tab_address
			cli.f_exec_cmd(new t()
			{
				{"cmd",@"CREATE TABLE IF NOT EXISTS tab_address (
						id_tab INTEGER PRIMARY KEY AUTOINCREMENT,
						  id INTEGER,
						  dtcre INTEGER,
						  deleted INTEGER,
						  id_login INTEGER,
						  name TEXT,
							_nocase_search
						)"},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						t_deb.f_deb("unit_test", "table {0} create is fail...", "TEST_TABLE");

						return new t();
					})
				}
			});

			return new t();
		}

		#region наполнение базы

		public t f_fill_tab_customer(t args)
		{

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sqlite_cli"].f_val<t_sqlite_cli>();
			}

			//запрос всех клиентов из Кибиком
			t query = new t()
			{
				{"_limit", new t(){0, 1000000}},
				{"id", ""},
				{"dtcre", ""},
				{"name", ""},
				{"phone", ""},
				{"email", ""},
				{"wd_customer_guid", ""}
			};

			//выполняем запрос
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				{"needs", new t(){"is_auth_done"}},		//когда выполниться процесс авторизации
				{"method", "POST"},
				{
					"get_tab_arr", new t()
					{
						{"tab_customer", new t(){query}}
					}
				},
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_done", new t_f<t,t>(delegate(t args1)
					{

						//если есть не пустой ответ
						if (args1["resp_json"].f_val() == null)
						{
							return null;
						}

						string tab = "tab_customer";
						ArrayList tab_rows = (ArrayList)args1["resp_json"].f_val<Dictionary<string, object>>()[tab];

						MessageBox.Show("selected="+tab_rows.Count.ToString());

						//если количество возвращенных результатов 0
						//то предлагаем создать нового контрагента
						if (tab_rows.Count == 0)
						{
							return new t();
						}

						int fail_count = 0;

						//перебираем элементы результата и формируем элменты для listbox
						foreach (Dictionary<string, object> row in tab_rows)
						{

							string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
							string row_dtcre = row.ContainsKey("dtcre") && row["dtcre"] != null ? row["dtcre"].ToString() : "";
							string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";
							string row_phone = row.ContainsKey("phone") && row["phone"] != null ? row["phone"].ToString() : "";
							string row_email = row.ContainsKey("email") && row["email"] != null ? row["email"].ToString() : "";
							string row_wd_customer_guid = row.ContainsKey("wd_customer_guid") && row["wd_customer_guid"] != null ?
															row["wd_customer_guid"].ToString() : "";

							DateTime dtcre=new DateTime();
							DateTime.TryParse(row_dtcre, out dtcre);
							int dtcre_ut = (int)(dtcre.ToUniversalTime()- new DateTime(1970, 1, 1)).TotalSeconds;

							cli.f_exec_cmd(new t()
							{
								//запрос блокирует клиента
								{"block", true},
								{"cmd", "insert into tab_customer (id, dtcre, name, phone, email, "+
										"wd_customer_guid, _nocase_search) values ("+
										row_id+","+
										dtcre_ut+",'"+
										row_name.Replace("'", "''")+"','"+
										row_phone.Replace("'", "''")+"','"+
										row_email.Replace("'", "''")+"','"+
										row_wd_customer_guid+"','"+
										(row_name+row_phone+row_email).Replace("'", "''").ToLower()+"') "
								},
								{
									"f_done", new t_f<t,t>(delegate (t args2)
									{


										return new t();
									})
								},
								{
									"f_fail", new t_f<t,t>(delegate (t args2)
									{

										//MessageBox.Show("fail get rows from kibicom");

										return new t();
									})
								}
							});


						}

						MessageBox.Show("fill tab_customer done. try=" + tab_rows.Count.ToString() + " fails=" + fail_count.ToString());

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return this;
		}

		public t f_fill_tab_address(t args)
		{
			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sqlite_cli"].f_val<t_sqlite_cli>();
			}

			//запрос все адреса из Кибиком
			t query = new t()
			{
				{"_limit", new t(){0, 1000000}},
				{"id", ""},
				{"dtcre", ""},
				{"name", ""}
			};

			//выполняем запрос
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				{"needs", new t(){"is_auth_done"}},		//когда выполниться процесс авторизации
				{"method", "POST"},
				{
					"get_tab_arr", new t()
					{
						{"tab_address", new t(){query}}
					}
				},
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_done", new t_f<t,t>(delegate(t args1)
					{

						//если есть не пустой ответ
						if (args1["resp_json"].f_val() == null)
						{
							return null;
						}

						string tab = "tab_address";
						ArrayList tab_rows = (ArrayList)args1["resp_json"].f_val<Dictionary<string, object>>()[tab];

						//MessageBox.Show(tab_rows.Count.ToString());

						//если количество возвращенных результатов 0
						//то предлагаем создать нового контрагента
						if (tab_rows.Count == 0)
						{
							return new t();
						}

						int fail_count=0;

						//перебираем элементы результата и формируем элменты для listbox
						foreach (Dictionary<string, object> row in tab_rows)
						{

							string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
							string row_dtcre = row.ContainsKey("dtcre") && row["dtcre"] != null ? row["dtcre"].ToString() : "";
							string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";

							DateTime dtcre=new DateTime();
							DateTime.TryParse(row_dtcre, out dtcre);
							int dtcre_ut = (int)(dtcre.ToUniversalTime()- new DateTime(1970, 1, 1)).TotalSeconds;

							cli.f_exec_cmd(new t()
							{
								//запрос блокирует клиента
								{"block", true},
								{"cmd", "insert into tab_address (id, dtcre, name, _nocase_search) values ("+
										row_id+","+
										dtcre_ut+",'"+
										row_name.Replace("'", "\'")+",'"+
										row_name.Replace("'", "\'").ToLower()+"') "
								},
								{
									"f_done", new t_f<t,t>(delegate (t args2)
									{


										return new t();
									})
								},
								{
									"f_fail", new t_f<t,t>(delegate (t args2)
									{

										//MessageBox.Show("fail insert tab_customer row");
										fail_count++;
										return new t();
									})
								}
							});


						}

						MessageBox.Show("fill tab_address done. try=" + tab_rows.Count.ToString() + " fails=" + fail_count.ToString());

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return this;

		}

		public t f_tab_customer_add(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sqlite_cli"].f_val<t_sqlite_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "insert into tab_customer (name, phone, email, wd_customer_guid, _nocase_search) values ('"+
						new_item["name"].f_str()+"','"+
						new_item["phone"].f_str()+"','"+
						new_item["email"].f_str()+"','"+
						new_item["wd_customer_guid"].f_str()+"','"+
						(new_item["name"].f_str()+new_item["phone"].f_str()+new_item["email"].f_str()).ToLower()+"') "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args2)
					{

						return new t();
					})
				}
			});

			//сохраняем в кибиком


			return this;


		}

		public t f_tab_address_add(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sqlite_cli"].f_val<t_sqlite_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{
					"cmd", "insert into tab_address (name, _nocase_search) values ('"+
							new_item["name"].f_str()+"','"+
							new_item["name"].f_str().ToLower()+"') "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args2)
					{

						return new t();
					})
				}
			});

			//сохраняем в кибиком


			return this;


		}

		#endregion наполнение базы

		#region SELECT

		public t f_select_tab_customer(t args)
		{

			string where = args["where"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sqlite_cli"].f_val<t_sqlite_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT * FROM tab_customer where "+where},
				{
					"f_each", args["f_each"].f_f()
				},
				{
					"f_done", args["f_done"].f_f()
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						

						return new t();
					})
				}
			});

			return this;
		}

		public t f_select_tab_address(t args)
		{

			string where = args["where"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sqlite_cli cli = this["sqlite_cli"].f_val<t_sqlite_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sqlite_cli"].f_val<t_sqlite_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT * FROM tab_address where "+where},
				{
					"f_each", args["f_each"].f_f()
				},
				{
					"f_done", args["f_done"].f_f()
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						

						return new t();
					})
				}
			});

			return this;
		}

		#endregion SELECT
	}
}
