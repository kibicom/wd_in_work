wd_in_work
==========

модуль передачи в работу для менеджера


## Сниппет получения номера

```csharp

t_wd_josi_num wd_josi_num = new t_wd_josi_num();
  		wd_josi_num.f_get_num(new t()
			{
				{
					"f_done",new t_f<t,t>(delegate(t args1)
					{
						//если необходима синхронизация потоков
						if (txt_num.InvokeRequired)
						{
							txt_num.Invoke(new t_f<t,t>(delegate(t args2)
							{

								//если ответ null то не удалось связаться с сервером
								//или если результаты показывать не нужно
								if (args2["resp_json"].f_val() == null)
								{
									return null;
								}

								string order_full_num = t_dot.f_get_val_from_json_obj
									(args1["resp_json"].f_val(), "order_full_num").ToString();

								txt_num.Text = order_full_num;

								return new t();
							}), 
							new object[] {args1});
						}

						return null;
					})
				}
			});

```
```php
//генерирует номер для заказа windraw Вента
function tservice_wd_f_get_order_num($args)
{
  
	pj_deb_flog3(__LINE__, __FILE__, $args, "tservice_wd");
	$kvl_1_mix=$args["kvl_1_mix"];
	$wd_idseller=$kvl_1_mix["wd_idseller"];
	$data_from=$kvl_1_mix["date_from"];
	$data_to=$kvl_1_mix["date_to"];
	
	//текущий суффикс MMyy
	$current_suffix=date("m").date("y");
	
	pj_deb_flog3(__LINE__, __FILE__, $current_suffix, "tservice_wd");
	
	//запрашиваем текущее значение счетчика для текущего индекса
	$tab_arr_data=tstore_fstore_get(Array
	(
		"where"=>Array
		(
			"tab_wd_order_num"=>Array
			(
				Array
				(
					"id"=>"",
					"kvl"=>"key:order_num&suffix:$current_suffix",
					"num"=>"",
				),
			),
		),
	));
	
	$tab_wd_order_num=$tab_arr_data["tab_wd_order_num"];
	
	//получаем следующий индекс для текущего суффикса
	//если индекса нет, выборка была пустой, например если начался новый месяц
	//то по умолчанию мы берем 0 и индексируем его, те получаем 1
	$curr_num=tuti_f_def($tab_wd_order_num[0]["num"],0)+1;
	
	$curr_full_num="$curr_num-$current_suffix";
	
	pj_deb_flog3(__LINE__, __FILE__, $tab_wd_order_num, "tservice_wd");
	
	pj_deb_flog3(__LINE__, __FILE__, $curr_full_num, "tservice_wd");
	
	//записываем сгенерированный номер и счетчик
	//в случае если индекса еще не было строка создасться новая
	//поскольку $tab_wd_order_num[0]["id"] будет null
	tstore_relat_fput_relat_struct_rows(Array
	(
		"tab_arr"=>Array
		(
			"tab_wd_order_num_log"=>Array
			(
				Array
				(
					"id"=>"",
					"num"=>$curr_full_num,
					"wd_idseller"=>$wd_idseller,
					"dt"=>date("U"),
					"tab_wd_order_num"=>Array
					(
						Array
						(
							"id"=>tuti_f_def($tab_wd_order_num[0]["id"],""),
							"kvl"=>"key:order_num&suffix:$current_suffix",
							"num"=>$curr_num,
						)
					)
				),
			),
		),
	));
	
	pj_deb_flog3(__LINE__, __FILE__, $zamer_item, "tservice_wd");
	
	//отдаем клиенту
	$GLOBALS["content"]=json_encode(array
	(
		"order_num"=>$curr_num,
		"order_full_num"=>$curr_full_num,
	));
	
	pj_deb_flog3(__LINE__, __FILE__, $by_dt_cnt_arr,"tservice_wd");
	
	return;
}
```
