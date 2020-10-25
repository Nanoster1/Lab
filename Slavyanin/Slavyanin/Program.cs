using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Slavyanin
{
    class Program
    {
        enum Letters
        {
            A = 10, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Б, Г, Д, Ё, Ы, Ъ, Ь, П, Й, И, Ш, Щ, З, Ф
        }
        static void Main()
        {
            Greetings2();
            ConsoleKeyInfo key = Console.ReadKey();
            PressKey(key);
        }
        static void PressKey(ConsoleKeyInfo key)
        {
            string num1;                                                                                   //Первое число
            string num2;                                                                                   //Второе число
            double ss;                                                                                     //Система счисления
            string op;                                                                                     //Операция
            string num1InSS;                                                                               //Первое обычное число в системе счисления
            string num2InSS;                                                                               //Второе обычное число в системе счисления
            string fracNum1InSS;                                                                           //Первое дробное число в системе счисления
            string fracNum2InSS;                                                                           //Второе дробное число в ситстеме счисления
            string numFinal;                                                                               //Конечное число (дописать метод)
            double normalNumFinal;                                                                         //Конечное число в десятичной системе счисления
            switch (key.Key)
            {
                case ConsoleKey.Q:                                                                         //Операция
                    Console.Clear();
                    Console.WriteLine("Введите 2 числа, пожалуйста.");
                    num1 = Input();                                                                        //Первое число
                    num2 = Input();                                                                        //Второе число
                    Console.Clear();
                    ss = WriteSS();                                                                        //Система счисления
                    Console.Clear();
                    op = WriteSign();                                                                      //Операция
                    if (num1.Contains(',') && num2.Contains(','))
                    {
                        fracNum1InSS = fullTransfer(num1, ss);                                             //Первое дробное число в системе счисления
                        fracNum2InSS = fullTransfer(num2, ss);                                             //Второе дробное число в ситстеме счисления
                        OperationOutput(op, num1, num2, ss);                                               //Метод операции
                                                                                                           //Метод шагов
                    }
                    else if (num1.Contains(',') && !num2.Contains(','))
                    {
                        fracNum1InSS = fullTransfer(num1, ss);                                             //Первое дробное число в системе счисления
                        num2InSS = new string(Transfer(num2, ss).Reverse().ToArray());                     //Второе обычное число в системе счисления
                        OperationOutput(op, num1, num2, ss);                                               //Метод операции
                                                                                                           //Метод шагов
                    }
                    else if (!num1.Contains(',') && num2.Contains(','))
                    {
                        num1InSS = new string(Transfer(num1, ss).Reverse().ToArray());                     //Первое обычное число в системе счисления
                        fracNum2InSS = fullTransfer(num2, ss);                                             //Второе дробное число в ситстеме счисления
                        OperationOutput(op, num1, num2, ss);                                               //Метод операции
                                                                                                           //Метод шагов
                    }
                    else if (!num1.Contains(',') && !num2.Contains(','))
                    {
                        num1InSS = new string(Transfer(num1, ss).Reverse().ToArray());                     //Первое обычное число в системе счисления
                        num2InSS = new string(Transfer(num2, ss).Reverse().ToArray());                     //Второе обычное число в системе счисления
                        OperationOutput(op, num1, num2, ss);                                               //Метод операции
                                                                                                           //Метод шагов
                    }
                    break;
                case ConsoleKey.W:                                                                         //Перевод числа в СС
                    Console.Clear();
                    Console.WriteLine("Введите число, пожалуйста.");
                    num1 = Input();                                                                        //Число
                    ss = WriteSS();                                                                        //Система счисления
                    Console.WriteLine($"Ваше число: {num1}");
                    if (num1.Contains(","))
                    {
                        if (num1.Contains("-"))
                        {
                            num1 = num1.Replace("-", "");
                            Console.WriteLine($"Ваше число в {ss}-й СС: -{fullTransfer(num1, ss)}");
                        }
                        else
                            Console.WriteLine($"Ваше число в {ss}-й СС: {fullTransfer(num1, ss)}");        //Дробное число в системе счисления
                    }
                    else
                    {
                        if (num1.Contains("-"))
                        {
                            num1 = num1.Replace("-", "");
                            Console.WriteLine($"Ваше число в {ss}-й СС: -{new string(Transfer(num1, ss).Reverse().ToArray())}");     //Обычное число в системе счисления
                        }
                        else
                            Console.WriteLine($"Ваше число в {ss}-й СС: {new string(Transfer(num1, ss).Reverse().ToArray())}");      //Обычное число в системе счисления
                    }
                    break;
                case ConsoleKey.E:                                                                         //Римская чушь
                    Console.Clear();
                    Console.WriteLine("Введите число, пожалуйста.");
                    num1 = Input();                                                                        //Число
                    Console.Clear();
                    Console.WriteLine($"Ваше число: {num1}");
                    Console.Write($"Ваше число на римский лад: {WriteElseIfString(num1)}");                //Римское число
                    break;
                case ConsoleKey.R:                                                                         //Вещественная чушь
                    Console.Clear();
                    Console.WriteLine("Введите число, пожалуйста.");
                    num1 = Input();                                                                        //Число
                    Console.WriteLine($"Ваше число в представлнении типа float: {WriteRealNumber(num1)}");
                    break;
                case ConsoleKey.T:                                                                         //Перевод в 10-ю СС
                    Console.Clear();
                    Console.WriteLine("Введите число, пожалуйста.");
                    num1 = Input();
                    ss = WriteSS();                                                                        //Система счисления
                    Console.WriteLine($"Ваше число: {num1}");
                    Console.WriteLine($"Ответ в 10-й СС: {TransferInTen(num1, ss)}");
                    Console.WriteLine();
                    break;


            }
        }
        static void OperationOutput(string op, string num1, string num2, double ss)
        {
            double normalNum1 = double.Parse(num1);
            double normalNum2 = double.Parse(num2);
            double finalNum = 0;
            if (op == "+")
            {
                finalNum = normalNum1 + normalNum2;
            }
            else if (op == "-")
            {
                finalNum = normalNum1 - normalNum2;
            }
            else if (op == "*")
            {
                finalNum = normalNum1 * normalNum2;
            }
            else if (op == "/")
            {
                finalNum = normalNum1 / normalNum2;
            }
            Console.WriteLine($"Ответ в 10-й СС: {finalNum}");
            Console.WriteLine($"Ответ в {ss}-й СС: {new string(Transfer(finalNum.ToString(), ss).Reverse().ToArray())}");
        }
        static void Greetings2()
        {
            Console.WriteLine("Нажмите Q, если хотите провести операцию");
            Console.WriteLine("Нажмите W, если хотите перевести число в СС (не больше 50-й)");
            Console.WriteLine("Нажмите E, если хотите увидеть число римскими символами");
            Console.WriteLine("Нажмите R, если хотите перевести число в вещественный тип");
            Console.WriteLine("Нажмите T, если хотите перевести число из СС (не больше 50-й) в 10-ю СС");
        }
        static string WriteNegativeNum(string num, double ss)                                               //Представление в компе отрицательного числа
        {
            num = num.Replace("-", "");
            string numInSS = new string(Transfer(num, 2).Reverse().ToArray()); //Число в 2-й СС
            while (numInSS.Length % 8 != 0)
            {
                numInSS = "0" + numInSS;
            }
            numInSS = numInSS.Replace("0", "2");
            numInSS = numInSS.Replace("1", "0");
            numInSS = numInSS.Replace("2", "1");
            double i = double.Parse(TransferInTenMain(numInSS, ss));
            i += 1;
            return Convert.ToString(i);
        }
        static string WriteSign()                            //Ввод операции
        {
            string op;
            Console.WriteLine("Введите операцию с этими числами");
            do
            {
                op = Console.ReadLine();
                if (op != "+" && op != "-" && op != "*" && op != "/")
                {
                    Console.WriteLine("Возможные операции:  + ,  -  ,  *  ,  / ");
                }
            }
            while (op != "+" && op != "-" && op != "*" && op != "/");
            return op;
        }
        static int WriteSS()                                 //Ввод системы счисления
        {
            Console.WriteLine("Введите систему счисления от 2-х до 50-ти");
            int ss;
            do
            {
                ss = int.Parse(Input());
                if (ss < 2 || ss > 50)
                {
                    Console.WriteLine("Система счисления должна быть в пределах от 2-х до 50-ти");
                }
            }
            while (ss < 2 || ss > 50);
            return ss;
        }
        static string Input()                                        //Ввод числа
        {
            string num = Console.ReadLine();
            return Check(num);
        }
        static string Check(string num)
        {
            double d;
            int i;
            string num2 = num.Replace(",", "");
            while (!int.TryParse(num2, out i) || !double.TryParse(num2, out d))
            {
                Console.WriteLine("Ошибка ввода");
                num = Console.ReadLine();
                num2 = num.Replace(",", "");
            }
            return num;
        }
        static string Transfer(string num, double ss)
        {
            int sss = Convert.ToInt32(ss);
            string numInSS = "";
            int intnum = int.Parse(num);
            while (intnum >= sss)
            {
                int remains = intnum % sss;
                intnum /= sss;
                if (remains > 9)
                    numInSS += (Letters)(remains);
                else
                    numInSS += remains;
            }
            if (intnum > 9)
                numInSS += (Letters)(intnum);
            else
                numInSS += intnum;
            return numInSS;
        }
        static string TransferInTen(string num, double ss)
        {
                string numInSS;
                string[] qoma = num.Split(',');
                numInSS = TransferInTenMain(qoma[0], ss);
                numInSS = numInSS + ",";
                numInSS += TransferInTenFrac(qoma[1], ss);
                return numInSS;
        }
        static string TransferInTenFrac(string num, double ss)
        {
            double final = 0;
            int i = -1;
            for (int q = 0; q < num.Length; q++)
            {
                double p = Math.Pow(ss, i);
                if (Convert.ToInt32(num[q].ToString()) > 9)
                {
                    final += CheckEnam(num, q) * p;
                }
                else
                    final += Convert.ToInt32(num[q]) * p;
                i -= 1;
            }
            return final.ToString();
        }
        static string TransferInTenMain(string num, double ss) //Перевод в десятичную СС
        {
            double final = 0;
            int i = num.Length - 1;
            for (int q = 0; q < num.Length; q++)
            {
                double p = Math.Pow(ss, i);
                if (Convert.ToInt32(num[q].ToString()) > 9)
                {
                    final += CheckEnam(num, q) * p;
                }
                else
                    final += Convert.ToInt32(num[q]) * p;
                i -= 1;
            }
            return final.ToString();
        }
        static double CheckEnam(string numFinal, int q)
        {
            int trueNum = 0;
            for (short i = 10; i <= 50; i++)
            {
                if (numFinal[q].ToString() == Convert.ToString((Letters)(i)))
                    trueNum = i;
            }
            return trueNum;
        }
        static string WriteElseIfString(string num)
        {
            string finalRome = "";
            int num2 = int.Parse(num) % 1000;
            int num3 = int.Parse(num) / 1000;
            for (int i = 0; i < num3; i++)
            {
                finalRome += 'M';
            }
            if (num2 / 500 != 0)
            {
                finalRome += new string('D', num2 / 500);
                num2 %= 500;
            }
            if (num2 / 100 != 0)
            {
                finalRome += new string('C', num2 / 100);
                num2 %= 100;
            }
            if (num2 / 50 != 0)
            {
                finalRome += new string('L', num2 / 50);
                num2 %= 50;
            }
            if (num2 / 10 != 0)
            {
                finalRome += new string('X', num2 / 10);
                num2 %= 10;
            }
            if (num2 - 5 >= 0)
            {
                finalRome += new string('V', num2 / 5);
                num2 -= 5;
            }
                finalRome += new string('I', num2);
            return finalRome;
        }
        static string fullTransfer(string num, double ss)
        {
            string numInSS;
            string[] qoma = num.Split(',');
            numInSS = new string(Transfer(qoma[0], ss).Reverse().ToArray());
            numInSS = numInSS + ",";
            numInSS += TransferFrac(qoma[1], ss);
            return numInSS;
        }
        static string TransferFrac(string num, double ss)
        {
            int sss = Convert.ToInt32(ss);
            int div = int.Parse("1" + new string('0', num.Length));
            int intNum = int.Parse(num);
            string finalFrac = "";
            int time;
            int i = 0;
            while (intNum != 0 && i < 10)
            {
                i++;
                intNum *= sss;
                time = intNum / div;
                if (time > 9)
                {
                    finalFrac += (Letters)(time);
                    intNum %= div;
                }
                else
                    finalFrac += time;
                    intNum %= div;
            }
            return finalFrac;
        }
        static string WriteRealNumber(string num)
        {
            string[] numB = num.Split(',');
            string numD = fullTransfer(num, 2);            //Доделать
            numD = numD.Replace(",", "");
            numD = numD.Remove(0, 1);
            string numA;
            numB[0] = numB[0].Replace("-", "");
            string numQ = new string(Transfer(numB[0], 2).Reverse().ToArray());
            int time = 127 - 1 + numQ.Length;
            if (num.Contains("-"))
                numA = "1,";
            else
                numA = "0,";
            numA += new string(Transfer(time.ToString(), 2).Reverse().ToArray());
            numA += numD;
            while (numA.Length < 32)
                numA += "0";
            return numA;
        }
    }
}
