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
        };

        static void Main(string[] args)
        {
            string entryRomanNumber = Console.ReadLine().ToUpper();

            int convertedNumber = CalculateArabDigits(entryRomanNumber);

            Console.WriteLine(convertedNumber);
        }

        private static int CalculateArabDigits(string entryRomanNumber)
        {
            int convertedArabicNumber = 0;
            int dictionaryPosition = 0;

            for (int i = 0; i < entryRomanNumber.Length; i++)
            {
                // I, X, C
                if (entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.FirstOrDefault() 
                    || entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.ElementAtOrDefault(2) 
                    || entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.ElementAtOrDefault(4))
                {
                    if (entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.FirstOrDefault())
                        dictionaryPosition = 1;
                    else if (entryRomanNumber.ElementAtOrDefault(i) == romanNumbers.Keys.ElementAtOrDefault(2))
                        dictionaryPosition = 3;
                    else
                        dictionaryPosition = 5;

                    if (entryRomanNumber.ElementAtOrDefault(i + 1) == romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition))
                    {
                        convertedArabicNumber += romanNumbers[romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition)] - romanNumbers[romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition - 1)];
                        i += 1;
                        continue;
                    }

                    if (entryRomanNumber.ElementAtOrDefault(i + 1) == romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition + 1))
                    {
                        convertedArabicNumber += romanNumbers[romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition + 1)] - romanNumbers[romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition - 1)];
                        i += 1;
                        continue;
                    }
                }
                
                convertedArabicNumber += romanNumbers[entryRomanNumber.ElementAtOrDefault(i)];
            }

            return convertedArabicNumber;
        }
    }
}
