using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab03
{
    class Program
    {
        enum Operations
        {
            Addition,                                                           //Сложение
            Subtraction,                                                        //Вычитание 
            Multiplication,                                                     //Умножение
            Division                                                            //Деление
        }
        static void Changes(Operations c,int x, int value)
        {
            switch (c)
            {
                case Operations.Addition:                                       //Операции с x
                    x = x + value;                        
                    break;
                case Operations.Subtraction:
                    x = x - value;
                    break;
                case Operations.Multiplication:
                    x = x * value;
                    break;
                case Operations.Division:
                    x = x / value;
                    break;
            }
            int y = x * x;                                                      //Функция в коде
            string input = ($"x = {x} ; y = {y}");
            Console.WriteLine(input);                                           //Вывод
        }
        static void Main()
        {
            Console.WriteLine("Введите начало диапазона значений x");           //Ввод
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конец диапазона значений x");
            int end = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знак");
            string sign = Console.ReadLine();
            sign = sign.Trim();
            Console.WriteLine("Введите значение");
            int value = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)                                  //Диапаон
            {
                int x = i;
                if (sign == "+")
                    Changes(Operations.Addition, x, value);
                else if (sign == "-")
                    Changes(Operations.Subtraction, x, value);
                else if (sign == "*")
                    Changes(Operations.Multiplication, x, value);
                else if (sign == "/")
                    Changes(Operations.Division, x, value);                             
            }            
        }
    }
}
