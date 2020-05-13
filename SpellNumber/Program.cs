using System;

namespace SpellNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the Number");
                var number = Int64.Parse(Console.ReadLine());
                var words = NumberTowords(number);
                Console.WriteLine(words);
            }

        }

        public static string NumberTowords(Int64 i)
        {
            if (i < 20)
            {
                return UnitProvider.Units[i];
            }
            if (i < 100)
            {
                return UnitProvider.Tens[i / 10] + ((i % 10 > 0) ? " " + NumberTowords(i % 10) : "");
            }
            if (i < 1000)
            {
                return UnitProvider.Units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + NumberTowords(i % 100) : "");
            }
            if (i < 100000)
            {
                return NumberTowords(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + NumberTowords(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return NumberTowords(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + NumberTowords(i % 100000) : "");
            }
            return NumberTowords(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + NumberTowords(i % 10000000) : "");
        }
    }
}
