using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enter any number into a string, replace - and decimals with positive values. 

            //Console.WriteLine("Enter any number");
            //string number = Console.ReadLine();

            //number = number.Replace("-", "");
            //number = number.Replace(",", "");
            //number = number.Replace(".", "");

            //Check if length of a number is bigger than 3

            //if (number.Length > 3)
            //{
            //    Console.WriteLine(number + " is a big number");
            //}
            //else
            //{
            //    Console.WriteLine(number + " is a small number");
            // }

            //Parse the number variable into int and add 1 until it reaches 1000

            //int numb = Int32.Parse(number);

            //do
            //{
            //    numb++;
            //    Console.WriteLine(numb);
            //} while (numb < 1000);

            //////////////////////////////////////////////////////////////////////////////////////


            //Case simple exercise, days of the week

            //Console.WriteLine("Unesi broj dana!");
            //int broj = Int32.Parse(Console.ReadLine());

            //switch (broj)
            //{
            //    case 0: Console.WriteLine("Monday");
            //        break;
            //    case 1:
            //        Console.WriteLine("Tuesday");
            //        break;
            //    case 2:
            //        Console.WriteLine("Wednesday");
            //        break;
            //    case 3:
            //        Console.WriteLine("Thursday");
            //        break;
            //    case 4:
            //        Console.WriteLine("Firday");
            //        break;
            //    case 5:
            //        Console.WriteLine("Saturday");
            //        break;
            //    case 6:
            //        Console.WriteLine("Sunday");
            //        break;

            //}

            /////////////////////////////////////////////////////////////////////
            ///
            // Enter two numbers and choose a function you wish to calculate

            //Console.WriteLine("Enter the first whole number!");
            //int firstNumber = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the second whole number!");
            //int secondNumber = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Which function do you want? +, -, * or /");
            //char function = char.Parse(Console.ReadLine());

            //if (function == '+')
            //{
            //    Console.WriteLine("Addition of those numbers is  " + (firstNumber + secondNumber));
            //}
            //else if (function == '-')
            //{
            //    Console.WriteLine("Subtraction of those numbers is " + (firstNumber - secondNumber));
            //}
            //else if (function == '*')
            //{
            //    Console.WriteLine("Multiplication of those numbers is " + (firstNumber * secondNumber));
            //}
            //else if (function == '/')
            //{
            //    Console.WriteLine("Division of those numbers is " + (firstNumber / secondNumber));
            //}
            //else
            //{
            //    Console.WriteLine("Unknown function");
            //}

            ///////////////////////////////////////////////////////////////////////////////

            //Odd numbers from 0 to 20 in a for loop

            //Console.WriteLine("Odds");
            //for (int i = 0; i <= 20; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //Numbers divisible by 3 in a for loop using modulo

            //Console.WriteLine("Numbers divisible by 3");
            //for (int i = 1; i < 100; i++)
            //{
            //    if (i % 3 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            ///////////////////////////////////


            /* Creating an ArrayList, entering 3 strings and looping
             through the list using different loops */


            string car;
            ArrayList cars = new ArrayList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a car ");
                car = (Console.ReadLine());
                cars.Add(car);
            }
            Console.WriteLine("List you have entered: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(cars[i]);

            }

            Console.WriteLine("List you have entered backwards: ");
            for (int i = cars.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(cars[i]);
            }

            Console.WriteLine("Foreach list: ");
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }








            Console.ReadLine();

        }
    }
}
