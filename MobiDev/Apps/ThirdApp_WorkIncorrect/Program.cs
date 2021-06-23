using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdApp
{
    class Program
    {
        /// <summary>
        /// Creating towns
        /// </summary>
        public static Town Lubeck;
        public static Town Reval;
        public static Town Bergen;
        
        /// <summary>
        /// Set data to towns
        /// </summary>
        protected static void SetData()
        {
            //Lubeck data
            Lubeck.res[0].cost = 20;
            Lubeck.res[0].type = "salt";

            Lubeck.res[1].cost = 50;
            Lubeck.res[1].type = "fish";

            Lubeck.res[2].cost = 60;
            Lubeck.res[2].type = "cloth";

            Lubeck.res[3].cost = 36;
            Lubeck.res[3].type = "copper";

            Lubeck.res[4].cost = 96;
            Lubeck.res[4].type = "furs";

            //Reval data
            Reval.res[0].cost = 35;
            Reval.res[0].type = "salt";

            Reval.res[1].cost = 50;
            Reval.res[1].type = "fish";

            Reval.res[2].cost = 40;
            Reval.res[2].type = "cloth";

            Reval.res[3].cost = 60;
            Reval.res[3].type = "copper";

            Reval.res[4].cost = 45;
            Reval.res[4].type = "furs";

            //Bergen data
            Bergen.res[0].cost = 62;
            Bergen.res[0].type = "salt";

            Bergen.res[1].cost = 15;
            Bergen.res[1].type = "fish";

            Bergen.res[2].cost = 18;
            Bergen.res[2].type = "cloth";

            Bergen.res[3].cost = 82;
            Bergen.res[3].type = "copper";

            Bergen.res[4].cost = 54;
            Bergen.res[4].type = "furs";
        }

        static void Main(string[] args)
        {
            Lubeck = new Town();
            Reval = new Town();
            Bergen = new Town();

            Traveler traveler = new Traveler();
            traveler.Money = 50;
            SetData();
            string key = "";

            //Will be batter to output this information by using class Town`s data

            Console.WriteLine($"All resources Lubeck\n"+
                                "Good prices:\n" +
                                "salt - 20 coins\n" +
                                "fish - 50 coins\n" +
                                "cloth - 60 coins\n" +
                                "copper - 36 coins\n" +
                                "furs - 96 coins\n");

            Console.WriteLine($"All resources Reval\n" +
                              "Good prices:\n" +
                              "salt - 35 coins\n" +
                              "fish - 50 coins\n" +
                              "cloth - 40 coins\n" +
                              "copper - 60 coins\n" +
                              "furs - 45 coins\n");

            Console.WriteLine($"All resources Bergen\n" +
                              "Good prices:\n" +
                              "salt - 62 coins\n" +
                              "fish - 15 coins\n" +
                              "cloth - 18 coins\n" +
                              "copper - 82 coins\n" +
                              "furs - 54 coins\n");
            for (; ;)
            {
                Console.WriteLine($"Initial coins {traveler.Money}");

                Console.WriteLine($"Enter Lubeck. Want to buy something? Y/N");
                key = Console.ReadLine();
                switch (key)
                {
                    case "Y":
                    {
                        Console.Write("Enter type of resource what you want to buy: ");

                        do
                        {
                            key = Console.ReadLine();

                            switch (key)
                            {
                                case "salt": traveler.Buy(Lubeck.res[0]); break;
                                case "copper": traveler.Buy(Lubeck.res[1]); break; ;
                                case "fish": traveler.Buy(Lubeck.res[2]); break; ;
                                case "cloth": traveler.Buy(Lubeck.res[3]); break; ;
                                case "furs": traveler.Buy(Lubeck.res[4]); break; ;
                                default: Console.WriteLine("Unknown"); break;
                            }
                        } while (traveler.HandIsEmpty);
                    } break;
                
                    case "N":
                        Console.WriteLine("Leaving Reval..."); break;
                    default: 
                        break;
                }
                Console.WriteLine($"Enter Reval");
                Console.WriteLine($"Want to sell hand? Y/N");
                key = Console.ReadLine();
                switch (key)
                {
                    case "Y": traveler.Sell(Reval); break;
                    case "N": break;
                    default:
                        break;
                }

                if(traveler.HandIsEmpty)
                {
                    Console.WriteLine($"Want to buy something? Y/N");
                    key = Console.ReadLine();
                    switch (key)
                    {
                        case "Y":
                        {
                            Console.Write("Enter type of resource what you want to buy: ");

                            do
                            {
                                key = Console.ReadLine();

                                switch (key)
                                {
                                    case "salt": traveler.Buy(Reval.res[0]); break;
                                    case "copper": traveler.Buy(Reval.res[1]); break; ;
                                    case "fish": traveler.Buy(Reval.res[2]); break; ;
                                    case "cloth": traveler.Buy(Reval.res[3]); break; ;
                                    case "furs": traveler.Buy(Reval.res[4]); break; ;
                                    default: Console.WriteLine("Unknown"); break;
                                }
                            } while (traveler.HandIsEmpty);
                        }
                            break;

                        case "N":
                            Console.WriteLine("Leaving Reval..."); break;
                        default:
                            break;
                    }
                }

                Console.WriteLine($"Enter Bergen");
                Console.WriteLine($"Want to sell hand? Y/N");
                key = Console.ReadLine();
                switch (key)
                {
                    case "Y": traveler.Sell(Bergen); break;
                    case "N": break;
                    default:
                        break;
                }

                Console.WriteLine($"Final coins {traveler.Money}");
            }



        }
    }

    /// <summary>
    /// Resource class
    /// </summary>
    class Resource : Town
    {
        /// <summary>
        /// Price
        /// </summary>
        public int cost;

        /// <summary>
        /// Type
        /// </summary>
        public string type;
    }

    /// <summary>
    /// Town class
    /// </summary>
    class Town
    {
        public  Resource[] res = new Resource[4];

        ///// <summary>
        ///// Salt cost
        ///// </summary>
        //public Resource salt;

        ///// <summary>
        ///// Fish cost
        ///// </summary>
        //public Resource fish;

        ///// <summary>
        ///// Cloth cost
        ///// </summary>
        //public Resource cloth;

        ///// <summary>
        ///// Copper cost
        ///// </summary>
        //public Resource copper;

        ///// <summary>
        ///// Furs cost
        ///// </summary>
        //public Resource furs;
    }

    /// <summary>
    /// Traveler class
    /// </summary>
    class Traveler
    {
        /// <summary>
        /// Traveler`s money
        /// </summary>
        public int Money;

        /// <summary>
        /// Resource 
        /// </summary>
        public Resource Item;

      
        /// <summary>
        /// Check is traveler`s hand empty or not
        /// </summary>
        public bool HandIsEmpty;

        /// <summary>
        /// Buy item
        /// </summary>
        public void Buy(Resource resource)
        {
            if (Money - resource.cost > 0)
            {
                HandIsEmpty = false;
                Item.cost = resource.cost;
                Item.type = resource.type.ToString();
            }
            else
                Console.WriteLine("Not enough money, you can`t buy this item");
        }

        /// <summary>
        /// Sell item
        /// </summary>
        public void Sell(Town town)
        {
            if (!HandIsEmpty)
            {
                HandIsEmpty = true;
                
                switch (Item.type)
                {
                    case "salt": Money += town.res[0].cost; break;
                    case "fish": Money += town.res[1].cost; break;
                    case "cloth": Money += town.res[2].cost; break;
                    case "copper": Money += town.res[3].cost; break;
                    case "furs": Money += town.res[4].cost; break;
                }

                Item.type = "";
            }
            else
            {
                Console.WriteLine("Your hand is empty. Just buy something");
            }
        }

        
    }
}
