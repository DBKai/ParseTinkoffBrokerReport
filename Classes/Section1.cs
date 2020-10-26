using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section1
    {
        internal class Subsection1
        {
            internal string n_sdelki { get; set; } // Номер сделки
            internal string n_poruchenija { get; set; } // Номер поручения
            internal DateTime data_zakluchenija { get; set; } // Дата и Время заключения
            internal string torg_ploshadka { get; set; } // Торговая площадка
            internal string rezhim_torgov { get; set; } // Режим торгов
            internal string vid_sdelki { get; set; } // Вид сделки
            internal string sokr_naim_aktiva { get; set; } // Сокращенное наименование актива
            internal string kod_aktiva { get; set; } // Код актива
            internal double zena_za_ed { get; set; } // Цена за единицу
            internal string valuta_zeni { get; set; } // Валюта цены
            internal int kolichestvo { get; set; } // Количество
            internal double sum_bez_nkd { get; set; } // Сумма (без НКД)
            internal double nkd { get; set; } // НКД
            internal double sum_sdelki { get; set; } // Сумма сделки
            internal string valuta_raschetov { get; set; } // Валюта расчетов
            internal double komissija_brokera { get; set; } // Комиссия брокера
            internal string valuta_komissii { get; set; } // Валюта комиссии
            internal double komissia_birji { get; set; } // Комиссия биржи
            internal string valuta_komissii_birji { get; set; } // Валюта комиссии биржи
            internal double komissia_klir_centra { get; set; } // Комиссия клир. центра
            internal string valuta_komissii_klir_centra { get; set; } // Валюта комиссии клир. центра
            internal int stavka_repo { get; set; } // Ставка РЕПО(%)
            internal string kontragent { get; set; } // Контрагент
            internal DateTime? data_raschetov { get; set; } // Дата расчетов
            internal DateTime? data_postavki { get; set; } // Дата поставки
            internal string status_brokera { get; set; } // Статус брокера
            internal string tip_dogovora { get; set; } // Тип дог.
            internal string n_dogovora { get; set; } // Номер дог.
            internal DateTime? data_dogovora { get; set; } // Дата дог.

            internal static Subsection1 ReadSection(System.Data.DataRow row)
            {
                Subsection1 sec = new Subsection1();
                try
                {
                    if (row.ItemArray.Length < 103)
                    {
                        return null;
                    }

                    sec.n_sdelki = row.ItemArray[0].ToString(); // Номер сделки
                    sec.n_poruchenija = row.ItemArray[2].ToString();   // Номер поручения

                    DateTime? date = Converter.ConvertToDateTime(row.ItemArray[4].ToString());   // Дата заключения
                    DateTime? time = Converter.ConvertToDateTime(row.ItemArray[9].ToString());   // Время

                    if (date == null || time == null)
                    {
                        return null;
                    }
                    
                    sec.data_zakluchenija = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, time.Value.Second);

                    sec.torg_ploshadka = row.ItemArray[13].ToString();   // Торговая площадка
                    sec.rezhim_torgov = row.ItemArray[18].ToString();   // Режим торгов
                    sec.vid_sdelki = row.ItemArray[20].ToString();   // Вид сделки
                    sec.sokr_naim_aktiva = row.ItemArray[24].ToString();   // Сокращенное наименование актива
                    sec.kod_aktiva = row.ItemArray[29].ToString();  // Код актива

                    sec.zena_za_ed = Converter.ConvertToDouble(row.ItemArray[33].ToString()); // Цена за единицу
                    sec.valuta_zeni = row.ItemArray[38].ToString(); // Валюта цены
                    sec.kolichestvo = Converter.ConvertToInt32(row.ItemArray[41].ToString()); // Количество
                    sec.sum_bez_nkd = Converter.ConvertToDouble(row.ItemArray[43].ToString()); // Сумма (без НКД)
                    sec.nkd = Converter.ConvertToDouble(row.ItemArray[50].ToString()); // НКД
                    sec.sum_sdelki = Converter.ConvertToDouble(row.ItemArray[54].ToString()); // Сумма сделки
                    sec.valuta_raschetov = row.ItemArray[58].ToString(); // Валюта расчетов
                    sec.komissija_brokera = Converter.ConvertToDouble(row.ItemArray[61].ToString()); // Комиссия брокера
                    sec.valuta_komissii = row.ItemArray[65].ToString(); // Валюта комиссии
                    sec.komissia_birji = Converter.ConvertToDouble(row.ItemArray[68].ToString()); // Комиссия биржи
                    sec.valuta_komissii_birji = row.ItemArray[72].ToString(); // Валюта комиссии биржи
                    sec.komissia_klir_centra = Converter.ConvertToDouble(row.ItemArray[75].ToString()); // Комиссия клир. центра
                    sec.valuta_komissii_klir_centra = row.ItemArray[76].ToString(); // Валюта комиссии клир. центра
                    sec.stavka_repo = Converter.ConvertToInt32(row.ItemArray[80].ToString()); // Ставка РЕПО(%)
                    sec.kontragent = row.ItemArray[84].ToString(); // Контрагент
                    sec.data_raschetov = Converter.ConvertToDateTime(row.ItemArray[86].ToString()); // Дата расчетов
                    sec.data_postavki = Converter.ConvertToDateTime(row.ItemArray[89].ToString()); // Дата поставки
                    sec.status_brokera = row.ItemArray[95].ToString(); // Статус брокера
                    sec.tip_dogovora = row.ItemArray[98].ToString(); // Тип дог.
                    sec.n_dogovora = row.ItemArray[101].ToString(); // Номер дог.
                    sec.data_dogovora = Converter.ConvertToDateTime(row.ItemArray[103].ToString()); // Дата дог.
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return sec;
            }
        }

        internal class Subsection4
        {
            internal string n_sdelki { get; set; } // Номер сделки
            internal string n_poruchenija { get; set; } // Номер поручения
            internal DateTime data_zakluchenija { get; set; } // Дата и Время заключения
            internal string torg_ploshadka { get; set; } // Торговая площадка
            internal DateTime? data_izmenenija_uslovij { get; set; } // Дата изменений условий
            internal string vid_sdelki { get; set; } // Вид сделки
            internal string sokr_naim_aktiva { get; set; } // Сокращенное наименование актива
            internal string kod_aktiva { get; set; } // Код актива
            internal double zena_za_ed { get; set; } // Цена за единицу до после
            internal string valuta_zeni { get; set; } // Валюта цены до после
            internal int kolichestvo { get; set; } // Количество до после
            internal double sum_bez_nkd { get; set; } // Сумма (без НКД) до после
            internal double nkd { get; set; } // НКД до после
            internal double sum_sdelki { get; set; } // Сумма сделки до после
            internal string valuta_raschetov { get; set; } // Валюта расчетов
            internal double komissija_brokera { get; set; } // Комиссия брокера
            internal string valuta_komissii { get; set; } // Валюта комиссии
            internal int stavka_repo { get; set; } // Ставка РЕПО(%)
            internal string kontragent { get; set; } // Контрагент
            internal DateTime? data_raschetov { get; set; } // Дата расчетов
            internal DateTime? data_postavki { get; set; } // Дата поставки
            internal string status_brokera { get; set; } // Статус брокера
            internal string tip_dogovora { get; set; } // Тип дог.
            internal string n_dogovora { get; set; } // Номер дог.
            internal DateTime? data_dogovora { get; set; } // Дата дог.

            internal static Subsection4 ReadSection(System.Data.DataRow row)
            {
                Subsection4 sec = new Subsection4();
                try
                {
                    if (row.ItemArray.Length < 103)
                    {
                        return null;
                    }

                    sec.n_sdelki = row.ItemArray[0].ToString(); // Номер сделки
                    sec.n_poruchenija = row.ItemArray[1].ToString();   // Номер поручения

                    DateTime? date = Converter.ConvertToDateTime(row.ItemArray[3].ToString());   // Дата заключения
                    DateTime? time = Converter.ConvertToDateTime(row.ItemArray[5].ToString());   // Время

                    if (date == null || time == null)
                    {
                        return null;
                    }

                    sec.data_zakluchenija = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, time.Value.Second);

                    sec.torg_ploshadka = row.ItemArray[8].ToString();   // Торговая площадка
                    sec.data_izmenenija_uslovij = Converter.ConvertToDateTime(row.ItemArray[14].ToString()); // Дата изменений условий
                    sec.vid_sdelki = row.ItemArray[19].ToString();   // Вид сделки
                    sec.sokr_naim_aktiva = row.ItemArray[22].ToString();   // Сокращенное наименование актива
                    sec.kod_aktiva = row.ItemArray[27].ToString();  // Код актива
                    sec.zena_za_ed = Converter.ConvertToDouble(row.ItemArray[30].ToString()); // Цена за единицу
                    sec.valuta_zeni = row.ItemArray[32].ToString(); // Валюта цены
                    sec.kolichestvo = Converter.ConvertToInt32(row.ItemArray[37].ToString()); // Количество
                    sec.sum_bez_nkd = Converter.ConvertToDouble(row.ItemArray[40].ToString()); // Сумма (без НКД)
                    sec.nkd = Converter.ConvertToDouble(row.ItemArray[44].ToString()); // НКД
                    sec.sum_sdelki = Converter.ConvertToDouble(row.ItemArray[51].ToString()); // Сумма сделки
                    sec.valuta_raschetov = row.ItemArray[55].ToString(); // Валюта расчетов
                    sec.komissija_brokera = Converter.ConvertToDouble(row.ItemArray[60].ToString()); // Комиссия брокера
                    sec.valuta_komissii = row.ItemArray[62].ToString(); // Валюта комиссии                
                    sec.stavka_repo = Converter.ConvertToInt32(row.ItemArray[67].ToString()); // Ставка РЕПО(%)
                    sec.kontragent = row.ItemArray[73].ToString(); // Контрагент
                    sec.data_raschetov = Converter.ConvertToDateTime(row.ItemArray[78].ToString()); // Дата расчетов
                    sec.data_postavki = Converter.ConvertToDateTime(row.ItemArray[83].ToString()); // Дата поставки
                    sec.status_brokera = row.ItemArray[87].ToString(); // Статус брокера
                    sec.tip_dogovora = row.ItemArray[90].ToString(); // Тип дог.
                    sec.n_dogovora = row.ItemArray[96].ToString(); // Номер дог.
                    sec.data_dogovora = Converter.ConvertToDateTime(row.ItemArray[101].ToString()); // Дата дог.
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
