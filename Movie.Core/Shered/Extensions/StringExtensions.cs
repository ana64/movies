using System;

namespace Movie.Core.Shered.Extensions
{
    public static class StringExtensions
    {
        public static void ThrowIfEmptyOrNull(this string str, string parameterName)
        {
            str = (str ?? string.Empty).Trim();
            if (str.Length == 0) throw new ArgumentException($"String parameter {parameterName} is empty.");
        }

        public static bool IsEmptyContent(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool CompareStringIgnoreCase(this string str, string text)
        {
            return str.Equals(text, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsUpper(this string value)
        {
            // Consider string to be uppercase if it has no lowercase letters.
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsLower(this string value)
        {
            // Consider string to be lowercase if it has no uppercase letters.
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
