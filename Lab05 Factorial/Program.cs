using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace Lab05_Factorial
{
    class Program
    {
        static void SetCursor(string conc, int y)                            //Функция для курсора
        {
            int x = Console.WindowWidth / 2 - conc.Length / 2;
            int y2 = Console.WindowHeight / 2 - y;
            Console.SetCursorPosition(x, y2);
        }
        static void WriteString(char a, int b)                              //Функция для множественного написания символов
        {
            Console.Write(new string(a, b));
        }
        static void Check(string numberStr)                                 //Проверка на число
        {
            ulong a;
            bool checking = ulong.TryParse(numberStr, out a);
            while (checking == false)
            {
                Main();
            }    
        }


        static void Main()                                                  //Основа
        {
            WriteGreeting();
            ulong number = ulong.Parse(Input());
            Loading();
            Output(number);
        }
        static void WriteGreeting()                                         //Приветствие
        {
            string greeting = ("Здравствуйте, ваше число, пожалуйста:");
            Console.WriteLine(greeting);
        }
        static string Input()                                               //Ввод
        {
            string numberStr = Console.ReadLine();
            Check(numberStr);
            return numberStr;
        }
        static void Loading()                                               //Экран загрузки (Чисто декор)
        {
            int i = 1;
            string load = "Loading";
            while (i <= 3)
            {
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.Clear();
                i += 1;
                SetCursor(load, -1);
                Console.Write(load);
                WriteString('.', i);
                Thread.Sleep(600);
            }
        }
        static void Output(ulong number)                                      //Зацикленный вывод со сменой цвета
        {
            string conc = ($"@-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-|{Сalculation(number)}|-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-@");
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                IntoOutput(conc);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Blue;
                IntoOutput(conc);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Green;
                IntoOutput(conc);
            }
        }
        static void IntoOutput(string conc)                                 //Табличка ("Внутренности вывода")
        {
            SetCursor(conc, -1);
            Console.Write('#');
            WriteString('=', conc.Length - 2);
            Console.WriteLine('#');
            SetCursor(conc, 0);
            Console.WriteLine(conc);
            SetCursor(conc, 1);
            Console.Write('#');
            WriteString('=', conc.Length - 2);
            Console.Write('#');
            Thread.Sleep(1000);
            Console.Clear();

        }
        static ulong Сalculation(ulong number)                                 //Вычисление факториала
        {
            
            ulong fact = 1;
            for(ulong i = 1; i <= number; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
