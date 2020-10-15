using System;
using System.Linq.Expressions;
using System.Threading;

namespace Lab05_Factorial
{
    class Program
    {
        static void SetCursor(string conc, int y)                                       //Функция для курсора
        {
            int x = Console.WindowWidth / 2 - conc.Length / 2;
            int y2 = Console.WindowHeight / 2 + y;
            Console.SetCursorPosition(x, y2);
        }
        static void WriteString(char a, int b)                                          //Функция для множественного написания символов
        {
            Console.Write(new string(a, b));
        }



        static void Main()                                                               //Основа
        {
            WriteGreeting();
            ulong number = Input();
            Loading();
            Output(number);
        }
        static void WriteGreeting()                                                      //Приветствие
        {
            string greeting = ("Здравствуйте, ваше число, пожалуйста: ");
            for (int i = 0; i < greeting.Length; i++)
            {
                Console.Write(greeting[i]);
                Thread.Sleep(50);
            }
        } 
        static ulong Input()                                                              //Ввод
        {
            string numberStr = Console.ReadLine();
            Check(numberStr);
            return ulong.Parse(numberStr);
        }
        static void Check(string numberStr)                                               //Проверка на число
        {
            ulong a;
            bool checking = ulong.TryParse(numberStr, out a);
            while (checking == false)
            {
                Main();
            }
        }
        static void Loading()                                                             //Экран загрузки (Чисто декор)
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
        static void Output(ulong number)                                                  //Зацикленный вывод со сменой цвета
        {
            string conc = ($"│$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$ |{Сalculation(number)}| $-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$│");
                Console.Clear();               
            while (true)
            {
                IntoOutput(conc);
                SwapColors(Console.ForegroundColor, Console.BackgroundColor);
                IntoOutput(conc);
                SwapColors(Console.ForegroundColor, Console.BackgroundColor);
            }
        }
        static void IntoOutput(string conc)                                               //Табличка ("Внутренности вывода")
        {
            Console.Clear();
            SetCursor(conc, -1);
            DoubleIntoOut(conc, '┌', '┐');
            SetCursor(conc, 0);
            Console.Write(conc);
            SetCursor(conc, 1);
            DoubleIntoOut(conc, '└', '┘');
            Thread.Sleep(1000);          
        }
        static void DoubleIntoOut(string conc, char leftSymbol, char rightSymbol)         //строки рамки                  
        {
            Console.Write(leftSymbol);
            WriteString('─', conc.Length - 2);
            Console.Write(rightSymbol);
        }
        static void SwapColors(ConsoleColor f, ConsoleColor b)    //Смена цветов
        {
            ConsoleColor c;
            c = b;
            b = f;
            f = c;
            Console.ForegroundColor = f;
            Console.BackgroundColor = b;
        }
        static ulong Сalculation(ulong number)                                             //Вычисление факториала
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
