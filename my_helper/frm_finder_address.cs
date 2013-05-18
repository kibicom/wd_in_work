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
		override public t f_get_items(t args)
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

						if (lbx_items.InvokeRequired)
						{
							lbx_items.Invoke(new t_f<t,t>(ffill_lbx_items), new object[] {args1});
						}

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",true},
			});

			return new t();
		}

		//заполняем список результатами запроса
		override public t ffill_lbx_items(t args)
		{

			pb_loading_2.Hide();

			//если ответ null то не удалось связаться с сервером
			//или если результаты показывать не нужно
			if (args["resp_json"].f_val() == null || !show_result)
			{
				return null;
			}

			richTextBox1.Text = args["query_str"].f_str() + "\r\n";

			richTextBox1.Text += args["resp_str"].f_str();


			//очищаем список
			lbx_items.Items.Clear();

			//foreach (string tab in json_obj.Keys)
			//{
			string tab = "tab_address";
			ArrayList tab_rows = (ArrayList)args["resp_json"].f_val<Dictionary<string, object>>()[tab];

			//если количество возвращенных результатов 0
			//то предлагаем создать нового контрагента
			if (tab_rows.Count == 0)
			{
				f_add_new();
			}

			//int lbx_items_selected_index==

			foreach (Dictionary<string, object> row in tab_rows)
			{
				//string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";

				string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
				//string row_wd_idcustomer = row.ContainsKey("wd_idcustomer") && row["wd_idcustomer"] != null ? row["wd_idcustomer"].ToString() : "";
				string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";
				//string row_phone = row.ContainsKey("phone") && row["phone"] != null ? row["phone"].ToString() : "";
				//string row_email = row.ContainsKey("email") && row["email"] != null ? row["email"].ToString() : "";
				//string row_address = row.ContainsKey("address") && row["address"] != null ? row["address"].ToString() : "";


				//int int_wd_idcustomer = !int.TryParse(row_wd_idcustomer, out int_wd_idcustomer) ? int_wd_idcustomer : 0;


				lbx_items.Items.Add(new t()
				{
					{"id",row_id},
					//{"wd_idcustomer",row_wd_idcustomer},
					{"name",row_name},
					//{"phone",row_phone},
					//{"email",row_email}//,
					//row_tab_address_id,
					/*row_tab_address_name*/
				});

				/*
				lbx_items.Items.Add(new t_customer(row_id,
									row_wd_idcustomer,
									row_name,
									row_phone,
									row_email//,
					//row_tab_address_id,
					/*row_tab_address_name));*/

			}
			lbx_items.SelectedIndex = 0;
			//lbx_items.Refresh();
			//}
			return null;
		}

		//если результ запроса пуст, предлагаем создать новый элемент ресурса
		override public void f_add_new()
		{
			try
			{
				tab["id"] = new t(30);
				//MessageBox.Show(tab_customer["id"].f_str());

				lbx_items.Items.Add(new t()
				{
					{"name","Добавить нового клиента"},
					{"phone",txt_query.Text},
				});

				/*
                lbx_items.Items.Add(new t_customer
                ("",
                    "",
                    "Добавить нового клиента",
                    txt_query.Text,
                    ""
                ));*/
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		//сохранение созданного клиента в josi_store
		override public void fstore_customer()
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
														"&kvl.1.tab_arr.tab_customer.0.name=" + selected_item["name"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.phone=" + selected_item["phone"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.email=" + selected_item["email"].f_str();


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

		//выбор отмеченного контрагента
		override public t f_select_item()
		{
			if (((t)lbx_items.SelectedItem)["name"].f_str() == "Добавить нового клиента")
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

					selected_item = ((customer_info.customer_info_form)frm_cre_edit_item).customer;

					lbx_items.Items.Clear();

					lbx_items.Items.Add(selected_item);

					lbx_items.SelectedIndex = 0;

					fstore_customer();

					args["address"].f_set(selected_item);

					t.f_f("f_done", args);

					Hide();


				}

			}
			else
			{
				selected_item = (t)lbx_items.SelectedItem;

				args["address"] = selected_item;

				t.f_f("f_done", args);

				Hide();

			}




			return new t();
		}
	}
}
