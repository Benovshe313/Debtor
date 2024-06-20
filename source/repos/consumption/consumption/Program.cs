namespace consumption
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\User\Desktop\water_consumption.txt";
            string name = "";
            double weight = 0;

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    name = sr.ReadLine();
                    double.TryParse(sr.ReadLine(), out weight);
                }
            }
            else
            {
                Helper.SaveNameAndWeight(filePath, ref name, ref weight);
            }



            Console.WriteLine($"Welcome {name}!");

        
            DateTime currentDate = DateTime.Now;
            
            

            while (true)
            {
                var todayDrunk2 = Helper.GetTodayWaterIntake(currentDate);

                Console.Write("Date: ");
                Console.WriteLine(currentDate.ToString("dd/MM/yyyy"));


                Console.WriteLine($"Daily norm: {Helper.FindDailyNorm(weight)} l");
                Console.WriteLine($"Today: {todayDrunk2} l");

                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Drink water");
                Console.WriteLine("2. History");
                Console.WriteLine("3. End of day");
                Console.WriteLine("4. Exit");

                Console.Write("Make choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter amount of water you drink: ");
                    double todayInput = User.validAmount();
                    User.todayDrunk += todayInput;
                    Helper.SaveDailyConsumption(currentDate, User.todayDrunk);

                }
                else if (choice == "2")
                {
                    Helper.PrintAllRecords();

                    //Console.WriteLine(currentDate.ToString("dd/MM/yyyy"));
                    //Console.WriteLine($"Amount of water you drank: {User.todayDrunk} l");

                    //if(currentDate == currentDate.AddDays(1))
                    //{
                    //    Console.WriteLine(currentDate.AddDays(1).ToString("dd/MM/yyyy"));
                    //    Console.WriteLine($"Amount of water you drank: {User.NextDayDrunk} l");
                    //}

                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    if (Helper.FindDailyNorm(weight) < User.todayDrunk)
                    {
                        Console.WriteLine("You drank more than norm");
                    }
                    else if (Helper.FindDailyNorm(weight) > User.todayDrunk)
                    {
                        Console.WriteLine("You didn't drink enough water");
                    }
                    else
                    {
                        Console.WriteLine("You drank enough water");
                    }
                    //Helper.SaveDailyConsumption(currentDate, User.todayDrunk);
                    currentDate = currentDate.AddDays(1);
                    User.todayDrunk = 0;

                }
                else if (choice == "4") 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Make a choice again");
                }

            }
        }
    }

}
