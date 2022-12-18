using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace MainNamespace
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                TimeClass time1 = new TimeClass();
                TimeClass time2 = new TimeClass(17, 30, 10);

                Console.WriteLine("Insert time1 parameters");
                time1.Input();
                Console.WriteLine("\ntime1 parameters are");
                Console.WriteLine(time1.ToString());
                Console.WriteLine("time2 parameters are");
                Console.WriteLine(time2.ToString());

                Console.WriteLine($"\nDifference in seconds = {time1.GetTimeDifference(time2)} \n");

                Console.WriteLine("One second was added to time1 = " + time1++);
                Console.WriteLine("One second was substracted from time1 = " + time1-- + "\n");

                Console.WriteLine($"Is time1 == time2 = {time1 == time2}");
                Console.WriteLine($"Is time1 != time2 = {time1 != time2} \n");

                Console.WriteLine($"Is time1 > time2 = {time1 > time2}");
                Console.WriteLine($"Is time1 < time2 = {time1 < time2}");
                Console.WriteLine($"Is time1 >= time2 = {time1 >= time2}");
                Console.WriteLine($"Is time1 <= time2 = {time1 <= time2} \n");

                // Вызов перегруженного оператора true
                if (time1)
                    Console.WriteLine("For time1 a new day has come!");
                else
                    Console.WriteLine("For time1 it is still today...");

                // Вызов перегруженного оператора false
                if (time2)
                    Console.WriteLine("For time2 a new day has come!");
                else
                    Console.WriteLine("For time2 it is still today... \n");

                // int <= TimeClass - явное
                int ms = (int)time1;
                Console.WriteLine("Time1 in milliseconds = " + ms);

                // TimeClass <= int - неявное
                Random rnd = new Random();
                int number = rnd.Next(0, 23); // creates a number between 0 and 23
                time2 = number;
                Console.WriteLine("A new time2 = " + time2 + " - this is angelic time - make a wish!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}