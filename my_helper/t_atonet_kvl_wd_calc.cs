using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

using kibicom;
using kibicom.tlib;
using kibicom.atonet_fast;
using kibicom.wd;

using Atechnology.DBConnections2;

namespace kibicom.my_wd_helper
{
	class t_atonet_kvl_wd_calc:t
	{
		delegate void t_d_f_calc(torder order);

		public t f_init_out(t args)
		{
			//dbconn.Init("MultipleActiveResultSets=True;database=ecad_venta;server=192.168.1.201;Connection Timeout = 10;uid=sa;Password=82757662=z");
			//dbconn.Init("MultipleActiveResultSets=True;database=ecad_venta;server=localhost\\sqlexpress;Connection Timeout = 10;uid=sa;Password=82757662=z");
			
			//dbconn.Init("MultipleActiveResultSets=True;database=ecad_etalon;server=192.168.1.201;Connection Timeout = 10;uid=sa;Password=82757662=z");
			
			dbconn._db = new dbconn();

			this["ds"].f_set(new DataSet());

			return this;
		}

		public t f_init(t args)
		{

			DataRow o_dr = args["o_dr"].f_val<DataRow>();

			this["ds"] = args["ds"];
			this["dbconn"] = args["dbconn"];

			//если это внешний расчет
			//инициализируем подключение к базе
			if (args["is_out_calc"].f_bool())
			{
				f_init_out(args);
			}



			//если строка заказа не передана
			if (o_dr == null&&1==0)
			{
				//строка заказа
				DataTable tab_order = f_tab_order(new t()
				{
					{"tab_name", "orders"},
					{"idorder", "4671"}
					//{"idorder", "97785"}
					//{"idorder","95740"}
					//{"idorder","96785"}

				})["orders"].f_val<DataTable>();

				if (tab_order.Rows.Count > 0)
				{
					o_dr = tab_order.Rows[0];
				}
			}

			//если сеть еще не загружена загружаем ее
			if (this["calc_atonet"].f_val() == null&&1==0)
			{
				DataSet ds = args["ds"].f_def(this["ds"].f_val<DataSet>()).f_val<DataSet>();
				this["ds"].f_set(ds);

				atonet_fast.tatonet good_calc_atonet = new atonet_fast.tatonet();

				//расчет изделий nerocalc
				torder order = new torder(dbconn._db, o_dr);//, pb);

				//загружаем kvl конфигурацию матераилов в сеть
				order.f_inject_good_kvl_conf(new t()
				{
					{"atonet",good_calc_atonet},
					{"ds",ds},
				});

				this["calc_atonet"].f_set(good_calc_atonet);
			}

			return this;
		}

		public t f_calc_order(t args)
		{
			//t_wd wd = new t_wd();

			//инициализация соединения с базой
			//wd.f_init(args);


			//строка заказа
			DataTable tab_order = f_tab_order(new t()
			{
				{"tab_name", "orders"},
				{"idorder", "4671"}
				//{"idorder", "97785"}
				//{"idorder","95740"}
				//{"idorder","96785"}

			})["orders"].f_val<DataTable>();

			/*
			//загрузка моделей
			DataTable tab_model = wd.f_tab_model(new t()
			{
				//{"idorder","20"},
				{"idorder","95740"},
				//{"idorder","96785"},
				{"idorderitem",""},
				{"idmodel",""}

			})["tab_model"].f_val<DataTable>();
			*/
			//расчитываем заказ
			f_calc_order_atonet_fast_kvl(new t()
			{
				{"o_dr", tab_order.Rows[0]},
				{"idorderitem","0"},
				{"idmodel","0"}
			});

			return new t();
		}

		public t f_tab_order(t args)
		{
			DataSet ds = this["ds"].f_val<DataSet>();
			string idorder = args["idorder"].f_str();
			string tab_name = args["tab_name"].f_def("orders").f_str();

			if (ds.Tables.Contains(tab_name))
			{
				//DataRow ds.Tables[tab_name].Select(" deleted is null and idorder=" + idorder);

				MessageBox.Show("ds contain table orders");

				return new t() { { tab_name, ds.Tables[tab_name] } };
			}

			//return new t();

			DataTable tab = new DataTable(tab_name);

			dbconn._db.OpenDB();

			if (idorder != "")
			{
				dbconn._db.command.CommandText = "select * from orders where deleted is null and idorder=" + idorder;
			}

			if (idorder == "")
			{
				dbconn._db.CloseDB();
				return new t() { { "tab_order", tab } };
			}

			dbconn._db.adapter.Fill(tab);

			if (!ds.Tables.Contains(tab_name))
			{
				ds.Tables.Add(tab);
			}

			dbconn._db.CloseDB();

			return new t() { { tab_name, tab } };
		}

		public t f_calc_order_atonet_fast_kvl(t args)
		{
			DataSet ds = this["ds"].f_val<DataSet>();
			DataRow o_dr = args["o_dr"].f_val<DataRow>();
			//DataGrid dg_ds = args["dg_ds"].f_def(new DataGrid()).f_val<DataGrid>();

			/*
			foreach (DataColumn c in o_dr.Table.Columns)
			{
				MessageBox.Show(c.ColumnName + " " + o_dr[c.ColumnName]);
			}
			*/
			//расчет изделий nerocalc
			torder order = new torder(dbconn._db, o_dr, true);//, pb);

			t_d_f_calc d_f_calc = new t_d_f_calc(delegate(torder ord)
			{
				ord.f_calc_atonet_fast_33_99(new t() { { "clear_mc", true } });
			});

			d_f_calc.BeginInvoke(order, new AsyncCallback(delegate(IAsyncResult ar)
			{
				 MessageBox.Show(ds.Tables["modelcalc"].Rows.Count.ToString());

				AsyncResult result = (AsyncResult)ar;
				//t_f<t, t> caller = (t_f<t, t>)result.AsyncDelegate;

				/*
				if (dg_ds.InvokeRequired)
				{
					dg_ds.Invoke(new t_f<t, t>(delegate(t args_1)
					{
						dg_ds.DataSource = order.args.ds;

						return new t();
					}), new object[] { new t() });
				}
				
				dg_ds.DataSource = order.args.ds;
				*/
				// Retrieve the format string that was passed as state 
				// information.
				//t args = (t)ar.AsyncState;
				MessageBox.Show("f_calc_done");


			}), null);

			return new t();
		}
	
	}
}
