using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section3
    {
        internal class Subsection1
        {
            internal string sokr_naim_aktiva { get; set; } // Сокращенное наименование актива
            internal string kod_aktiva { get; set; } // Код актива
            internal string mesto_hranenija { get; set; } // Место хранения
            internal int vhod_ostatok { get; set; } // Входящий остаток
            internal int zachislenie { get; set; } // Зачисление
            internal int spisanie { get; set; } // Списание
            internal int ishod_ostatok { get; set; } // Исходящий остаток
            internal int plan_ishod_ostatok { get; set; } // Плановый исходящий остаток
            internal double rynochnaja_zena { get; set; } // Рыночная цена
            internal string valuta_zeni { get; set; } // Валюта цены
            internal double nkd { get; set; } // НКД
            internal double rynochnaja_stoimost { get; set; } // Рыночная стоимость
            internal static Subsection1 ReadSection(System.Data.DataRow row)
            {
                Subsection1 sec = new Subsection1();
                try
                {
                    sec.sokr_naim_aktiva = row.ItemArray[0].ToString(); // Сокращенное наименование актива
                    sec.kod_aktiva = row.ItemArray[11].ToString(); // Код актива
                    sec.mesto_hranenija = row.ItemArray[17].ToString(); // Место хранения
                    sec.vhod_ostatok = Converter.ConvertToInt32(row.ItemArray[31].ToString()); // Входящий остаток
                    sec.zachislenie = Converter.ConvertToInt32(row.ItemArray[39].ToString()); // Зачисление
                    sec.spisanie = Converter.ConvertToInt32(row.ItemArray[48].ToString()); // Списание  
                    sec.ishod_ostatok = Converter.ConvertToInt32(row.ItemArray[57].ToString()); // Исходящий остаток
                    sec.plan_ishod_ostatok = Converter.ConvertToInt32(row.ItemArray[64].ToString()); // Плановый исходящий остаток
                    sec.rynochnaja_zena = Converter.ConvertToDouble(row.ItemArray[74].ToString()); // Рыночная цена
                    sec.valuta_zeni = row.ItemArray[79].ToString(); // Валюта цены
                    sec.nkd = Converter.ConvertToDouble(row.ItemArray[88].ToString()); // НКД
                    sec.rynochnaja_stoimost = Converter.ConvertToDouble(row.ItemArray[97].ToString()); // Рыночная стоимость

                    if (sec.zachislenie == 0 && sec.spisanie == 0)
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return sec;
            }
        }

        internal class Subsection2
        {
            internal string naimenovanie_kontrakta { get; set; } // Наименование контракта
            internal string kod_kontrakta { get; set; } // Код контракта
            internal string naimenovanie_aktiva { get; set; } // Наименование актива
            internal string vhod_ostatok { get; set; } // Входящий остаток
            internal int zachislenie { get; set; } // Зачисление
            internal int spisanie { get; set; } // Списание
            internal string ishod_ostatok { get; set; } // Исходящий остаток
            internal string plan_ishod_ostatok { get; set; } // Плановый исходящий остаток

            internal static Subsection2 ReadSection(System.Data.DataRow row)
            {
                Subsection2 sec = new Subsection2();
                try
                {
                    sec.naimenovanie_kontrakta = row.ItemArray[0].ToString(); // Наименование контракта
                    sec.kod_kontrakta = row.ItemArray[16].ToString(); // Код контракта
                    sec.naimenovanie_aktiva = row.ItemArray[28].ToString(); // Наименование актива
                    sec.vhod_ostatok = row.ItemArray[42].ToString(); // Входящий остаток
                    sec.zachislenie = Converter.ConvertToInt32(row.ItemArray[59].ToString()); // Зачисление
                    sec.spisanie = Converter.ConvertToInt32(row.ItemArray[66].ToString()); // Списание
                    sec.ishod_ostatok = row.ItemArray[77].ToString(); // Исходящий остаток
                    sec.plan_ishod_ostatok = row.ItemArray[92].ToString(); // Плановый исходящий остаток
                    
                    if (sec.zachislenie == 0 && sec.spisanie == 0)
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return sec;
            }
        }

        internal class Subsection3
        {
            internal string data_rascheta { get; set; } // Дата расчета
            internal string naimenovanie_kontrakta { get; set; } // Наименование контракта
            internal string kod_kontrakta { get; set; } // Код контракта
            internal string pos_na_nachalo_dnja { get; set; } // Позиция на начало дня
            internal string pos_na_konec_dnja { get; set; } // Позиция на конец дня
            internal string var_marzha_na_nachalo_dnya { get; set; } // Вар.маржа на начало дня
            internal string var_marzha_na_konec_dnya { get; set; } // Вар маржа на конец дня
            internal string garant_obespechenie { get; set; } // Гарантийное обеспечение

            internal static Subsection3 ReadSection(System.Data.DataRow row)
            {
                Subsection3 sec = new Subsection3();
                try
                {
                    sec.data_rascheta = row.ItemArray[0].ToString(); // Дата расчета
                    sec.naimenovanie_kontrakta = row.ItemArray[6].ToString(); // Наименование контракта
                    sec.kod_kontrakta = row.ItemArray[21].ToString(); // Код контракта
                    sec.pos_na_nachalo_dnja = row.ItemArray[34].ToString(); // Позиция на начало дня
                    sec.pos_na_konec_dnja = row.ItemArray[49].ToString(); // Позиция на конец дня
                    sec.var_marzha_na_nachalo_dnya = row.ItemArray[63].ToString(); // Вар.маржа на начало дня
                    sec.var_marzha_na_konec_dnya = row.ItemArray[76].ToString(); // Вар маржа на конец дня
                    sec.garant_obespechenie = row.ItemArray[91].ToString(); // Гарантийное обеспечение

                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return sec;
            }
        }
    }    
}
