using ParseTinkoffBrokerReport.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace ParseTinkoffBrokerReport
{
    class Program
    {
        static DataTable LoadWorksheetInDataTable(string fileName, string sheetName)
        {
            DataTable sheetData = new DataTable();
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;"))
            {
                conn.Open();
                // retrieve the data using data adapter
                OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [" + sheetName + "$]", conn);
                sheetAdapter.Fill(sheetData);
                conn.Close();
            }
            return sheetData;
        }

        static void Main(string[] args)
        {
            List<string> fileList = Directory.GetFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*.xlsx").ToList<string>();

            List<Section1.Subsection1> section1_1List = new List<Section1.Subsection1>();
            List<Section1.Subsection1> section1_2List = new List<Section1.Subsection1>();
            List<Section1.Subsection1> section1_3List = new List<Section1.Subsection1>();
            List<Section1.Subsection4> section1_4List = new List<Section1.Subsection4>();
            List<Section2> section2List = new List<Section2>();
            List<Section3.Subsection1> section3_1List = new List<Section3.Subsection1>();
            List<Section3.Subsection2> section3_2List = new List<Section3.Subsection2>();
            List<Section3.Subsection3> section3_3List = new List<Section3.Subsection3>();
            List<Section4.Subsection1> section4_1List = new List<Section4.Subsection1>();
            List<Section4.Subsection1> section4_2List = new List<Section4.Subsection1>();
            List<Section4.Subsection3> section4_3List = new List<Section4.Subsection3>();
            List<Section5> section5List = new List<Section5>();
            List<Section6> section6List = new List<Section6>();

            string[] sectionString = new string[]
            {
                "1.1 Информация о совершенных и исполненных сделках на конец отчетного периода",
                "1.2 Информация о неисполненных сделках на конец отчетного периода",
                "1.3 Сделки за расчетный период, обязательства из которых прекращены  не в результате исполнения ",
                "1.4 Информация об изменении расчетных параметров сделок РЕПО",
                "2. Операции с денежными средствами",
                "3.1 Движение по ценным бумагам инвестора",
                "3.2 Движение по производным финансовым инструментам",
                "3.3 Информация о позиционном состоянии по производным финансовым инструментам из таблицы",
                "4.1 Информация о ценных бумагах",
                "4.2 Информация об инструментах, не квалифицированных в качестве ценной бумаги",
                "4.3 Информация о производных финансовых инструментах",
                "5. Информация о торговых площадках",
                "6. Расшифровка дополнительных кодов используемых в отчете"
            };

            // читаем каждый файл из списка и проверяем наличие в БД            
            foreach (var file in fileList)
            {
                var fileInfo = new FileInfo(file);
                DataTable dt = LoadWorksheetInDataTable(fileInfo.FullName, "broker_rep");                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[0])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[1])
                        {
                            Section1.Subsection1 sec = Section1.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section1_1List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[1])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[2])
                        {
                            Section1.Subsection1 sec = Section1.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section1_2List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[2])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[3])
                        {
                            Section1.Subsection1 sec = Section1.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section1_3List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[3])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[4])
                        {
                            Section1.Subsection4 sec = Section1.Subsection4.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section1_4List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[4])
                    {
                        List<Section2.Ostatki> ostatki_List = new List<Section2.Ostatki>();

                        // Остатки по валютам
                        while (true)
                        {
                            Section2.Ostatki ost = Section2.Ostatki.ReadOstatki(dt.Rows[i]);

                            // Если такая валюта уже есть в списке
                            if (ostatki_List.Count(s => s.valuta.Equals(ost.valuta)) > 0)
                            {
                                break;
                            }
                            else
                            {
                                ostatki_List.Add(ost);
                            }

                            i = i + 1;
                        }

                        string valuta = string.Empty;

                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[5])
                        {
                            Section2 sec = Section2.ReadSection(dt.Rows[i]);

                            if (sec != null)
                            {
                                sec.valuta = valuta;
                                section2List.Add(sec);
                            }
                            else
                            {
                                // Если прочитанная строка является началом валюты
                                if (ostatki_List.Count(s => s.valuta.Equals(dt.Rows[i].ItemArray[0].ToString())) > 0)
                                {
                                    valuta = dt.Rows[i].ItemArray[0].ToString();
                                }
                            }

                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[5])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[6])
                        {
                            Section3.Subsection1 sec = Section3.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section3_1List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[6])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[7])
                        {
                            Section3.Subsection2 sec = Section3.Subsection2.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section3_2List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[7])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[8])
                        {
                            Section3.Subsection3 sec = Section3.Subsection3.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section3_3List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[8])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[9])
                        {
                            Section4.Subsection1 sec = Section4.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section4_1List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[9])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[10])
                        {
                            Section4.Subsection1 sec = Section4.Subsection1.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section4_2List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[10])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[11])
                        {
                            Section4.Subsection3 sec = Section4.Subsection3.ReadSection(dt.Rows[i]);
                            if (sec != null)
                            {
                                section4_3List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[11])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != sectionString[12])
                        {
                            Section5 sec = Section5.ReadSection(dt.Rows[i]);
                            if (sec != null && sec.kod_rezhima_torgov != sectionString[11])
                            {
                                section5List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }

                    if (dt.Rows[i].ItemArray[0].ToString() == sectionString[12])
                    {
                        while (dt.Rows[i].ItemArray[0].ToString() != "АО «Тинькофф Банк»")
                        {
                            Section6 sec = Section6.ReadSection(dt.Rows[i]);
                            if (sec != null && sec.kod != sectionString[12])
                            {
                                section6List.Add(sec);
                            }
                            i = i + 1;
                        }
                    }
                }
                dt.Dispose();
            }

            Console.WriteLine($"Записей: {section1_1List.Count}. Раздел: {sectionString[0]}");
            Console.WriteLine($"Записей: {section1_2List.Count}. Раздел: {sectionString[1]}");
            Console.WriteLine($"Записей: {section1_3List.Count}. Раздел: {sectionString[2]}");
            Console.WriteLine($"Записей: {section1_4List.Count}. Раздел: {sectionString[3]}");
            Console.WriteLine($"Записей: {section2List.Count}. Раздел: {sectionString[4]}");
            Console.WriteLine($"Записей: {section3_1List.Count}. Раздел: {sectionString[5]}");
            Console.WriteLine($"Записей: {section3_2List.Count}. Раздел: {sectionString[6]}");
            Console.WriteLine($"Записей: {section3_3List.Count}. Раздел: {sectionString[7]}");
            Console.WriteLine($"Записей: {section4_1List.Count}. Раздел: {sectionString[8]}");
            Console.WriteLine($"Записей: {section4_2List.Count}. Раздел: {sectionString[9]}");
            Console.WriteLine($"Записей: {section4_3List.Count}. Раздел: {sectionString[10]}");
            Console.WriteLine($"Записей: {section5List.Count}. Раздел: {sectionString[11]}");
            Console.WriteLine($"Записей: {section6List.Count}. Раздел: {sectionString[12]}");
            Console.WriteLine("All data read");
            Console.ReadKey();
        }
    }
}
