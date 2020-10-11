using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_String
{
    class Program
    {
        static void Main()
        {
            bool x = false;
            Console.WriteLine("Input text. You can use English, don't forget the dots at the end of sentences.");                       //Ввод текста
            string text = Console.ReadLine();
            text = text.Trim();
            string textLow = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                if (i + 1 < textLow.Length && CheckWord(textLow[i + 1]) == false && CheckWord(textLow[i]) == false && CheckSpace(textLow[i]) && CheckSpace(textLow[i + 1]))
                    x = true;
            }
            if (x)
                Console.WriteLine("You have repeated 2 characters in a row");
            else
            {
                IsSigns(textLow);
                Console.WriteLine("");
                IsOffers(text);
                Console.WriteLine("");
                IsWords(textLow);
                Console.WriteLine("");
                IsOperLongWord(IsLongWord(textLow));
            }
        }
        static bool CheckWord(char a)
        {
            bool c = a >= 97 && a <= 122;
            return c;
        }
        static bool CheckSpace(char a)
        {
            bool d = a != 32;
            return d;
        }
        static void IsSigns(string textLow)                                                                                              //Подсчёт знаков
        {
            int symbol = 0;
            for (int i = 0; i < textLow.Length; i++)
            {
                if (CheckWord(textLow[i]) == false)
                {
                    if (textLow[i] != 32)
                        symbol += 1;
                }
            }
            Console.WriteLine($"Number of symbols in the text: {symbol}");
        }
        static void IsOffers(string text)                                                                                                //Разбиение на предложения
        {
            string[] textOffers = text.Split(new char[] { '.', '?', '!' });
            Console.WriteLine("Offers separately:");
            foreach (string of in textOffers)
            {
                Console.WriteLine(of.Trim());
            }
        }
        static void IsWords(string textLow)                                                                                              //Уникальные слова
        {
            Console.WriteLine("");
            string temporaryWord = "";
            List<string> unique = new List<string>();
            for (int i = 0; i < textLow.Length; i++)
            {
                if (CheckWord(textLow[i]))
                    temporaryWord += textLow[i];
                else
                {
                    unique.Add(temporaryWord);
                    temporaryWord = "";
                }
            }
            var uniq = unique.Distinct();
            foreach (string s in uniq)
            {
                Console.WriteLine(s);
            }
        }
        static string IsLongWord(string textLow)                                                                                          //Самое длинное слово
        {
            string temporaryWord = "";
            string longWord = "";
            for (int i = 0; i < textLow.Length; i++)
            {
                if (CheckWord(textLow[i]))
                    temporaryWord += textLow[i];
                else
                {
                    if (temporaryWord.Length > longWord.Length)
                        longWord = temporaryWord;
                    temporaryWord = "";
                }
            }
            Console.WriteLine($"The longest word: {longWord}");
            Console.WriteLine("");
            return longWord;
        }
        static void IsOperLongWord(string longWord)                                                                                       //Операции над самым длинным словом
        {
            if (longWord.Length % 2 == 0)
                longWord = longWord.Substring(0, longWord.Length / 2);
            else
                longWord = longWord.Replace(longWord[longWord.Length / 2 + 1], '*');
            Console.WriteLine(longWord);
        }
    }
}
