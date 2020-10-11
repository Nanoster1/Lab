using System;
using System.Threading;

namespace Visual_novell
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (string answer = "Y"; answer != "N";)
            {            
            Console.WriteLine("Напишите текст");
            string text = Console.ReadLine();
            Console.WriteLine("Напишите задержку");
            int delay = int.Parse(Console.ReadLine());
            Console.Clear();

            foreach (char word in text)
            {
                Console.Write(word);
                Thread.Sleep(delay);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Повторить?");
            Console.WriteLine("Нет - N");
            answer = Console.ReadLine();
            answer = answer.ToUpper();
            }
        }
    }
}
