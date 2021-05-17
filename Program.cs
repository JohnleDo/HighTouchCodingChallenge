using System;
using System.Collections.Generic;
using System.Linq;

namespace HighTouchCodingChallenge
{
    class Program
    {
        static IDictionary<string, int> StringInfo(string text)
        {
            IDictionary<string, int> characters = new Dictionary<string, int>();

            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    if (!characters.ContainsKey(c.ToString()))
                    {
                        characters.Add(c.ToString(), 1);
                    }
                    else
                    {
                        characters[c.ToString()]++;
                    }
                }
                else
                {
                    if (!characters.ContainsKey("Invalid Characters"))
                    {
                        characters.Add("Invalid Characters", 1);
                    }
                    else
                    {
                        characters["Invalid Characters"]++;
                    }
                }
            }

            return characters;
        }

        static string StringExtractor(IDictionary<string, int> characters)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

            foreach (char c in alphabet)
            {
                if (characters.ContainsKey(c.ToString()))
                {
                    alphabet = alphabet.Replace(c.ToString(), "");
                }
            }

            return alphabet;
        }

        static void StringStats(IDictionary<string, int> characters)
        {
            int invalidChar = 0;
            int letterCount = 0;
            SortedDictionary<string, int> sortedList = new SortedDictionary<string, int>(characters);
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Number of specific charater occurences");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var x in sortedList)
            {
                if (x.Key == "Invalid Characters")
                {
                    invalidChar = x.Value;
                }
                else
                {
                    Console.WriteLine(string.Format("Letter {0}, Number of times occured: {1}", x.Key, x.Value));
                    letterCount = letterCount + x.Value;
                }
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(string.Format("Amount of Characters: {0}", invalidChar + letterCount));
            Console.WriteLine(string.Format("Amount of Valid Characters: {0}", letterCount));
            Console.WriteLine(string.Format("Amount of Invalid Characters: {0}", invalidChar));
            Console.WriteLine("------------------------------------------------------------------");
        }

        static void Main(string[] args)
        {
            IDictionary<string, int> letters = new Dictionary<string, int>();
            var inputtedText = "";

            while (true)
            {
                Console.Write("Enter a string:  ");
                inputtedText = Console.ReadLine();
                inputtedText = inputtedText.ToLower();

                if (inputtedText.Length <= 256)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The string you enter exceeded 256 characters, please try again");
                }
            }



            letters = StringInfo(inputtedText);

            var newWord = StringExtractor(letters);
            int count = 0;
            foreach (char c in newWord)
            {
                count++;
            }

            StringStats(letters);

            Console.WriteLine(string.Format("The alphabet minus letters from user input: {0}, Letter count: {1}", newWord, count));

        }
    }
}
