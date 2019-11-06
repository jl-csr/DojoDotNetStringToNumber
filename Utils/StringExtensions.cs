namespace DojoDotNetStringToNumber.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static string SubstringWithRemove(this string text, string[] search)
        {
            foreach (var s in search)
            {
                if(text.IndexOf(s) >= 0)
                    text = text.Substring(text.IndexOf(s) + s.Length);
            }

            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Substring(this string text, string[] search)
        {
            foreach (var s in search)
            {
                if(text.IndexOf(s) >= 0)
                    text = text.Substring(0, text.IndexOf(s));
            }

            return text;
        }

        public static string ReplaceAll(this string text, string[] search, string replace)
        {
            foreach (var s in search)
                text = text.Replace(s, replace);

            return text;
        }
    }
}