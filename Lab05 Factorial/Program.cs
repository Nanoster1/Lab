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


        static void Main()                                                  //Основа и ввод числа
        {           
            WriteGreeting();
            int number = int.Parse(Console.ReadLine());
            Loading();
            Output(number);
        }
        static void WriteGreeting()                                         //Приветствие
        {
            string greeting = ("Здравствуйте, ваше число, пожалуйста:");
            Console.WriteLine(greeting);
            WriteString(' ', greeting.Length / 2 - 2);
            Console.WriteLine("...");
        }
        static void Loading()                                               //Экран загрузки (Чисто декор)
        {
            int i = 1;
            string load = "Loading";
            while (i <= 3)
            {
                Console.Clear();
                i += 1;
                SetCursor(load, -1);
                Console.Write(load);
                WriteString('.', i);
                Thread.Sleep(600);
            }
        }
        static void Output(int number)                                      //Зацикленный вывод со сменой цвета
        {
            string conc = ($"@-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-|{Сalculation(number)}|-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-@");
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                IntoOutput(conc);
                Console.ForegroundColor = ConsoleColor.White;
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
        static long Сalculation(int number)                                 //Вычисление факториала
        {
            int i = 1;
            long fact = 0;
            if (number >= 0)
                fact += 1;
            else if (number <= 0)
            {
                fact -= 1;
                if (number % 2 != 0)
                    fact = fact * (-1);
            }
            while (i <= Math.Abs(number))
            {
                fact = fact * i;
                i = i + 1;
            }
            return fact;
        }
    }
}
