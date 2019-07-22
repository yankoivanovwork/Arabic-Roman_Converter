using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanArabic_Converter
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
            int arabicNumber;
            string entryLine = Console.ReadLine();

            if (int.TryParse(entryLine, out arabicNumber) && arabicNumber >= 1 & arabicNumber <= 500)
            {
                string convertedRomanNumber = string.Empty;

                convertedRomanNumber += CalculateRomanNumber(arabicNumber / 100, 2);
                convertedRomanNumber += CalculateRomanNumber(((arabicNumber % 100) - (arabicNumber % 10)) / 10, 1);
                convertedRomanNumber += CalculateRomanNumber(arabicNumber % 10, 0);

                Console.WriteLine(convertedRomanNumber);
            }
            else
            {
                //roman -> arabic
                //int convertedNumber = CalculateArabDigits(entryLine.ToUpper());
                Console.WriteLine(CalculateArabDigits(entryLine.ToUpper()));
            }
        }

        private static string CalculateRomanNumber(int entryNumber, int digitPosition)
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
