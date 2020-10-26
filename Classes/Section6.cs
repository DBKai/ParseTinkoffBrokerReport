using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section6
    {
        internal string kod { get; set; } // Код
        internal string rasshifrovka { get; set; } // Расшифровка

        internal static Section6 ReadSection(System.Data.DataRow row)
        {
            Section6 sec = new Section6();
            try
            {
                sec.kod = row.ItemArray[0].ToString(); // Код
                sec.rasshifrovka = row.ItemArray[23].ToString(); // Расшифровка

                if(sec.rasshifrovka == "Расшифровка")
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
