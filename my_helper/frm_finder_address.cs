using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using kibicom.tlib;
using kibicom.josi;

namespace my_helper
{
	public partial class frm_finder_address : frm_finder
	{
		public frm_finder_address():base()
		{
			InitializeComponent();
		}

		public frm_finder_address(t args): base(args)
		{

		}

		//получение элементов из источника
		public t f_get_items_(t args)
		{

			t query = new t()
			{
				{
					"_query",new t()
					{
						{
							"entry", new t()
							{
								"name"
							}
						}
					}
				},
				{"id", ""},
				{"name", txt_query.Text},
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
						
						//если количество возвращенных результатов 0
						//то предлагаем создать нового контрагента
						if (tab_rows.Count == 0)
						{
							f_fill_lbx(new t());
							return new t();
						}

						//перебираем элементы результата и формируем элменты для listbox
						foreach (Dictionary<string, object> row in tab_rows)
						{

							string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
							string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";


							//создаем очередной элемент
							this.args["items"].Add(new t()
							{
								{"str1", row_name},
								{"str2", ""},
								{
									"item", new t()
									{
										{"id",row_id},
										{"name",row_name},
									}
								}
							});

						}

						f_fill_lbx(new t());

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",true},
			});

			return new t();
		}

		//получение элементов из источника local_store
		override public t f_get_items(t args)
		{

			kwj.f_select_tab_address(new t()
			{
				{
					"where", " _nocase_search like '%"+txt_query.Text+"%' "
				},
				{
					"f_each", new t_f<t,t>(delegate (t args1)
					{
						DataRow dr = args1["each"]["item"].f_val<DataRow>();

						//создаем очередной элемент
						this.args["items"].Add(new t()
						{
							{"str1", dr["name"].ToString()},
							{"str2", ""},
							{
								"item", new t()
								{
									{"id",dr["id"].ToString()},
									{"name",dr["name"].ToString().Replace("\'", "'")},
									{"wd_customer_guid",dr["wd_customer_guid"].ToString()}
								}
							}
						});

						return new t();
					})
				},
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{
						
						f_fill_lbx(new t());

						return new t();
					})
				}
			});



			return new t();
		}
		
		//сохранение созданного клиента в josi_store
		public void fstore_customer()
		{
			//текст введенный менеджером - номер карты
			//string fio = txt_fio.Text;
			//string phone = txt_phone.Text;
			//string email = txt_email.Text;
			//string address = txt_address.Text;

			josi_store.f_gen_id(new t()
			{
				{"res_name","tab_customer"}, 
				{"id_key","id"},
				{
					"f_done",
					new t_f<t,t>(delegate(t args)
					{
						MessageBox.Show(args["id_str"].f_str());
						string id = args["id_str"].f_str();
						string res_dot_key_query_str =	"&kvl.1.tab_arr.tab_customer.0.id=" + id +
														"&kvl.1.tab_arr.tab_customer.0.name=" + args["selected_item"]["name"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.phone=" + args["selected_item"]["phone"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.email=" + args["selected_item"]["email"].f_str();


						josi_store.f_store(new t()
						{
							{"res_dot_key_query_str",res_dot_key_query_str},
							{
								"f_done",
								new t_f<t,t>(delegate(t args1)
								{
									MessageBox.Show(args1["resp_str"].f_str());
									return null;
								})
							},
							{"encode_json",true},
							{"cancel_prev",true},
						});

						/*
						josi_store.f_store(new t_josi_store_req_args
						(
							res_dot_key_query_str,
							delegate(t_josi_store_req_args args1)
							{
								MessageBox.Show(args1.resp_str);
							}, 
							true, 
							true
						));
						 * */
						return null;
					})
				}
			});

			return;

		}

		override public t f_select_item()
		{

			t.f_f("f_done", args);

			Hide();

			return new t();
		}

		override public t f_cre_item(t args)
		{

			//создаем форму ввода данных нового контрагента
			frm_cre_edit_item = new customer_info.customer_info_form(txt_query.Text);

			//показываем форму как диалог
			frm_cre_edit_item.ShowDialog();

			if (((customer_info.customer_info_form)frm_cre_edit_item).args["is_done"].f_bool())
			{
				//в результате деактивации текущего окна (окна поиска)
				//оно скроется так как предыдущее окно было диалогом
				//сюда мы попадем когда его закроют - данные введут
				//поэтом вновь показываем себя
				Show();

				//selected_item = ((customer_info.customer_info_form)frm_cre_edit_item).customer;

				t created_customer = ((customer_info.customer_info_form)frm_cre_edit_item).customer;

				//this.args["selected_item"]["str1"] = this.args["selected_item"]["item"]["name"];
				//this.args["selected_item"]["str2"] = this.args["selected_item"]["item"]["phone"];

				//добавляем созданный элемент в кэш времени выполнения
				//запрос f_find() выполниться из кеша что бы не обращаться к серверу
				this.args["new_items"].Add(new t()
				{
					{"str1", created_customer["name"]},
					{"str2", ""},
					{"item", created_customer}
				});


				f_find(new t()
				{
					{
						"f_done", new t_f<t,t> (delegate (t args1)
							{

								f_touch_lbx_item();

								return new t();
							})
					}
				});

			}

			return new t();
		}
	}
}
