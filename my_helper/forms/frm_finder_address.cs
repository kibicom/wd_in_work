using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using kibicom.tlib;
using kibicom.josi;


namespace kibicom.my_wd_helper
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
			string tab_customer_uid = this.args["tab_customer_uid"].f_str();
			string query=txt_query.Text.Replace(' ', '%');
			query = (new Regex("(\\d)")).Replace(query, "$1%");
			//query = (new Regex("(\\d)")).Replace(query, "$1[- ,/]");

			string where = "";
			if (this.args["using_local_store"].f_str() == "mssql")
			{
				if (tab_customer_uid != ""&&query=="")
				{

					where = "uid in (select tab_address_uid from tab_relat_391" +
							" where tab_customer_uid='" + tab_customer_uid + "')";
				}
				else
				{
					where = " name like '%" + query + "%' ";
				}
			}
			else if (this.args["using_local_store"].f_str() == "sqlite")
			{
				where = " _nocase_search like '%" + query + "%' ";
			}

			kwj.f_select_tab_address(new t()
			{
				{"limit" , 20},
				{"where", where},
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
									{"uid",dr["uid"].ToString()},
									{"deleted",dr["deleted"].ToString()},
									{"name",dr["name"].ToString()}
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

		//курсон переведен на другой элемента
		override public t f_mouse_change_selected_item(t args)
		{

			f_check_pick_btn(new t()
			{
				{"item", args["item"]},
				{"btn", btn_pick}
			});

			f_check_drop(new t()
			{
				{"item", args["item"]},
				{"btn", btn_pick}
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

			Hide();

			t.f_f("f_done", args);

			return new t();
		}

		override public t f_cre_item(t args)
		{

			t item = args["item"];

			//создаем форму ввода данных нового контрагента
			//frm_cre_edit_item = new customer_info.customer_info_form(txt_query.Text);

			//показываем форму как диалог
			//frm_cre_edit_item.ShowDialog();

			//if (((customer_info.customer_info_form)frm_cre_edit_item).args["is_done"].f_bool())
			{
				//в результате деактивации текущего окна (окна поиска)
				//оно скроется так как предыдущее окно было диалогом
				//сюда мы попадем когда его закроют - данные введут
				//поэтом вновь показываем себя
				//Show();

				//selected_item = ((customer_info.customer_info_form)frm_cre_edit_item).customer;

				//t created_item = ((customer_info.customer_info_form)frm_cre_edit_item).customer;

				//this.args["selected_item"]["str1"] = this.args["selected_item"]["item"]["name"];
				//this.args["selected_item"]["str2"] = this.args["selected_item"]["item"]["phone"];

				item["uid"].f_set(Guid.NewGuid().ToString());
				item["name"].f_set(txt_query.Text);

				//добавляем созданный элемент в кэш времени выполнения
				//запрос f_find() выполниться из кеша что бы не обращаться к серверу
				this.args["new_items"].Add(new t()
				{
					{"str1", item["name"]},
					{"str2", ""},
					{"item", item}
				});


				f_find(new t()
				{
					{
						"f_done", new t_f<t,t> (delegate (t args1)
							{

								f_touch_lbx_item();

								t.f_f("f_done", this.args);

								return new t();
							})
					}
				});

				//сохраняем созданного контрагента
				kwj.f_tab_address_add_mssql(new t() { { "item", item } });
				//f_store(new t() { { "item", created_item } });

			}

			return new t();
		}

		override public t f_modify_item(t args)
		{

			t item = args["item"];

			//создаем форму ввода данных нового контрагента
			frm_cre_edit_item = new address_info_form(new t() { { "item", item["item"] } });

			//frm_cre_edit_item.TopMost = true;

			//frm_cre_edit_item.Show();

			//показываем форму как диалог
			frm_cre_edit_item.ShowDialog();

			if (((address_info_form)frm_cre_edit_item).args["is_done"].f_bool())
			{
				

				t created_item = ((address_info_form)frm_cre_edit_item).args["item"];

				//item["name"].f_set(txt_query.Text);

				lbx_items.SelectedItem = item;

				//в результате деактивации текущего окна (окна поиска)
				//оно скроется так как предыдущее окно было диалогом
				//сюда мы попадем когда его закроют - данные введут
				//поэтом вновь показываем себя
				((kibicom_mwh_frm_main)Owner).f_frm_customer_address(new t());

				//f_touch_lbx_item();

				//сохраняем созданного контрагента
				kwj.f_tab_address_modify_mssql(new t() { { "item", created_item } });

			}

			frm_cre_edit_item = null;

			return new t();

		}

		//удаление элемента
		override public t f_drop_item(t args)
		{

			t item = args["item"];
			Button btn = args["btn"].f_val<Button>();


			//удаляем элемент
			kwj.f_tab_address_drop_mssql(new t() 
			{ 
				{ "item", item["item"] },
				{ "wd_seller_guid", this.args["wd_seller_guid"]}
			});

			//вызываем проверку удаления, чтобы выключить ненужные теперь кнопки
			f_check_drop(args);

			return new t();

		}

		//восстановление элемента
		override public t f_revert_item(t args)
		{

			t item = args["item"];
			Button btn = args["btn"].f_val<Button>();


			//восстанавливаем элемент
			kwj.f_tab_address_revert_mssql(new t() 
			{ 
				{ "item", item["item"] },
				{ "wd_seller_guid", this.args["wd_seller_guid"]}
			});

			//вызываем проверку удаления, чтобы включить кнопки
			f_check_drop(args);

			return new t();

		}


		//сохранение связи между выбранный клиентом и адресом
		public t f_store_related_customer(t args)
		{
			if (!this.args["tab_customer_uid"].f_is_empty())
			{
				kwj.f_store_customer_address_relat(new t()
				{
					{"tab_customer_uid", this.args["tab_customer_uid"]},
					{"tab_address_uid", this.args["selected_item"]["item"]["uid"]}
				});
			}
			return new t();
		}

		public t f_check_pick_btn(t args)
		{
			t item = args["item"];
			Button btn = args["btn"].f_val<Button>();

			if (item["item"]["tab_pick_id"].f_is_empty())
			{
				f_btn_up(btn);
			}
			else
			{
				f_btn_push(btn);
			}

			return new t();
		}


		public t f_check_drop(t args)
		{
			t item = args["item"];
			Button btn = args["btn"].f_val<Button>();

			//если deleted пуст то показываем кнопки
			if (item["item"]["deleted"].f_is_empty())
			{
				btn_pick.Visible = true;
				btn_change.Visible = true;
				btn_drop.Visible = true;

				btn_revert.Visible = false;

			}
			else
			{
				btn_pick.Visible = false;
				btn_change.Visible = false;
				btn_drop.Visible = false;

				btn_revert.Visible = true;
			}

			return new t();
		}


		public t f_store(t args)
		{

			kwj.f_tab_customer_add_mssql(args);

			return new t();
		}

	}
}
