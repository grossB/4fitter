using System.Collections.Generic;
using System.Web.Mvc;

namespace _4fitter.Utilities
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString CheckIfUserIsInRole(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value == string.Empty;
        }

        public static string RemovePolishLetters(this string source)
        {
            var result = source.ToLower();

            var forbiddenLetters = new Dictionary<char, char>
            {
                { 'ń', 'n' },
                { 'ą', 'a' },
                { 'ś', 's' },
                { 'ć', 'c' },
                { 'ź', 'z' },
                { 'ż', 'z' },
                { 'ó', 'o' },
                { 'ł', 'l' },
                { 'ę', 'e' }
            };

            foreach (var letter in forbiddenLetters)
            {
                result = result.Replace(letter.Key, letter.Value);
            }

            return result;
        }
    }
}