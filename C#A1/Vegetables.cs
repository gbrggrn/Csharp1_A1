using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class Vegetables //---This class holds data and methods to calculate a possible harvesting date for specific vegetables.
    {
        private readonly Dictionary<string, int> vegInventory; //---Defines a Dictionary where each position holds a string and an int (vegetable, days from planting to harvest).
        private readonly InputValidation validation;

        public Vegetables(InputValidation validation) //---Constructor initiates the Dictionary and calls a method to populate it with data.
        {
            this.vegInventory = new Dictionary<string, int>();
            this.validation = validation;
        }
        
        public void PopulateVegDatabase() //---Populates the dictionary, then calls VegetableOperations()
        {
            vegInventory.Add("Beets", 50);
            vegInventory.Add("Broccoli", 60);
            vegInventory.Add("Cabbage", 90);
            vegInventory.Add("Carrot", 65);
            vegInventory.Add("Cauliflower", 70);
            vegInventory.Add("Cucumber", 55);
            vegInventory.Add("Eggplant", 75);
            vegInventory.Add("Kohlrabi", 58);
            vegInventory.Add("Lettuce", 50);

            VegetableOperations();
        }

        public void VegetableOperations() //---Clears the console and initiates the main flow of this little app
        {
            Console.Clear();
            Console.WriteLine("+++ Let's Grow Vegetables! +++");

            DisplayVeg();

            SearchVeg();
        }

        public void DisplayVeg() //---Iterates through the dictionary and prints the vegetables names
        {
            foreach (var veg in vegInventory.Keys)
            {
                Console.WriteLine($"{veg}");
            }
        }
        
        public void SearchVeg() //---Holds the search-functionality and the planting-to-harvest logic.
        {
            string searchedVeg;
            int days;
            DateTime plantTime;

            while (true) 
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the name of the vegetable you would like to grow");

                searchedVeg = validation.ValidateStringInput("Vegetable");

                if (vegInventory.ContainsKey(searchedVeg)) //---Check if Dictionary contains searchedVeg
                {
                    days = vegInventory.GetValueOrDefault(searchedVeg); //---Assigns the value connected to the searched vegetable to variable "days"
                    Console.WriteLine();
                    Console.WriteLine("Let's see when " + searchedVeg + " can be ready for harvest!");
                    break;
                }
                else
                {
                    Console.WriteLine("Could not find a vegetable named " + searchedVeg);
                    Console.WriteLine("Press enter to try again");
                    Console.ReadLine();
                    continue;
                }
           
            }

            while (true)
            {
                 Console.WriteLine("Please enter date of planting:");
                 Console.WriteLine("Date MM/DD/YYYY:");
                 string? plantDate = Console.ReadLine();

                 if (DateTime.TryParse(plantDate, out plantTime) == false) //---Tries to parse input(plantDate) as DateTime, if successful saves it to plantTime
                 {
                      Console.WriteLine("Invalid date format");
                      Console.WriteLine("Press enter to try again");
                      Console.ReadLine();
                      continue;
                 }

                 break;
            }

            DateTime harvestDate = plantTime.AddDays(days); //---New variable harvestDate of type DateTime declared and initiated with the (time of planting) + (number of days to harvest)

            Console.WriteLine();
            Console.WriteLine("Your " + searchedVeg + " should be ready for harvest in " + days + " days by " + harvestDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Press Enter to return to the main menu");
            Console.ReadLine();
            return;
        }
    }
}
