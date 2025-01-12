using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class InputValidation //---Holds helper-methods for validating input
    {

        public string ValidateStringInput(string question) //---Helper method for all methods in this program that have to process string-input.
        {                                                  //---Takes a string "question" as argument to format how the question for input is asked in the console.
            string? input;

            while (true)
            {
                Console.WriteLine(question + ":");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) == true)
                {
                    Console.WriteLine(question + " can not be null");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
                if (int.TryParse(input, out int val) == true)
                {
                    Console.WriteLine(question +" has to be valid string");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }

                return input;
                
            }
        }

       public int ValidateIntInput(string question) //---Helper method for all methods in this program that have to handle int-input.
        {                                           //---Takes a string "question" as argument to format how the question for input is asked in the console.
            string? inputAsString;

            while (true)
            {
                Console.WriteLine(question +":");
                inputAsString = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputAsString) == true)
                {
                    Console.WriteLine(question + " can not be null");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
                if (int.TryParse(inputAsString, out int input) == true)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine(question + " has to be a valid integer");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        public bool ValidateGenderInput(string species) //---Helpter method to assign gender to an instance of Pet
        {                                               //---Takes a string "species" as argument to format the prints to the console.
            string? gender;
            bool isFemale;

            while (true)
            {
                Console.WriteLine("Is your " + species + " female? y/n");
                gender = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(gender) == true)
                {
                    Console.WriteLine("Answer has to be a y/n");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
                if (int.TryParse(gender, out int val) == true)
                {
                    Console.WriteLine("Answer can not be an integer");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
                if (gender == "y")
                {
                    isFemale = true;
                    return isFemale;
                }
                if (gender == "n")
                {
                    isFemale = false;
                    return isFemale;
                }
            }
        }
    }
}
