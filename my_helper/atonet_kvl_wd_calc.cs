using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using kibicom;
using kibicom.tlib;
using kibicom.atonet_fast;
using kibicom.wd;

using Atechnology.DBConnections2;

namespace kibicom.my_wd_helper
{
	class atonet_kvl_wd_calc:t
	{
		DataSet ds;

		public t f_calc_order(t args)
		{
			t_wd wd = new t_wd();

			//инициализация соединения с базой
			wd.f_init(args);

			//строка заказа
			DataTable tab_order = wd.f_tab_order(new t()
			{
				{"idorder", "97785"}
				//{"idorder","95740"}
				//{"idorder","96785"}

			})["tab_order"].f_val<DataTable>();

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
			wd.f_calc_order_atonet_fast_kvl(new t()
			{
				{"o_dr", tab_order.Rows[0]},
				{"idorderitem","0"},
				{"idmodel","0"}
			});

			return new t();
		}

		public t f_tab_order(t args)
		{
			string idorder = args["idorder"].f_str();
			string tab_name = args["tab_name"].f_def("tab").f_str();

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

			ds.Tables.Add(tab);

			dbconn._db.CloseDB();

			return new t() { { "tab_order", tab } };
		}

	
	}
}
