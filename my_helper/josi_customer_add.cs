using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using fastJSON;
using System.Collections;
using System.Threading;
using System.Net;

namespace josi.store
{
    public partial class josi_customer_add : Form
    {

        private string edit_item_id = null;

        public tlist_item selected_item;

        Dictionary<string, object> json_obj;

        string cookie = "";//"kvl.1.tab_session_log.id=1320";// "kvl.1.tab_session_log.id=1320; path=/";

        //Запоминаем текущий фильтр на время редактирования записи
        string bak_fio;
        string bak_phone;
        string bak_email;
        string bak_address;


        public josi_customer_add()
        {
            InitializeComponent();
            //toolTip1.SetToolTip(lbxItems, "подробное описание");
        }

        public josi_customer_add(string cookie)
        {
            InitializeComponent();
            //toolTip1.SetToolTip(lbxItems, "подробное описание");
            this.cookie = cookie;

            //запрос может быть выполнен только от авторизованного пользователя
            f_login();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bntAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Найти")
            {
                fhttp_request();
                if (lbxItems.Items.Count == 0)
                {
                    btnAction.Text = "Создать";
                }
                return;
            }
            if (btnAction.Text == "Выбрать")
            {
                f_sel_customer();
                return;
            }
            if (btnAction.Text == "Создать")
            {
                MessageBox.Show("Клиент создан");
                f_gen_id_customer();
                fstore_customer();
                //запрос созданного пользователя и размещение в списке
                fhttp_request();

                //должен быть возвращен 1 элемент выбираем его
                if (lbxItems.Items.Count > 0)
                {
                    lbxItems.SelectedIndex = 0;
                }

                //вызываем функцию быбора контрагента
                f_sel_customer();
                return;
            }
        }

        
        private void MeasureItemHandler(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }

        private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            int i = e.Index;
            if (i < 0) return;
            

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //some code when the item is selected
                //if (i % 2 == 0)
                //{
                    //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255,204,204)), e.Bounds);
                    //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(204, 255, 204)), e.Bounds);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 102, 102)), e.Bounds);
                    //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 102, 102)), 
                    //                            e.Bounds.X,e.Bounds.Y,e.Bounds.Width, e.Bounds.Height+20);
                    //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                    //e.BackColor = Color.Aqua;
                //}
                //else
                //{
                    //e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    //e.BackColor = Color.White;
                //}
                    //Brush brush = new Brush();
                StringFormat sf = new StringFormat();
                float[] ts = { 100.0f, 150.0f, 170.0f };
                sf.SetTabStops(0.0f, ts);

