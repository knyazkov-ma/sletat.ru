using System.Text.RegularExpressions;

namespace sletat.ru
{
    public static class ExtensionString
    {
        public static string GetClearPhone(this string s)
        {
            return Regex.Replace(s, @"[^\d]", "");
        }
    }
}
