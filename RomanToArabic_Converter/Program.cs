using System;
using System.Linq;
using System.Collections.Generic;

namespace RomanToArabic_Converter
{
    class Program
    {
        private static Dictionary<char, int> romanNumbers = new Dictionary<char, int>
        {
            { 'I', 1 }, //0
            { 'V', 5 }, //1
            { 'X', 10 }, //2
            { 'L', 50 }, //3
            { 'C', 100 }, //4
            { 'D', 500 }, //5
            { 'M', 1000 } //6
        };

        static void Main(string[] args)
        {
            string entryRomanNumber = Console.ReadLine().ToUpper();
            int convertedArabicNumber = 0;

            for (int i = 0; i < entryRomanNumber.Length; i++)
            {
                //entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.ElementAtOrDefault(4) ||
                if (entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.ElementAtOrDefault(2)) // || entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.FirstOrDefault())
                {
                    if (entryRomanNumber.ElementAtOrDefault(i) == entryRomanNumber.ElementAtOrDefault(i + 1) & entryRomanNumber.ElementAtOrDefault(i + 1) != romanNumbers.Keys.FirstOrDefault())
                    {
                        convertedArabicNumber += entryRomanNumber.ElementAtOrDefault(i);
                        continue;
                    }
                    else
                    {
                        convertedArabicNumber -= entryRomanNumber.ElementAtOrDefault(i);
                        continue;
                    }
                }

                if (entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.FirstOrDefault())
                {
                    if (entryRomanNumber.ElementAtOrDefault(i + 1) == romanNumbers.Keys.ElementAtOrDefault(1))
                    {
                        convertedArabicNumber -= 1;
                        continue;
                    }
                    else
                    {
                        convertedArabicNumber += entryRomanNumber.Substring(entryRomanNumber.IndexOf(entryRomanNumber.ElementAtOrDefault(i)),entryRomanNumber.Length- entryRomanNumber.IndexOf(entryRomanNumber.ElementAtOrDefault(i))).Length * 1;
                        continue;
                    }
                }

                convertedArabicNumber += romanNumbers[entryRomanNumber.ElementAtOrDefault(i)];
            }

            Console.WriteLine(convertedArabicNumber);
        }
    }
}
