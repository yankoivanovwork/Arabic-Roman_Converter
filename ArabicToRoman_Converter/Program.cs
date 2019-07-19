using System;
using System.Linq;
using System.Collections.Generic;

namespace ArabicToRoman_Converter
{
    class Program
    {
        private static Dictionary<char, int> romanNumbers = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        static void Main(string[] args)
        {
            int entryNumber;

            if (int.TryParse(Console.ReadLine(), out entryNumber) & entryNumber >= 1 & entryNumber <= 500)
            {
                string convertedRomanNumber = string.Empty;

                convertedRomanNumber += CalculateArabDigits(entryNumber / 100, 2);
                convertedRomanNumber += CalculateArabDigits(((entryNumber % 100) - (entryNumber % 10)) / 10, 1);
                convertedRomanNumber += CalculateArabDigits(entryNumber % 10, 0);

                Console.WriteLine(convertedRomanNumber);
            }
        }

        private static string CalculateArabDigits(int entryNumber, int digitPosition)
        {
            string convertedRomanNumber = string.Empty;

            if (entryNumber != 0)
            {
                int dictionaryPosition = digitPosition * 2;

                if (entryNumber <= 3)
                {
                    convertedRomanNumber += new string(romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition), entryNumber);
                }
                else if (entryNumber >= 4 & entryNumber <= 8)
                {
                    if (entryNumber < 5)
                        convertedRomanNumber += romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition);

                    convertedRomanNumber += romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition + 1);

                    if (entryNumber > 5)
                        convertedRomanNumber += new string(romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition), entryNumber - 5);
                }
                else
                {
                    convertedRomanNumber += romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition);
                    convertedRomanNumber += romanNumbers.Keys.ElementAtOrDefault(dictionaryPosition + 2);
                }
            }

            return convertedRomanNumber;
        }
    }
}