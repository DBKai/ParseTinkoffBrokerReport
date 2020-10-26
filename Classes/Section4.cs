using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section4
    {
        internal class Subsection1
        {
            internal string sokr_naim_aktiva { get; set; } // Сокращенное наименование актива
            internal string kod_aktiva { get; set; } // Код актива
            internal string isin { get; set; } // ISIN
            internal string nomer_gos_registracii { get; set; } // Номер гос.регистрации
            internal string naimenovanie_emitenta { get; set; } // Наименование эмитента
            internal string tip { get; set; } // Тип
            internal string nominal { get; set; } // Номинал
            internal string valuta_nominala { get; set; } // Валюта номинала          

            internal static Subsection1 ReadSection(System.Data.DataRow row)
            {
                Subsection1 sec = new Subsection1();
                try
                {
                    sec.sokr_naim_aktiva = row.ItemArray[0].ToString(); // Сокращенное наименование актива
                    sec.kod_aktiva = row.ItemArray[15].ToString(); // Код актива
                    sec.isin = row.ItemArray[26].ToString(); // ISIN
                    sec.nomer_gos_registracii = row.ItemArray[35].ToString(); // Номер гос.регистрации
                    sec.naimenovanie_emitenta = row.ItemArray[47].ToString(); // Наименование эмитента
                    sec.tip = row.ItemArray[71].ToString(); // Тип
                    sec.nominal = row.ItemArray[82].ToString(); // Номинал
                    sec.valuta_nominala = row.ItemArray[93].ToString(); // Валюта номинала   
                    
                    if (sec.isin == "ISIN" || string.IsNullOrEmpty(sec.isin))
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
            internal string naimenovanie_kontrakta { get; set; } // Наименование контракта
            internal string jod_kontrakta { get; set; } // Код контракта
            internal string naimenovanie_aktiva { get; set; } // Наименование актива
            internal string tip_kontrakta { get; set; } // Тип контракта
            internal string punkt_zeny { get; set; } // Пункт цены
            internal string valuta_punkta_zeny { get; set; } // Валюта пункта цены

            internal static Subsection3 ReadSection(System.Data.DataRow row)
            {
                Subsection3 sec = new Subsection3();
                try
                {
                    sec.naimenovanie_kontrakta = row.ItemArray[0].ToString(); // Наименование контракта
                    sec.jod_kontrakta = row.ItemArray[26].ToString(); // Код контракта
                    sec.naimenovanie_aktiva = row.ItemArray[46].ToString(); // Наименование актива
                    sec.tip_kontrakta = row.ItemArray[70].ToString(); // Тип контракта
                    sec.punkt_zeny = row.ItemArray[81].ToString(); // Пункт цены
                    sec.valuta_punkta_zeny = row.ItemArray[94].ToString(); // Валюта пункта цены

                    if(sec.naimenovanie_aktiva == "Наименование актива" || string.IsNullOrEmpty(sec.naimenovanie_aktiva))
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
    }
}
