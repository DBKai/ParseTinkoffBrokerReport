using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section2
    {
        internal string valuta { get; set; } // Валюта
        internal DateTime? data_sovershenija { get; set; } // Дата и Время совершения
        internal DateTime? data_ispolnenija { get; set; } // Дата исполнения
        internal string operacija { get; set; } // Операция
        internal double sum_zachislenija { get; set; } // Сумма зачисления
        internal double sum_spisanija { get; set; } // Сумма списания
        internal string primechanie { get; set; } // Примечание

        internal static Section2 ReadSection(System.Data.DataRow row)
        {
            Section2 sec = new Section2();
            try
            {
                DateTime? date = Converter.ConvertToDateTime(row.ItemArray[0].ToString()); // Дата совершения
                DateTime? time = Converter.ConvertToDateTime(row.ItemArray[10].ToString()); // Время совершения
                
                if (date == null || time == null)
                {
                    sec.data_sovershenija = null;
                }
                else
                {
                    sec.data_sovershenija = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, time.Value.Second); // Дата и Время совершения    
                }
                
                sec.data_ispolnenija = Converter.ConvertToDateTime(row.ItemArray[23].ToString()); // Дата исполнения

                if (sec.data_ispolnenija == null)
                {
                    return null;
                }

                sec.operacija = row.ItemArray[36].ToString(); // Операция
                sec.sum_zachislenija = Converter.ConvertToDouble(row.ItemArray[56].ToString()); // Сумма зачисления
                sec.sum_spisanija = Converter.ConvertToDouble(row.ItemArray[69].ToString()); // Сумма списания
                sec.primechanie = row.ItemArray[85].ToString(); // Примечание
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sec;
        }

        internal class Ostatki
        {
            internal string valuta { get; set; } // Валюта
            internal double vhod_ostatok_na_nachalo { get; set; } // Входящий остаток на начало периода
            internal double ishod_ostatok_na_konec { get; set; } // Исходящий остаток на конец периода
            internal double plan_ishod_ostatok_na_konec { get; set; } // Плановый исходящий остаток на конец периода (с учетом неисполненных на дату
            internal double zadolzh_klienta_pered_brok { get; set; } // Задолженность клиента перед брокером
            internal double sum_nepokrit_ostatka { get; set; } // Сумма непокрытого остатка
            internal double vhod_ostatok_na_konec { get; set; } // Задолженность клиента перед Депозитарием (справочно)

            internal static Ostatki ReadOstatki(System.Data.DataRow row)
            {
                Ostatki ost = new Ostatki();
                try
                {
                    ost.valuta = row.ItemArray[0].ToString(); // Валюта
                    ost.vhod_ostatok_na_nachalo = Converter.ConvertToDouble(row.ItemArray[10].ToString()); // Входящий остаток на начало периода
                    ost.ishod_ostatok_na_konec = Converter.ConvertToDouble(row.ItemArray[23].ToString()); // Исходящий остаток на конец периода                    
                    ost.plan_ishod_ostatok_na_konec = Converter.ConvertToDouble(row.ItemArray[36].ToString()); // Плановый исходящий остаток на конец периода (с учетом неисполненных на дату
                    ost.zadolzh_klienta_pered_brok = Converter.ConvertToDouble(row.ItemArray[56].ToString()); // Задолженность клиента перед брокером
                    ost.sum_nepokrit_ostatka = Converter.ConvertToDouble(row.ItemArray[69].ToString()); // Сумма непокрытого остатка
                    ost.vhod_ostatok_na_konec = Converter.ConvertToDouble(row.ItemArray[85].ToString()); // Задолженность клиента перед Депозитарием (справочно)
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return ost;
            }
        }       
    }
}
