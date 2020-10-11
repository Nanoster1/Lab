using System;
using System.Linq;

namespace Lab02_Knights_move
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите свою фигуру из предложенных:");
            Console.WriteLine("Король");
            Console.WriteLine("Ферзь");
            Console.WriteLine("Ладья");
            Console.WriteLine("Слон");
            Console.WriteLine("Конь");
            Console.WriteLine("Пешка");
            string figure = Console.ReadLine();
            figure = figure.ToLower();
            figure = figure.Trim();
            string a = Console.ReadLine();
            string b = new string(a.Reverse().ToArray());

            if (figure == "король")
                Console.WriteLine(b);
            else if (figure == "ферзь")
                queen();
            else if (figure == "ладья")
                rook();
            else if (figure == "слон")
                bishop();
            else if (figure == "конь")
                knight();
            else if (figure == "пешка")
                pawn();
            else
                Console.WriteLine("Ошибка: Введите название фигуры корректно");
        }
        static bool king()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            Console.WriteLine("Введите координаты после хода");
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();

            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];

            int x1 = b1 + 1;                                                           //Изменения цифр
            int x2 = b1 - 1;
            int aftertrue1 = b0 + 1;                                                   //Изменения букв                 
            int aftertrue2 = b0 - 1;


            bool c = b0 == a0 && (x1 == a1 || x2 == a1)                                //Условие хода королём
                  || b1 == a1 && (aftertrue1 == a0 || aftertrue2 == a0)
                  || a0 == aftertrue1 && (a1 == x1 || a1 == x2)
                  || a0 == aftertrue2 && (a1 == x1 || a1 == x2);

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                    
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;
        }
        static bool queen()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            Console.WriteLine("Введите координаты после хода");
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();

            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];

            int x1 = a0 - b0;                                                          //Разность координат
            int x2 = a1 - b1;

            bool c = a0 == b0 || a1 == b1 || Math.Abs(x1) == Math.Abs(x2);             //Условие хода ферзём

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                    
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;
        }
        static bool rook()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();

            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];

            bool c = a0 == b0 || a1 == b1;                                             //Условие хода ладьёй

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                                                                                                                   
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;
        }
        static bool bishop()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            Console.WriteLine("Введите координаты после хода");
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();

            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];

            int x1 = a0 - b0;                                                          //Разность координат
            int x2 = a1 - b1;

            bool c = (Math.Abs(x1) == Math.Abs(x2));                                   //Условие хода слоном

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                    
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;
        }
        static bool knight()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            Console.WriteLine("Введите координаты после хода");
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();

            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];

            int x1 = b1 + 2;                                                           //Изменения цифр
            int x2 = b1 + 1;
            int x3 = b1 - 2;
            int x4 = b1 - 1;
            int aftertrue1 = b0 + 1;                                                   //Изменения букв                 
            int aftertrue2 = b0 - 1;
            int aftertrue3 = b0 + 2;
            int aftertrue4 = b0 - 2;

            bool c = x1 == a1 && (aftertrue1 == a0 || aftertrue2 == a0 )               //Условие хода конём
                  || x2 == a1 && (aftertrue3 == a0 || aftertrue4 == a0 )
                  || x3 == a1 && (aftertrue1 == a0 || aftertrue2 == a0 )
                  || x4 == a1 && (aftertrue3 == a0 || aftertrue4 == a0 );

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                    
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;

        }
        static bool pawn()
        {
            Console.WriteLine("Введите координаты начала");                            //Ввод координат
            string before = Console.ReadLine();
            Console.WriteLine("Введите координаты после хода");
            string after = Console.ReadLine();
            before = before.ToLower();
            after = after.ToLower();
            char b0 = before[0];                                                       //Присваеваем переменным значения символов                   
            char a0 = after[0];
            char b1 = before[1];
            char a1 = after[1];                                                        //Изменение цифры

            int x1 = b1 + 1;
            int x2 = b1 + 2;
            int x3 = b1 - 1;
            int x4 = b1 - 2;

            bool c = b0 == a0                                                          //Условие хода пешки
                 && (x1 == a1 || x3 == a1
                 ||  b1 == 50 && x2 == a1
                 ||  b1 == 55 && x4 == a1);           

            if (c == true && a1 >= 49 && a1 <= 56 && a0 >= 97 && a0 <= 104 && b1 >= 49 && b1 <= 56 && b0 >= 97 && b0 <= 104)                                                                                                     //Вывод данных                                    
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
            return c;
        }
    }
}