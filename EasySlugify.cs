using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace EasySlugify
{
    public static class Slugify
    {
        public static string Slug(this string text, string separator = "-")
        {
            text = Regex.Replace(text, @"['\""]", ""); // Take out single and double quotes
            text = Regex.Replace(text, @"[^\p{L}\p{N}]", " "); // Replace non-letters and non-numeric characters with white spaces
            text = Regex.Replace(text.Trim(), @"\s+", separator); // Replace consecutive white spaces by just one separator
            return text;
        }

        public static string ReplaceDiacritics(this string text, Dictionary<string, string> characters = null)
        {
            if (characters != null)
            {
                text.ReplaceCharacters(characters);
            }
            // https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net/249126#249126
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in text.Normalize(NormalizationForm.FormD))
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string ReplaceCharacters(this string text, Dictionary<string, string> charactersDictionary)
        {
            foreach (KeyValuePair<string, string> item in charactersDictionary)
            {
                text = text.Replace(item.Key, item.Value);
            }
            return text;
        }
    }
}