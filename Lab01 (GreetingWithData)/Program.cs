using System;

namespace Lab01__GreetingWithData_
{
    class Greeting
    {
        static void Main()
        {
            Console.WriteLine("Здравствуйте");                                                                       // Приветствие

            Console.WriteLine("Введите ваше имя");                                                                   // Ввод данных
            string name = Console.ReadLine();
            Console.WriteLine("Введите ваш день рождения");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш месяц рождения");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш год рождения");
            int year = int.Parse(Console.ReadLine());

            DateTime date = DateTime.Now;
            int yearnow = date.Year;                                                                                 //Вводим возраст
            int daynow = date.Day;
            int mouthnow = date.Month;
            int age = yearnow - year;

            if (year % 4 == 0 && month == 2 && day > 29)                                                             //Проверка високосного года
                Console.WriteLine("В феврале может быть не больше 29 дней в високосный год");
            else if (year % 4 != 0 && month == 2 && day > 28)
                Console.WriteLine("В феврале может быть не больше 28 дней");
            else if (day > 31 || day < 1)
                Console.WriteLine("В месяце может быть от 1 до 31 дня включительно");                                // Проверка на кол-во дней/месяцев
            else if (month > 12 || month < 1)
                Console.WriteLine("В году может быть от 1 до 12 месяцев включительно");

            else if (month > mouthnow || month == mouthnow && day > daynow)
            {                                                                                                        // Корректировка возраста
                age = age - 1;
                Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");
            }
            else
                Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");
        }
    }
}