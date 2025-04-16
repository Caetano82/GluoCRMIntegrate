using System;
using System.Linq;

namespace GTIGluoCrmTefway.Service.Extensios
{
    public static class OnlyNumbers
    {
        public static string getOnlyNumbers(this string param)
        {
            if (param == null || param == "") return param;

            return new string(param.Where(char.IsDigit).ToArray());

        }

    }
}
