using System;
using System.Collections.Generic;

namespace DojoDotNetStringToNumber
{
    class Program
    {
        static string NumberPerExtense;

        static void Main(string[] args)
        {
            GetNumberPerExtense();

            Console.WriteLine(Cheque.ConvertTextToDecimal(NumberPerExtense));

            Console.ReadKey();
        }

        static void GetNumberPerExtense()
        {
            Console.WriteLine("Enter your number:");

            NumberPerExtense = Console.ReadLine();
        }
    }
}
