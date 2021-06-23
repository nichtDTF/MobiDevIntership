/*
 * Task 1
 * Order in Online Shop
 *
 * by Chuev Oleg
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        /// <summary>
        /// Order items array
        /// </summary>
        protected static List<float> OrderItems = new List<float>();

        /// <summary>
        /// Discounts in percent
        /// </summary>
        protected static List<float> Discounts = new List<float>();

        /// <summary>
        /// Result sum
        /// </summary>
        private static float TotalSum;

        /// <summary>
        /// Input values
        /// </summary>
        private static float Input(string str)
        {
            Console.WriteLine("Input values of " + str);
            float tmp = 0;

            try
            {
                tmp = Convert.ToSingle(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"User input not a number; To the {str} will be added 0\n");
            }
            return tmp;
        }

        /// <summary>
        /// Method for calculating
        /// </summary>
        /// <returns></returns>
        private static bool Calculate()
        {
            if (OrderItems.Count == Discounts.Count)
            {
                int i = 0;
                foreach (var elem in OrderItems)
                {
                    TotalSum += elem - Convert.ToSingle(Discounts[i] * (elem * 0.01));
                    i++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for output data
        /// </summary>
        private static void Ouput(List<float> or, List<float> ds)
        {
            Console.Write("\nOrder: ");

            foreach (var el in or)
            {
                Console.Write($"[{el}] ");
            }

            Console.Write("\nDiscount: ");

            foreach (var elem in ds)
            {
                Console.Write($"[{elem}] ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method for clear all data
        /// </summary>
        private static void Clear()
        {
            OrderItems.Clear();
            Discounts.Clear();
            TotalSum = 0;
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void  Main(string[] args)
        {
            Console.WriteLine("1 - Add order\n" +
                              "2 - Add discount\n" +
                              "3 - Calculate\n" +
                              "4 - Output\n" +
                              "5 - Clear\n");

            for (;;)
            {
                string key = "";
                Console.WriteLine("Input key: ");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1": OrderItems.Add(Input("Order")); break;
                    case "2": Discounts.Add(Input("Discount")); break;
                    case "3": 
                            if(Calculate() == true)
                                Console.WriteLine($"Total sum: {TotalSum}");
                            else
                                Console.WriteLine($"User don`t add enough discounts or orders.\n");
                            break;
                    case "4": Ouput(OrderItems, Discounts); break;
                    case "5": Clear(); break;
                    default: Console.WriteLine("Wrong key"); break;
                }
            }

        }
    }
}
