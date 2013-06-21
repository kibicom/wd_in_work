using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;


using kibicom.tlib;
using kibicom.tlib.data_store_cli;
using kibicom.josi;

namespace kibicom.my_wd_helper
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
			string store_type = args["store_type"].f_str();
			t_sql_store_cli cli = null;

			if (store_type == "mssql")
			{
				//параметры переданне для этого подключения
				t mssql_cli=args["mssql_cli"];

				//создаем клиента
				cli = new t_msslq_cli(new t()
				{
					{"connection_str",			mssql_cli["connection_str"]},
					{"server",					mssql_cli["server"]},
					{"server_name",				mssql_cli["server_name"].f_def("")},
					{"login",					mssql_cli["login"]},
					{"pass",					mssql_cli["pass"]},
					{"db_name",					mssql_cli["db_name"]},
					{"tab_name",				mssql_cli["tab_name"]},
					{"conn",					mssql_cli["conn"]},
					{"conn_keep_open",			mssql_cli["conn_keep_open"].f_def(true)}
				});
			}
			else if (store_type=="sqlite")
			{
				//параметры переданне для этого подключения
				t sqlite_cli = args["sqlite_cli"];
				string file_name = sqlite_cli["file_name"].f_str();

				if (File.Exists(file_name)) File.Delete(file_name);

				//создаем клиента, подключаемся
				cli = new t_sqlite_cli(new t()
				{
					{"location", file_name},
					{"conn_keep_open", true}
				});
			}

			//запоминаем клиента
			this["sql_store_cli"].f_set(cli);

			return this;
		}

		public t f_cre_josi_store(t args)
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("4947").f_str();
			string josi_end_point = args["josi_end_point"].
				f_def("http://kibicom.com/order_store_339/index.php").f_str();
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				//f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();

			//MessageBox.Show(login_name);

			t_store josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},		//точка подключения josi
				{"req_timeout", args["req_timeout"].f_def(5000).f_int()},	//таймаут запроса
				{"login_name",login_name},				//имя для входа
				{"pass",pass},							//пароль для входа
				{"login_on_cre", true},					//логинимся
				{"auth_try_count", args["auth_try_count"].f_def(3).f_int()},	//количество попыток авторизации
				{"f_done_", args["f_done"].f_f()},		//вызываем когда авторизуемся успешно
				{"f_fail_", args["f_fail"].f_f()},		//вызываем если авторизация не удалась
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_done", new t_f<t,t>(delegate(t args1)
					{
						return new t();
					})
				},
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_fail", new t_f<t,t>(delegate(t args1)
					{
						return new t();
					})
				},
			});

			this["josi_store"] = josi_store;

			return this;
		}

		public t f_kwj_sqlite_cre(t args)
		{

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli==null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
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

		public t f_kwj_mssql_cre(t args)
		{

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			//создаем таблицу tab_customer
			cli.f_exec_cmd(new t()
			{
				{
					"cmd",@"
								IF (EXISTS (SELECT * 
												 FROM INFORMATION_SCHEMA.TABLES 
												 WHERE TABLE_SCHEMA = 'dbo' 
												 AND  TABLE_NAME = 'tab_customer'))
								BEGIN
								   drop table tab_customer
								END
								
								CREATE TABLE [dbo].[tab_customer](
									[id_tab] [int] IDENTITY(1,1) NOT NULL,
									[id] [int] NULL,
									[dtcre] [datetime] NULL,
									[deleted] [datetime] NULL,
									[id_login] [int] NULL,
									[name] [varchar](1000) NULL,
									[fio] [varchar](1000) NULL,
									[phone] [varchar](1000) NULL,
									[email] [varchar](1000) NULL,
									[site] [varchar](1000) NULL,
									[wd_idcustomer] [int] NULL,
									[wd_customer_guid] [uniqueidentifier] NULL,
								 CONSTRAINT [PK_tab_customer] PRIMARY KEY CLUSTERED 
								(
									[id_tab] ASC
								)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
								) ON [PRIMARY]
								
								"
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						MessageBox.Show("tab_customer пересоздан");

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
				{
					"cmd",@"
								IF (EXISTS (SELECT * 
												 FROM INFORMATION_SCHEMA.TABLES 
												 WHERE TABLE_SCHEMA = 'dbo' 
												 AND  TABLE_NAME = 'tab_address'))
								BEGIN
								   drop table tab_address
								END
								CREATE TABLE [dbo].[tab_address](
									[id_tab] [int] IDENTITY(1,1) NOT NULL,
									[id] [int] NULL,
									[dtcre] [datetime] NULL,
									[deleted] [datetime] NULL,
									[id_login] [int] NULL,
									[name] [varchar](1000) NULL
								 CONSTRAINT [PK_tab_address] PRIMARY KEY CLUSTERED 
								(
									[id_tab] ASC
								)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
								) ON [PRIMARY]

								"
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						MessageBox.Show("tab_address пересоздан");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} create is fail...", "TEST_TABLE");

						return new t();
					})
				}
			});

			//tab_pick
			cli.f_exec_cmd(new t()
			{
				{
					"cmd",@"
								IF (EXISTS (SELECT * 
												 FROM INFORMATION_SCHEMA.TABLES 
												 WHERE TABLE_SCHEMA = 'dbo' 
												 AND  TABLE_NAME = 'tab_pick'))
								BEGIN
								   drop table tab_pick
								END
								CREATE TABLE [dbo].[tab_pick](
									[id_tab] [int] IDENTITY(1,1) NOT NULL,
									[id] [int] NULL,
									[dtcre] [datetime] NULL,
									[deleted] [datetime] NULL,
									[id_login] [int] NULL,
									tab_address_id int null,
									tab_customer_id int null,
									tab_seller_id int null,
									[wd_customer_guid] [uniqueidentifier] NULL,
									[wd_seller_guid] [uniqueidentifier] NULL,
								 CONSTRAINT [PK_tab_pick] PRIMARY KEY CLUSTERED 
								(
									[id_tab] ASC
								)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
								) ON [PRIMARY]

								"
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						MessageBox.Show("tab_pick пересоздан");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} create is fail...", "TEST_TABLE");

						return new t();
					})
				}
			});

			//tab_relat_391
			cli.f_exec_cmd(new t()
			{
				{
					"cmd",@"
								IF (EXISTS (SELECT * 
												 FROM INFORMATION_SCHEMA.TABLES 
												 WHERE TABLE_SCHEMA = 'dbo' 
												 AND  TABLE_NAME = 'tab_relat_391'))
								BEGIN
								   drop table tab_relat_391
								END
								CREATE TABLE [dbo].[tab_relat_391](
									[id_tab] [int] IDENTITY(1,1) NOT NULL,
									[id] [int] NULL,
									[dtcre] [datetime] NULL,
									[deleted] [datetime] NULL,
									[id_login] [int] NULL,
									[name] [varchar](1000) NULL,
									tab_address_id int null,
									tab_customer_id int null
								 CONSTRAINT [PK_tab_relat_391] PRIMARY KEY CLUSTERED 
								(
									[id_tab] ASC
								)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
								) ON [PRIMARY]

								"
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						MessageBox.Show("tab_pick пересоздан");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} create is fail...", "TEST_TABLE");

						return new t();
					})
				}
			});

			//tab_freq
			cli.f_exec_cmd(new t()
			{
				{
					"cmd",@"
								IF (EXISTS (SELECT * 
												 FROM INFORMATION_SCHEMA.TABLES 
												 WHERE TABLE_SCHEMA = 'dbo' 
												 AND  TABLE_NAME = 'tab_freq'))
								BEGIN
								   drop table tab_freq
								END
								CREATE TABLE [dbo].[tab_freq](
									[id_tab] [int] IDENTITY(1,1) NOT NULL,
									[id] [int] NULL,
									[dtcre] [datetime] NULL,
									[deleted] [datetime] NULL,
									[id_login] [int] NULL,
									[tab_address_id] [int] NULL,
									[tab_customer_id] [int] NULL,
									[tab_seller_id] [int] NULL,
									[wd_customer_guid] [uniqueidentifier] NULL,
									[wd_seller_guid] [uniqueidentifier] NULL,
									[freq] [int] NULL,
								 CONSTRAINT [PK_tab_freq] PRIMARY KEY CLUSTERED 
								(
									[id_tab] ASC
								)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
								) ON [PRIMARY]

								"
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} created successfull...", "TEST_TABLE");

						MessageBox.Show("tab_pick пересоздан");

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						//t_deb.f_deb("unit_test", "table {0} create is fail...", "TEST_TABLE");

						return new t();
					})
				}
			});

			return new t();
		}


		#region наполнение базы

		public t f_fill_tab_customer_sqlite(t args)
		{

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
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

		public t f_fill_tab_address_sqlite(t args)
		{
			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
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


		public t f_fill_tab_customer_mssql(t args)
		{

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
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

							cli.f_exec_cmd(new t()
							{
								//запрос блокирует клиента
								{"block", true},
								{"cmd", "insert into tab_customer (id, dtcre, name, phone, email, "+
										"wd_customer_guid) values ("+
										row_id+",'"+
										dtcre.ToString("yyyy-MM-dd HH:mm:ss")+"','"+
										row_name.Replace("'", "''")+"','"+
										row_phone.Replace("'", "''")+"','"+
										row_email.Replace("'", "''")+"',"+
										(row_wd_customer_guid==""?"null":"'"+row_wd_customer_guid+"'")+") "
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
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						MessageBox.Show("не удалось получить tab_customer из кибиком");

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return this;
		}

		public t f_fill_tab_address_mssql(t args)
		{
			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args["josi_store"])["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args["local_store"])["sql_store_cli"].f_val<t_sql_store_cli>();
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

						MessageBox.Show("selected=" + tab_rows.Count.ToString());

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
								{"cmd", "insert into tab_address (id, dtcre, name) values ("+
										row_id+",'"+
										dtcre.ToString("yyyy-MM-dd HH:mm:ss")+"','"+
										row_name.Replace("'", "''")+"') "
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
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						MessageBox.Show("не удалось получить tab_addres из кибиком");

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			return this;

		}


		public t f_tab_customer_add_sqlite(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
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

		public t f_tab_address_add_sqlite(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
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


		public t f_tab_customer_add_mssql(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "insert into tab_customer (uid, dtcre, name, phone, email, wd_customer_guid) values ('"+
						new_item["uid"].f_str()+"','"+
						new_item["dtcre"].f_str()+"','"+
						new_item["name"].f_str()+"','"+
						new_item["phone"].f_str()+"','"+
						new_item["email"].f_str()+"','"+
						new_item["wd_customer_guid"].f_str()+"') "
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

		public t f_tab_address_add_mssql(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{
					"cmd", "insert into tab_address (uid,name) values ('"+
							new_item["uid"].f_str()+"','"+
							new_item["name"].f_str()+"') "
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


		public t f_tab_customer_modify_mssql(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_customer set "+
						"name='"+new_item["name"].f_str()+
						"', phone='"+new_item["phone"].f_str()+
						"', email='"+new_item["email"].f_str()+
						"' where uid='"+new_item["uid"].f_str()+"' "
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

		public t f_tab_address_modify_mssql(t args)
		{
			t new_item = args["item"];

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{
					"cmd", "update tab_address set name='"+
							new_item["name"].f_str()+"'"+
							" where uid='"+new_item["uid"].f_str()+"' "
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
			string limit = args["limit"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT top "+limit+" * FROM view_tab_customer where "+where},
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

		public t f_select_tab_customer_address(t args)
		{

			string where = args["where"].f_str();
			string limit = args["limit"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT top "+limit+" * FROM view_tab_customer_address where "+where},
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
			string limit = args["limit"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT  top "+limit+" * FROM tab_address where "+where},
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

		#region взаимодействие

		public t f_tab_customer_pick_mssql(t args)
		{

			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "insert into tab_pick (tab_customer_uid, wd_seller_guid) values ('"+
						new_item["uid"].f_str()+"','"+
						wd_seller_guid+"') "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["tab_pick_id"].f_set(1);

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


			return new t();
		}

		public t f_tab_customer_unpick_mssql(t args)
		{

			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//удаляем все строки из tab_pick для данного сочетания продавца и контрагента
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_pick set deleted=getdate() where deleted is null"+
							" and wd_seller_guid='"+wd_seller_guid+
							"' and tab_customer_uid='"+new_item["uid"].f_str()+"' "},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["tab_pick_id"].f_set("");

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


			return new t();
		}


		public t f_tab_customer_drop_mssql(t args)
		{

			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_customer set deleted=getdate() where deleted is null"+
							" and uid='"+new_item["uid"].f_str()+"' "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["deleted"].f_set(DateTime.Now);

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

		public t f_tab_customer_revert_mssql(t args)
		{
			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//удаляем все строки из tab_pick для данного сочетания продавца и контрагента
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_customer set deleted=null where deleted is not null"+
							" and uid='"+new_item["uid"].f_str()+"' "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["deleted"].f_set("");

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


		public t f_tab_address_drop_mssql(t args)
		{

			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_address set deleted=getdate() where deleted is null"+
							" and uid='"+new_item["uid"].f_str()+"' "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["deleted"].f_set(DateTime.Now);

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

		public t f_tab_address_revert_mssql(t args)
		{
			t new_item = args["item"];
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//удаляем все строки из tab_pick для данного сочетания продавца и контрагента
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "update tab_address set deleted=null where deleted is not null"+
							" and uid='"+new_item["uid"].f_str()+"' "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["deleted"].f_set("");

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


		public t f_store_customer_address_relat(t args)
		{
			t new_item = args["item"];
			string tab_customer_uid = args["tab_customer_uid"].f_str();
			string tab_address_uid = args["tab_address_uid"].f_str();
			string wd_seller_guid = args["wd_seller_guid"].f_str();

			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}


			//сохраняем в локальный кеш
			cli.f_exec_cmd(new t()
			{
				//запрос блокирует клиента
				{"block", true},
				{"cmd", "insert into tab_relat_391 (tab_customer_uid, tab_address_uid) values ('"+
						tab_customer_uid+"','"+
						tab_address_uid+"') "
				},
				{
					"f_done", new t_f<t,t>(delegate (t args2)
					{

						new_item["tab_pick_id"].f_set(1);

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


		

		#endregion взаимодействие

		#region product supply

		public t f_get_tab_product_supply(t args)
		{

			string where = args["where"].f_def(" deleted is null ").f_str();
			string limit = args["limit"].f_def(" 10000 ").f_str();

			/*
			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}
			*/
			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			cli.f_select(new t()
			{
				{"cmd","SELECT  top "+limit+" * FROM tab_product_supply where "+where},
				{
					"f_each", args["f_each"].f_f()
				},
				{
					"f_done", args["f_done"].f_f()
				},
				{
					"f_fail", args["f_fail"].f_f()
				}
			});

			return this;
		}

		public t f_put_tab_product_supply(t args)
		{

			DataTable tab = args["tab"].f_val<DataTable>();

			/*
			t_store josi_store = this["josi_store"].f_val<t_store>();
			if (josi_store == null)
			{
				josi_store = f_cre_josi_store(args)["josi_store"].f_val<t_store>();
			}
			*/

			t_sql_store_cli cli = this["sql_store_cli"].f_val<t_sql_store_cli>();
			if (cli == null)
			{
				cli = f_cre_local_db(args)["sql_store_cli"].f_val<t_sql_store_cli>();
			}

			cli.f_store_tab(new t()
			{
				{"tab",tab},
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

		#endregion product supply

	}
}
