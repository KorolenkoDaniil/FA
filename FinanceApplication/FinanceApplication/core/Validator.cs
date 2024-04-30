using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FinanceApp.classes
{
    internal static class Validator
    {
        public static bool ValidateString(string value, int max_size)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length > max_size) return false;

            return true;
        }

        public static bool ValidateIdAndIntegers(int value)
        {
            if (value < 0) return false;
            return true;
        }

        public static bool ValidateSum(decimal value)
        {
            if (value < 0) return false;
            return true;
        }
    }
}
