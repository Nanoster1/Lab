using System;
using System.ComponentModel;
using System.Threading;

namespace Array2
{
    class Program
    {
        static void Main()
        {
            Greetings();
            if (PressKey())                                                          //Вписывание букв для выбора
            {
                Console.Clear();
                int[] firstAr = InputElofAr(1);                                      //Ввод первого массива
                int[] secondAr = InputElofAr(2);                                     //Ввод второго массива
                Output(CalculateEsc(firstAr, secondAr));                             //Вывод
            }
            else
            {
                Console.Clear();
                int[][] firstMultiAr = InputMultiAr(1);                              //Ввод первого массива массивов
                int[][] secondMultiAr = InputMultiAr(2);                             //Ввод второго массива массивов
                Output(CalculateEnt(firstMultiAr, secondMultiAr));                   //Вывод
            }
        }
        static void Greetings()                                                      //Приветствие
        {
            Console.WriteLine("Здравствуйте.");
            Console.WriteLine("Впишите O, если хотите провести операцию с одномерными массивами.");
            Console.WriteLine("Впишите MM, если хотите провести операцию с массивом массивов.");
        }
        static bool PressKey()                                                       //Метод для вписывания букв
        {
            bool c = false;
            if (Console.ReadKey().Key == ConsoleKey.O)
            {
                c = true;
                return c;
            }
            else if (Console.ReadKey().Key == ConsoleKey.M)
            {
                c = false;
                return c;  
            }   
            else
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода");
                Thread.Sleep(500);
                Main();
                return c;
            }
        }
        static bool CalculateEnt(int[][] firstAr, int[][] secondAr)                         //Проверка массивов массивов 
        {
            int s = 0;
            bool concl = false;
            int f = 0;
            int ff = 0;
            if (firstAr.Length < secondAr.Length)
                return concl;
            else
            {
                while (f < firstAr.Length)
                {
                    if (CalculateEsc(firstAr[f], secondAr[s]))
                    {
                        while (ff < firstAr.Length)
                        {
                            if (CalculateEsc(firstAr[ff], secondAr[s]))
                            {
                                concl = true;
                                s++;
                                if (s == secondAr.Length)
                                    return concl;
                            }
                            else
                            {
                                if (ff > 0 && s > 0 && CalculateEsc(firstAr[ff - 1], secondAr[s - 1]))
                                {
                                    concl = false;
                                    return concl;
                                }
                            }
                            ff++;
                            if (ff == firstAr.Length && s < secondAr.Length)
                            {
                                concl = false;
                                return concl;
                            }
                        }
                    }
                    else
                            concl = false;
                    f++;
                    ff = 0;
                }
                return concl;
            }
        }
        static int[][] InputMultiAr(int n)                                                          //Ввод массива массивов
        {
            int numAr;                                                                              //Кол-во элементов в массивах массива
            Console.WriteLine($"Введите кол-во массивов {n}-го массива массивов");
            int numberArray = InputNum();                                                           //Кол-во массивов в массиве массивов
            int[][] arrays = new int[numberArray][];                                                //Массив массивов
            int numberOfArray;
            for (int i = 0; i < numberArray; i++)
            {
                Console.WriteLine($"Введите кол-во элементов {i + 1}-го массива");
                numAr = InputNum();
                arrays[i] = new int[numAr];
                for (int k = 0; k < numAr; k++)
                {
                    Console.WriteLine($"Введите значение {k}-го элемента");
                    numberOfArray = InputNum();
                    arrays[i][k] = numberOfArray;
                }
                Console.Clear();
            }
            return arrays;
        }
        static void Output(bool Calculate)
        {
            if (Calculate)
                Console.WriteLine("Ваш второй массив является подмассивом первого массива");
            else
                Console.WriteLine("Ваш второй массив не является подмассивом первого массива");
        }
        static bool CalculateEsc(int[] firstAr, int[] secondAr)                                     //Проверка массивов
        {
            int s = 0;
            bool concl = false;
            int f = 0;
            int ff = 0;
            if (firstAr.Length < secondAr.Length)
                return concl;
            else
            {
                while ( f < firstAr.Length)
                {
                    if (firstAr[f] == secondAr[s])
                    {
                        ff = f;
                        while (ff < firstAr.Length)
                        {
                            if (firstAr[ff] == secondAr[s])
                            {
                                concl = true;
                                s++;
                                if (s == secondAr.Length)
                                    return concl;
                            }
                            else
                            {
                                if (concl) //ff > 0 && s > 0 && firstAr[ff - 1] == secondAr[s - 1] Условие правильного порядка цифр
                                {
                                    concl = false;
                                    break;
                                }
                            }
                            ff++;
                            if (ff == firstAr.Length && s < secondAr.Length)
                            {
                                concl = false;
                                break;
                            }
                        }
                    }
                    else
                        concl = false;
                    f++;
                    s = 0;
                }
                return concl;
            }
        }
        static int[] InputElofAr(int n)                                             //Ввод количества Элементов массива и возвращение массива
        {
            Console.WriteLine($"Введите количество элементов {n}-го массива");
            int NumAr = InputNum();
            int[] array = new int[NumAr];      //Массив
            for (int num = 0; num < NumAr; num++)
            {
                InputNumAr(array, num);
            }
            return array;
        }
        static void InputNumAr(int[] array,int num)                              //Ввод элемента массива
        {
            Console.WriteLine($"Введите значение {num}-го элемента массива");
            array[num] = InputNum();
        }
        static int InputNum()                                                    //Ввод числа
        {
            string a = Console.ReadLine();
            return int.Parse(a);
        }
        static void Check(string a)                                              //Проверка
        {
            bool b = int.TryParse(a, out int c);
            do
            {
                a = Console.ReadLine();
                b = int.TryParse(a, out c);
                if (b == false || int.Parse(a) < 0)
                    Console.WriteLine("Ошибка ввода, введите число ещё раз");
            }
            while (b == false || int.Parse(a) < 0);
        }
    }
}