                e.Graphics.DrawString(lbxItems.Items[e.Index].ToString(),
                e.Font,  Brushes.White, e.Bounds, sf);
            }
            else
            {
                //some code when the item is unselected
                if (i % 2 == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(204, 255, 204)), e.Bounds);
                    //e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(204,204, 255)), e.Bounds);
                    //e.BackColor = Color.Aqua;
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    //e.BackColor = Color.White;
                }
                e.Graphics.DrawString(lbxItems.Items[e.Index].ToString(),
                e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            }
            

            
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        

        private void josi_customer_add_Load(object sender, EventArgs e)
        {
            lbxItems.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
            lbxItems.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(MeasureItemHandler);
        }

        private void txt_fio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar = Keys.Back.)
            //{

            //}
        }

        private void txt_fio_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (edit_item_id != null) return;

            //если мы в режиме поиска и нажали пробел ентер или таб
            //выболняем поиск по набранному условию
            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                && btnAction.Text == "Найти")
            {
                bool query_success = false;
                if ((TextBox)sender == txt_address)
                {
                    //MessageBox.Show("ищем по адресу");
                    query_success=f_find_by_address();
                }
                else if ((TextBox)sender == txt_card)
                {
                    //MessageBox.Show("ищем по карте");
                    query_success=f_find_by_card();
                }
                else
                {
                    query_success=fhttp_request();
                }
                //если поиск вернул 0 совпадений
                //переходим в режим создания нового клиента
                if (lbxItems.Items.Count == 0&&query_success)
                {
                    btnAction.Text = "Создать";
                }
                return;
            }
            //есил ранее мы перешли в резим создания и теперь нажали enter
            //то создаем контрагента выбираем его для заказа и выходим
            if (e.KeyCode == Keys.Enter && btnAction.Text == "Создать")
            {
                //MessageBox.Show("Клиент создан");

                //предупреждаем пользователя о создании нового адреса
                if (!josi_msg_box.fshow("Проверьте правильность введенных данных. \r\n\r\n"+
                                        txt_fio.Text+"\r\n"+
                                        txt_phone.Text + "\r\n" + 
                                        txt_address.Text + "\r\n"+
                                        txt_email.Text + "\r\n\r\n"+
                                        "Если все верно, нажмите ОК.", "ОК", "Редактировать"))
                {
                    btnAction.Text = "Найти";
                    return;
                }

                f_gen_id_customer();
                fstore_customer();
                //запрос созданного пользователя и размещение в списке
                f_find_by_id();

                //должен быть возвращен 1 элемент выбираем его
                if(lbxItems.Items.Count>0)
                {
                    lbxItems.SelectedIndex = 0;
                }

                //вызываем функцию быбора контрагента
                f_sel_customer();
                return;
            }

            //есил ранее мы перешли в резим создания и теперь нажали enter
            //то создаем контрагента выбираем его для заказа и выходим
            if (e.KeyCode == Keys.Enter && btnAction.Text == "Выбрать")
            {
                if (lbxItems.SelectedItem != null)
                {
                    f_sel_customer();
                }
                return;
            }

            //выбираем элемент в списке при нежатии стрелки вниз
            if (e.KeyCode == Keys.Down)
            {

                txt.SelectionStart = txt.Text.Length;
                if (lbxItems.Items.Count>0&&lbxItems.SelectedIndex<lbxItems.Items.Count-1)
                {
                    lbxItems.SelectedIndex++;
                    btnAction.Text = "Выбрать";
                    return;
                }
            }

            //выбираем элемент в списке при нежатии стрелки вверх
            if (e.KeyCode == Keys.Up)
            {

                txt.SelectionStart = txt.Text.Length;
                if (lbxItems.Items.Count > 0 && lbxItems.SelectedIndex>0)
                {
                    lbxItems.SelectedIndex--;
                    btnAction.Text = "Выбрать";
                    return;
                }
            }

            //если нажата любая другая клавиша то всегда стараемся уйти в режим поиска
            btnAction.Text = "Найти";

        }

        private void txt_address_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            //btnAction.Text = "Выбрать";
        }

        private void lbxItems_Enter(object sender, EventArgs e)
        {
            btnAction.Text = "Выбрать";
        }

        private void lbxItems_Leave(object sender, EventArgs e)
        {
            
        }

        private void lbxItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (lbxItems.SelectedItem!=null && e.KeyCode == Keys.Enter)
            {
                f_sel_customer();
            }
        }

        private void txt_fio_Enter(object sender, EventArgs e)
        {
            btnAction.Text = "Найти";
        }

        private void lbxItems_Click(object sender, EventArgs e)
        {
            btnAction.Text = "Выбрать";
        }

        private void lbxItems_DoubleClick(object sender, EventArgs e)
        {
            f_sel_customer();
        }

        private void lbxItems_MouseEnter(object sender, EventArgs e)
        {
            if (lbxItems.Items.Count > 0)
            {
                lbxItems.Focus();
                if (lbxItems.SelectedItem == null)
                {
                    lbxItems.SetSelected(0, true);
                }
            }
        }

        private void lbxItems_MouseLeave(object sender, EventArgs e)
        {

        }

        private void mi_edit_Click(object sender, EventArgs e)
        {
            //берем текущие значения из выбранного элемента
            tlist_item edit_item = (tlist_item)lbxItems.SelectedItem;

            //запоминаем текущий поисковый запрос
            bak_fio=txt_fio.Text;
            bak_phone=txt_phone.Text;
            bak_email=txt_email.Text;
            
            //переносим текущие значения в поля редактирования
            edit_item_id = edit_item.id.ToString();
            txt_fio.Text = edit_item.name;
            txt_phone.Text = edit_item.phone;
            txt_email.Text = edit_item.email;
            
            //переключаем кнопки - включаем кнопки редактирования
            btnAction.Visible = false;
            btn_edit_cancel.Visible = true;
            btn_edit_save.Visible = true;

            //выключаем нередакторные поля
            label4.Enabled = false;
            label5.Enabled = false;
            txt_address.Enabled = false;
            txt_card.Enabled = false;


        }

        private void btn_edit_save_Click(object sender, EventArgs e)
        {
            //f_gen_id_customer();
            //сохраняем текущего клиента
            fstore_customer();

            //вносим изменения в локальный список
            tlist_item edit_item = (tlist_item)lbxItems.SelectedItem;

            edit_item.name=txt_fio.Text;
            edit_item.phone = txt_phone.Text;
            edit_item.email=txt_email.Text;
            lbxItems.Refresh();


            //возвращаем поисковый запрос сохраненый перед редактированием
            txt_fio.Text = bak_fio;
            txt_phone.Text = bak_phone;
            txt_email.Text = bak_email;

            //переключаем кнопки - убираем кнопки редактирования
            //включаем кнопку поиска/выбора/создания
            btnAction.Visible = true;
            btn_edit_cancel.Visible = false;
            btn_edit_save.Visible = false;
            //выключаем нередакторные поля
            label4.Enabled = true;
            label5.Enabled = true;
            txt_address.Enabled = true;
            txt_card.Enabled = true;
        }

        //отмена реадктирования клиента
        private void btn_edit_cancel_Click(object sender, EventArgs e)
        {
            //обнуляем редактируемый id
            edit_item_id = null;

            //возвращаем поисковый запрос сохраненый перед редактированием
            txt_fio.Text = bak_fio;
            txt_phone.Text = bak_phone;
            txt_email.Text = bak_email;

            //переключаем кнопки - убираем кнопки редактирования
            //включаем кнопку поиска/выбора/создания
            btnAction.Visible = true;
            btn_edit_cancel.Visible = false;
            btn_edit_save.Visible = false;
            //выключаем нередакторные поля
            label4.Enabled = true;
            label5.Enabled = true;
            txt_address.Enabled = true;
            txt_card.Enabled = true;
        }


        #region работа с базой


        private void f_sel_customer()
        {
            //MessageBox.Show("Клиент выбран");
            //запоминаем выбранного клиента
            selected_item = (tlist_item) lbxItems.SelectedItem;
            this.Hide();
            //выводим форму выбора адреса доставки
            //josi_address_form jaf = new josi_address_form(txt_address.Text);
            //jaf.ShowDialog();

            this.Close();
        }

        private void f_gen_id_customer()
        {
            string resp_str = f_get_store_data("kvl.0.f=gen_id&kvl.1.tab=tab_customer&kvl.1.id=id");
            //"&kvl.1.tab_customer.discount_calc");

            Dictionary<string, object> json_obj = (Dictionary<string, object>)JsonParser.JsonDecode(resp_str);

            MessageBox.Show(resp_str);

            edit_item_id = f_get_val_from_json_obj(json_obj, "tab_customer.id").ToString();

            MessageBox.Show(edit_item_id);

            return;
        }

        private void fstore_customer()
        {
            //текст введенный менеджером - номер карты
            string fio = txt_fio.Text;
            string phone = txt_phone.Text;
            string email = txt_email.Text;
            string address = txt_address.Text;



            /*
            string resp_str = f_get_store_data("kvl.0.f=store_data" +
                "&kvl.1.tab_customer.0.id="+edit_item_id+
                "&kvl.1.tab_customer.0.name=" + fio +
                "&kvl.1.tab_customer.0.phone=" + phone +
                "&kvl.1.tab_customer.0.email=" + email);
            */
            //kvl.1.tab_arr.tab_kibi_do_do.0.id
            string resp_str = f_get_store_data("kvl.0.f=store_put_granted" +
                "&kvl.1.tab_arr.tab_customer.0.id=" + edit_item_id +
                "&kvl.1.tab_arr.tab_customer.0.name=" + fio +
                "&kvl.1.tab_arr.tab_customer.0.phone=" + phone +
                "&kvl.1.tab_arr.tab_customer.0.email=" + email);


            return;




        }

        private string f_get_store_data(string query_str)
        {
            //включаем на время выполнения запроса прогрессбар
            progressBar1.Visible = true;

            string seller_code = "3256-83490";//Atechnology.ecad.Settings.Base.seller_code;
            string req_url;
            if (seller_code == "3256-8341")
            {
                //req_url = "http://192.168.1.39:3927/josi_deb/index9.php?" + query_str;
                req_url = "http://192.168.1.39:3927/venta_service/index.php?" + query_str;
            }
            else
            {
                //req_url = "http://85.175.5.118:3927/josi_deb/index9.php?" + query_str;
                req_url = "http://85.175.5.118:3927/venta_service/index.php?" + query_str;
            }

            //наш http запрос к серверу формируется из адреса для запросов и предаваемого запроса query_str
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(req_url);

            //MessageBox.Show(cookie);

            // передаем cookie, полученные в предыдущем запросе
            if (!String.IsNullOrEmpty(cookie))
            {
                req.Headers.Add(HttpRequestHeader.Cookie, cookie);
            }

            

            //наш http запрос к серверу формируется из адреса для запросов и предаваемого запроса query_str
            //HttpWebRequest req =
            //    (HttpWebRequest)WebRequest.Create("http://85.175.5.118:3927/josi_deb/index9.php?" + query_str);

//            req.UserAgent = "Mozila/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
            //req.Accept = "image/gif, image/x-xbitmap, image/jpeg, text/plain";// +
            //             "image/pjpeg, application/x-shockwave-flash,"+
            //             "application/vnd.ms-excel,"+
            //             "application/vnd.ms-powerpoint,"+ 
            //             "application/msword, */"+"*";

            //req.Headers.Add(HttpRequestHeader.Cookie, cookie);

            

            richTextBox1.Text = req_url;

            //return "";

            //таймаут запроса
            req.Timeout = 10000;

            //принимать любые сертификаты
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //делегат вызова функции отправки запроса на сервер и получения ответа
            hwr_delegate hwr_dlg = new hwr_delegate(f_get_response);

            //выполняем асинхронный запрос к серверу
            IAsyncResult ar = hwr_dlg.BeginInvoke(req, null, null);

            

            //пока не выполнился ассинхронный вызов обновляем форму
            while (ar.IsCompleted == false)
            {
                Thread.Sleep(100);  // pretend to so some useful work
                //MessageBox.Show("123");

                this.Refresh();
            }

            //ar.AsyncWaitHandle.WaitOne();

            HttpWebResponse response = hwr_dlg.EndInvoke(ar);

            //return;

            if (response == null)
            {
                //выключаем прогрессбар
                progressBar1.Visible = false;
                return null;
            }

            //если сервер прислал новый cookie то берем его иначе оставляем тот что хранится на текущий момент
            cookie =String.IsNullOrEmpty(response.Headers["Set-Cookie"]) ? cookie : response.Headers["Set-Cookie"];

            //MessageBox.Show(cookie);
            //richTextBox1.Text = cookie;

            Stream dataStream = response.GetResponseStream();



            StreamReader reader = new StreamReader(dataStream);

            string resp_str = reader.ReadToEnd();

            

            reader.Close();

            dataStream.Close();

            response.Close();

            //richTextBox1.Text = resp_str;

            //Dictionary<string, object> json_obj = (Dictionary<string, object>) JsonParser.JsonDecode(resp_str);

            //выключаем прогрессбар
            progressBar1.Visible = false;

            return resp_str;
        }

        private HttpWebResponse f_get_response(HttpWebRequest req)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)req.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось связаться с сервером.\n\r" +
                                "Проверьте подключение к интернету.",
                                "Ошибка связи с серевером",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return response;
        }

        private bool f_find_by_address()
        {
            //текст введенный менеджером - номер карты
            string fio = txt_fio.Text;
            string phone = txt_phone.Text;
            string email = txt_email.Text;
            string address = txt_address.Text;

            //защита от пустого поиска и очень которких слов 1-3 буквы - слышком большая выборка
            if (address.Length < 3)
            {
                return false;
            }

            string resp_str = f_get_store_data("kvl.0.f=tab_json_view_relat" +
                //"&kvl.1.tab_address.tab_order.tab_customer.id=" +
                //"&kvl.1.tab_address.tab_order.id=" +
                //"&kvl.1.tab_address.id=" +
                "&kvl.1.tab_address.tab_order.tab_customer.name=" + (fio == "" ? "" : "%" + fio + "%") +
                "&kvl.1.tab_address.tab_order.tab_customer.phone=" + (phone == "" ? "" : "%" + phone + "%") +
                "&kvl.1.tab_address.tab_order.tab_customer.email=" + (email == "" ? "" : "%" + email + "%") +
                "&kvl.1.tab_address.name=" + (address == "" ? "" : "%" + address + "%"));

            json_obj = (Dictionary<string, object>)JsonParser.JsonDecode(resp_str);

            if (resp_str == null) return false;

            //заполняем список результами запроса
            ffill_lbx();

            return true;
        }

        private bool f_find_by_card()
        {
            //текст введенный менеджером - номер карты
            string fio = txt_fio.Text;
            string phone = txt_phone.Text;
            string email = txt_email.Text;
            string address = txt_address.Text;
            string card_num = txt_card.Text.Substring(1, txt_card.Text.Length-2);
            //MessageBox.Show(card_num);

            //защита от пустого поиска и очень которких слов 1-3 буквы - слышком большая выборка
            if (card_num.Length<10)
            {
                return false;
            }

            string resp_str = f_get_store_data("kvl.0.f=tab_json_view_relat" +
                //"&kvl.1.tab_discount_card.tab_order.id=" +
                //"&kvl.1.tab_discount_card.id=" +
                //"&kvl.1.tab_discount_card.tab_order.tab_customer.id=" +
                "&kvl.1.tab_discount_card.tab_order.tab_customer.name=" + (fio == "" ? "" : "%" + fio + "%") +
                "&kvl.1.tab_discount_card.tab_order.tab_customer.phone=" + (phone == "" ? "" : "%" + phone + "%") +
                "&kvl.1.tab_discount_card.tab_order.tab_customer.email=" + (email == "" ? "" : "%" + email + "%") +
                "&kvl.1.tab_discount_card.num_char=" + card_num);

            json_obj = (Dictionary<string, object>)JsonParser.JsonDecode(resp_str);

            if (resp_str == null) return false;

            //заполняем список результами запроса
            ffill_lbx();

            return true;
        }

        private bool fhttp_request()
        {
            //текст введенный менеджером - номер карты
            string fio = txt_fio.Text;
            string phone = txt_phone.Text;
            string email = txt_email.Text;
            string address = txt_address.Text;
            string card = txt_card.Text;

            //защита от пустого поиска и очень которких слов 1-3 буквы - слышком большая выборка
            if (fio.Length < 3 && phone.Length < 3 && email.Length < 3)
            {
                return false;
            }

            string resp_str = f_get_store_data("kvl.0.f=store_get" +
                "&kvl.1.where.tab_customer.0.id=" +
                "&kvl.1.where.tab_customer.0.name=" + (fio == "" ? "" : "%" + fio + "%") +
                "&kvl.1.where.tab_customer.0.phone=" + (phone == "" ? "" : "%" + phone + "%") +
                "&kvl.1.where.tab_customer.0.email=" + (email == "" ? "" : "%" + email + "%"));
            /*
            string resp_str = f_get_store_data("kvl.0.f=tab_json_view_relat" +
                "&kvl.1.tab_customer.id=" +
                "&kvl.1.tab_customer.name=" + (fio == "" ? "" : "%" + fio + "%") +
                "&kvl.1.tab_customer.phone=" + (phone == "" ? "" : "%" + phone + "%") +
                "&kvl.1.tab_customer.email=" + (email == "" ? "" : "%" + email + "%"));// +
                //"&kvl.1.tab_customer.tab_order.tab_address.name=");
            */
            

            //return true;

            if (resp_str == null) return false ;

            //MessageBox.Show(resp_str);

            //если получено пустое множество нечего выводить в список предлагаем создать
            if (resp_str.Trim() == "[]") return true;

            json_obj = (Dictionary<string, object>)JsonParser.JsonDecode(resp_str);

            //заполняем список результами запроса
            ffill_lbx();
            //"&kvl.1.tab_customer.discount_calc");

            //return;

            return true;


        }

        private bool f_login()
        {
            if (cookie == "")
            {
                string resp_str = f_get_store_data(
                    "&kvl.0.f=login" +
                    "&kvl.1.login=dnclive" +
                    "&kvl.1.pass=135");
            }

            if (cookie == "")
            {
                josi_msg_box.fshow("Отказ в авторизации. Обратитесь к администратору!", "ОК", "Редактировать");
                return false;
            }

            //если авторизация успешна возвращаем true;
            return true;

        }

        private bool f_find_by_id()
        {

            string resp_str = f_get_store_data("kvl.0.f=store_get" +
                "&kvl.1.where.tab_customer.0.id=" +edit_item_id+
                "&kvl.1.where.tab_customer.0.name=" +
                "&kvl.1.where.tab_customer.0.phone=" +
                "&kvl.1.where.tab_customer.0.email=");
            /*
            string resp_str = f_get_store_data("kvl.0.f=tab_json_view_relat" +
                "&kvl.1.tab_customer.id=" + edit_item_id+
                "&kvl.1.tab_customer.name=" +
                "&kvl.1.tab_customer.phone=" +
                "&kvl.1.tab_customer.email=" );// +
            //"&kvl.1.tab_customer.tab_order.tab_address.name=");
            */
            if (resp_str == null) return false;

            //если получено пустое множество нечего выводить в список предлагаем создать
            if (resp_str.Trim() == "[]") return true;

            json_obj = (Dictionary<string, object>)JsonParser.JsonDecode(resp_str);

            //заполняем список результами запроса
            ffill_lbx();
            //"&kvl.1.tab_customer.discount_calc");

            //return;

            return true;


        }



        private void ffill_lbx()
        {
            //если ответ null то не удалось связаться с сервером
            if (json_obj == null)
            {
                return;
            }

            lbxItems.Items.Clear();

            //foreach (string tab in json_obj.Keys)
            //{
            string tab = "tab_customer";
            ArrayList tab_rows = (ArrayList)json_obj[tab];
            foreach (Dictionary<string, object> row in tab_rows)
            {

                string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
                string row_wd_idcustomer = row.ContainsKey("wd_idcustomer") && row["wd_idcustomer"] != null ? row["wd_idcustomer"].ToString() : "";
                string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";
                string row_phone = row.ContainsKey("phone") && row["phone"] != null ? row["phone"].ToString() : "";
                string row_email = row.ContainsKey("email") && row["email"] != null ? row["email"].ToString() : "";
                //string row_address = row.ContainsKey("address") && row["address"] != null ? row["address"].ToString() : "";

                /*
                //запоминаем id_adrress если он один в списке
                string row_tab_address_id=null;
                string row_tab_address_name = null;
                if (json_obj.ContainsKey("tab_address"))
                {
                    if (((ArrayList)json_obj["tab_address"]).Count == 1)
                    {
                        row_tab_address_id = ((Dictionary<string, object>)((ArrayList)json_obj["tab_address"])[0])
                                                ["id"].ToString();
                        row_tab_address_name = ((Dictionary<string, object>)((ArrayList)json_obj["tab_address"])[0])
                                                ["name"].ToString();
                    }
                }
                 * */
                //MessageBox.Show(((ArrayList)json_obj["tab_address"]).Count.ToString());
                //MessageBox.Show(((Dictionary<string, object>)((ArrayList)json_obj["tab_address"])[0])
                //                                ["name"].ToString());
                //MessageBox.Show(row_tab_address_name);
                //запоминаем id_adrress если он один в списке
                string row_tab_discount_cart_id = null;
                if (json_obj.ContainsKey("tab_discount_card"))
                {
                    if (((ArrayList)json_obj["tab_discount_card"]).Count == 1)
                    {
                        row_tab_discount_cart_id = ((Dictionary<string, object>)((ArrayList)json_obj["tab_discount_card"])[0])
                                ["id"].ToString();
                    }
                }
                int int_id = !int.TryParse(row_id, out int_id) ? int_id : 0;
                int int_wd_idcustomer = !int.TryParse(row_wd_idcustomer, out int_wd_idcustomer) ? int_wd_idcustomer : 0;

                lbxItems.Items.Add(new tlist_item(  row_id, 
                                                    row_wd_idcustomer, 
                                                    row_name, 
                                                    row_phone, 
                                                    row_email//,
                                                    //row_tab_address_id,
                                                    /*row_tab_address_name*/));

            }
            lbxItems.Refresh();
            //}
        }

        private delegate HttpWebResponse hwr_delegate(HttpWebRequest req);

        #endregion работа с базой

        #region json_dot_val

        private object f_get_val_from_json_obj(object json_obj, string dot_key)
        {
            //Dictionary<string, object> json_obj_dic=null;
            //ArrayList json_obj_arr=null;

            string dot_keyi = f_get_top_dot_keyi(dot_key);
            string dot_key_tail = f_get_dot_key_tail(dot_key);

            if (dot_keyi == "")
            {
                return json_obj;
            }

            int num_dot_keyi;
            if (int.TryParse(dot_keyi, out num_dot_keyi))
            {
                ArrayList json_obj_arr = (ArrayList)json_obj;



                return f_get_val_from_json_obj(json_obj_arr[num_dot_keyi], dot_key_tail);

                /*
                foreach (object json_obj_arri in json_obj_arr)
                {
                    f_get_val_from_json_obj(json_obj_arri, dot_key_tail);	
                }
                */
            }
            else
            {

                Dictionary<string, object> json_obj_dic = (Dictionary<string, object>)json_obj;

                return f_get_val_from_json_obj(json_obj_dic[dot_keyi], dot_key_tail);
            }
            return null;
        }

        private string f_get_top_dot_keyi(string dot_key)
        {
            int doti = dot_key.IndexOf('.');
            return doti < 0 ? dot_key : dot_key.Substring(0, dot_key.IndexOf('.'));
        }

        private string f_get_dot_key_tail(string dot_key)
        {
            int doti = dot_key.IndexOf('.');
            return doti < 0 ? "" : dot_key.Substring(doti + 1, dot_key.Length - doti - 1);
        }
		

        #endregion json_dot_val





        





    }
    /*
    class tlistbox_ext : ListBox
    {
        /// 
        /// Called when invalidated to find the item bounds. Since we are only concerned 
        /// with the height we only need to set this value and leave the bounds.width 
        /// as is! 
        ///
        protected void OnMeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if ((e.Index < 0) || (e.Index >= itemCache.Count))
                return;

            ExtendedListBoxItem xlbi = (ExtendedListBoxItem)itemCache[e.Index];

            //If its the current selection and not collapsed 
            // set height to Max. otherwise just set the item selected to Min. value.
            if ((e.Index == _currentIndex) && !isCollapsed)
                e.ItemHeight = xlbi.MaxSize;
            else
                e.ItemHeight = xlbi.MinSize;

            e.ItemWidth = this.Width;
        }

        ///
        /// Called when the item needs to be drawn
        ///    
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            base.OnDrawItem(e);


            //If not a valid index just ignore      
            if ((e.Index < 0) || (e.Index >= itemCache.Count))
                return;

            ExtendedListBoxItem xlbi = (ExtendedListBoxItem)itemCache[e.Index];

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            //Draw the item in current state.
            if ((e.Index == _currentIndex) && !isCollapsed)
                xlbi.DrawExpanded(e);
            else
                xlbi.DrawCollapsed(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //Invalidate previous selection 
            InvalidateItem(_previousIndex);

            //Invalidate current selection 
            InvalidateItem(_currentIndex);
        }

        /// 
        /// Invalidates the item at the provided index.
        ///
        public void InvalidateItem(int index)
        {
            if ((index < 0) || (index >= itemCache.Count))
                return;

            //All we need to do here is make sure
            //we get the correct item index.
            this.Items.RemoveAt(index);
            this.Items.Insert(index, " ");
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }
    */


    public class tlist_item
    {
        public string id;
        public string wd_idcustomer;
        public string name;
        public string phone;
        public string email;
        public string tab_address_id;
        public string tab_address_name;
        //public string text = null;
        //public string wd_name=null;

        public tlist_item(string id, string wd_idcustomer, string name, string phone, string email)
        {
            this.id = id;
            this.wd_idcustomer=wd_idcustomer;
            this.name = name;
            this.phone=phone;
            this.email = email;
            //MessageBox.Show(tab_address_name);
            //this.tab_address_id = tab_address_id;
            this.tab_address_name = tab_address_name;
            //MessageBox.Show(this.tab_address_name);
        }

        public override string ToString()
        {
            //
            return fnotvarstr(name, 50, ' ') + fnotvarstr(phone, 30, ' ') + fnotvarstr(email, 30, ' ');// +tab_address_name;
            return name + "       " + phone + "           " + email+"       "+tab_address_name;
        }

        string fnotvarstr(string str, int len, char fill)
        {
            int cnt = len - str.Length;
            string conststr = str + new string(fill, cnt<0?0:cnt);
            return conststr;
        }
    }

    public class tlive_words
    {
        public ListBox lbx;

        public tlive_words()
        {

        }



    }
}