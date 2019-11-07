using DojoDotNetStringToNumber.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoDotNetStringToNumber
{
    public static class Cheque
    {
        // static readonly string TagMillion = "{million}";
        static readonly string TagThousand = "{thousand}";

        static readonly string TagHundred = "{hundred}";

        static readonly string TagCents = "{cents}";

        static string Mask = $"{TagThousand}{TagHundred}{TagCents}";

        static string Text = "";

        static Dictionary<string,int> Numbers = new Dictionary<string, int>();

        /// <summary>
        /// 
        /// </summary>
        public static string ConvertTextToDecimal(string text)
        {
            CreateDictionary();

            Text = text;

            Mask = Mask.Replace(TagCents, GetCents(Text));
            Mask = Mask.Replace(TagHundred, GetHundred(Text));
            Mask = Mask.Replace(TagThousand, GetThousand(Text));

            return Mask;
        }

        /// <summary>
        /// 
        /// </summary>
        static string GetCents(string text)
        {
            var sum = "0";

            if(!text.ToLower().Contains("centavo"))
                return sum.PadLeft(2, '0');
            
            // Remove text "real" or "reais" and empty spaces
            text = text.ToLower().SubstringWhen(new[] { "real e ", "reais e " });

            // Remove partial text from complete text
            Text = Text.Replace(text, string.Empty);

            // Remove text "centavo" or "centavos" and empty spaces
            text = text.ToLower().ReplaceAll(new[] { "centavos", "centavo" }, string.Empty);

            text.ToLower()
                .Split(" e ", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(v => sum += Numbers[v.Trim()] );
            
            return $"{sum.ToString().PadLeft(2, '0')}";
        }

        /// <summary>
        /// 
        /// </summary>
        static string GetHundred(string text)
        {
            var sum = 0;

            if(!text.ToLower().Contains("real") && !text.ToLower().Contains("reais"))
                return text.ToLower().Contains("mil") ? "000," : "0,";

            // Remove text "mil" and empty spaces
            text = text.ToLower().SubstringWhen(new[] { "mil e", "mil" }).Trim();

            // Remove partial text from complete text
            Text = Text.Replace(text, string.Empty);

            // Remove text "real" or "reais" and empty spaces
            text = text.ToLower().ReplaceAll(new[] { "real e", "reais e", "real", "reais" }, string.Empty).Trim();

            text.ToLower()
                .Split(" e ", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(v => sum += Numbers[v.Trim()] );

            return $"{sum.ToString().PadLeft(3, '0')},";
        }

        /// <summary>
        /// 
        /// </summary>
        static string GetThousand(string text)
        {
            var sum = 0;

            if(!text.ToLower().Contains("mil") && !text.ToLower().Contains("reais"))
                return string.Empty;

            // Remove text "real" or "reais" and empty spaces
            text = text.ToLower().ReplaceAll(new[] { "mil e", "mil" }, string.Empty).Trim();

            if(text.Length == 0)
                text = "um";

            text.ToLower()
                .Split(" e ", StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(v => sum += Numbers[v.Trim()] );

            return $"{sum}.";
        }

        /// <summary>
        /// 
        /// </summary>
        static void CreateDictionary()
        {
            Numbers.Add("um", 1);
            Numbers.Add("dois", 2);
            Numbers.Add("tres", 3);
            Numbers.Add("quatro", 4);
            Numbers.Add("cinco", 5);
            Numbers.Add("seis", 6);
            Numbers.Add("sete", 7);
            Numbers.Add("oito", 8);
            Numbers.Add("nove", 9);
            Numbers.Add("dez", 10);
            Numbers.Add("onze", 11);
            Numbers.Add("doze", 12);
            Numbers.Add("treze", 13);
            Numbers.Add("quatorze", 14);
            Numbers.Add("catorze", 14);
            Numbers.Add("quinze", 15);
            Numbers.Add("dezesseis", 16);
            Numbers.Add("dezessete", 17);
            Numbers.Add("dezoito", 18);
            Numbers.Add("dezenove", 19);
            Numbers.Add("vinte", 20);
            Numbers.Add("trinta", 30);
            Numbers.Add("quarenta", 40);
            Numbers.Add("cinquenta", 50);
            Numbers.Add("sessenta", 60);
            Numbers.Add("setenta", 70);
            Numbers.Add("oitenta", 80);
            Numbers.Add("noventa", 90);
            Numbers.Add("cem", 100);
            Numbers.Add("cento", 100);
            Numbers.Add("duzentos", 200);
            Numbers.Add("trezentos", 300);
            Numbers.Add("quatrocentos", 400);
            Numbers.Add("quinhentos", 500);
            Numbers.Add("seiscentos", 600);
            Numbers.Add("seissentos", 600);
            Numbers.Add("setecentos", 700);
            Numbers.Add("oitocentos", 800);
            Numbers.Add("novecentos", 900);
            Numbers.Add("mil", 1000);
        }
    }
}