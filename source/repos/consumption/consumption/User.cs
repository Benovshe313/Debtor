using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumption
{
    internal class User
    {
        
        public string Name {  get; set; }
        public double Weight {  get; set; }
        public static double todayDrunk { get; set; } = 0;
        public static double NextDayDrunk { get; set; } = 0;
        public static double TheNextDayDrunk { get; set; } = 0;
        public User(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public static double validWeight()
        {
            double weight;
            while (true)
            {
                //Console.Write("Weight: ");
                string input = Console.ReadLine();
                try
                {
                    if (double.TryParse(input, out weight) && weight > 0)
                    {
                        break;
                    }
                    else
                    {
                        throw new FormatException("Invalid input. Enter valid number");
                    }
                }
                catch (FormatException ex) { 
                    Console.WriteLine(ex.Message);
                
                }
            }
            return weight;
        }

        public static double validAmount()
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    double amount = double.Parse(input);
                    return amount;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Enter valid amount");
                }
            }
        }

        
    }

    
}
