using System;

namespace Array2
{
    class Program
    {
        static void Main()
        {
            Greetings();
            PressKey();
        }
        static void Greetings()
        {
            Console.WriteLine("Здравствуйте.");
            Console.WriteLine("Нажмите Escape, если хотите провести операцию с одномерными массивами.");
            Console.WriteLine("Нажмите Enter, если хотите провести операцию с массивом массивов.");
        }
        static void PressKey()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                Output(CalculateEsc(InputAr(1), InputAr(2)));
            else if (Console.ReadKey().Key == ConsoleKey.Enter)
                Output(CalculateEnt(InputMultiAr(1), InputMultiAr(2)));
        }
        static bool CalculateEnt(int[][] firstAr, int[][] secondAr)
        {
            int s = 0;
            bool concl = false;
            int f = 0;
            if (firstAr.Length < secondAr.Length)
                return concl;
            else
            {
                while (f < firstAr.Length)
                {
                    if (CalculateEsc(firstAr[f], secondAr[s]))
                    {
                        concl = true;
                        s++;
                        if (s == secondAr.Length)
                            return concl;
                    }
                    else
                    {
                        if (f > 0 && s > 0 && CalculateEsc(firstAr[f - 1], secondAr[s - 1]))
                        {
                            concl = false;
                            return concl;
                        }
                    }
                    f++;
                    if (f == firstAr.Length && s < secondAr.Length)
                    {
                        concl = false;
                        return concl;
                    }
                }
                return concl;
            }
        }
        static int[][] InputMultiAr(int n)
        {
            int numAr;                                           //Кол-во элементов в массивах массива
            Console.WriteLine($"Введите кол-во массивов {n}-го массива массивов");
            int numberArray = InputNum();                        //Кол-во массивов в массиве массивов
            int[][] arrays = new int[numberArray][];             //Массив массивов
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
            if (Calculate == true)
                Console.WriteLine("Ваш второй массив является подмассивом первого массива");
            else
                Console.WriteLine("Ваш второй массив не является подмассивом первого массива");
        }
        static bool CalculateEsc(int[] firstAr, int[] secondAr)
        {
            int s = 0;
            bool concl = false;
            int f = 0;
            if (firstAr.Length < secondAr.Length)
                return concl;
            else
            {
                while ( f < firstAr.Length)
                {
                    if (firstAr[f] == secondAr[s])
                    {
                        concl = true;
                        s++;
                        if (s == secondAr.Length)
                            return concl;
                    }
                    else
                    {
                        if (f > 0 && s > 0 && firstAr[f - 1] == secondAr[s - 1])
                        {
                            concl = false;
                            return concl;
                        }
                    }
                    f++;
                    if (f == firstAr.Length && s < secondAr.Length)
                    {
                        concl = false;
                        return concl;
                    }
                }
                return concl;
            }
        }
        static int[] InputAr(int n)
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
        static void InputNumAr(int[] array,int num)
        {
            Console.WriteLine($"Введите значение {num}-го элемента массива");
            array[num] = InputNum();
        }
        static int InputNum()
        {
            int c;
            string a = Console.ReadLine();
            bool b = int.TryParse(a, out c);
            while (b == false || int.Parse(a) < 0)
            {
                Console.WriteLine("Ошибка ввода, введите число ещё раз");
                a = Console.ReadLine();
                b = int.TryParse(a, out c);
            }
            return int.Parse(a);
        }
    }
}
