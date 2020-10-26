using System;

namespace ParseTinkoffBrokerReport.Classes
{
    internal class Converter
    {
        internal static DateTime? ConvertToDateTime(string dateTimeString)
        {
            DateTime? dtResult = null;
            try
            {
                if (!string.IsNullOrEmpty(dateTimeString) && char.IsDigit(dateTimeString.Trim()[0]))
                {
                    dtResult = Convert.ToDateTime(dateTimeString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + $" Переданное значение: '{dateTimeString}'");
            }
            return dtResult;
        }

        internal static Int32 ConvertToInt32(string int32String)
        {
            Int32 intResult = 0;
            try
            {
                if (!string.IsNullOrEmpty(int32String.Trim()) && char.IsDigit(int32String.Trim()[0]))
                {
                    intResult = Convert.ToInt32(int32String);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return intResult;
        }

        internal static Double ConvertToDouble(string doubleString)
        {
            Double doubleResult = 0;
            try
            {
                if (!string.IsNullOrEmpty(doubleString.Trim()) && char.IsDigit(doubleString.Trim()[0]))
                {
                    doubleResult = Convert.ToDouble(doubleString.Replace(".", ","));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return doubleResult;
        }
    }
}
