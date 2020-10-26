using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Section5
    {
        internal string kod_rezhima_torgov { get; set; } // Код режима торгов
        internal string opisanie { get; set; } // Описание

        internal static Section5 ReadSection(System.Data.DataRow row)
        {
            Section5 sec = new Section5();
            try
            {
                sec.kod_rezhima_torgov = row.ItemArray[0].ToString(); // Код режима торгов
                sec.opisanie = row.ItemArray[23].ToString(); // Описание

                if (sec.opisanie == "Описание")
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
