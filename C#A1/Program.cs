using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace C_A1
{
    internal class Program //---This class contains the main method, defines crucial dependencies between classes and controls the basic flow of the program.
    {
        public Program()
        {
            Console.Title = "Programming in C# - A1";
        }
        static void Main(string[] args) //---Creates an instance of the program-class and adds itself as an argument when calling DefineDependencies
        {
            Program program = new();

            program.DefineDependencies(program);
        }

        public void DefineDependencies(Program program) //---Defines crucial dependencies between classes.
        {
            InputValidation validation = new();
            TicketSeller ticketSeller = new();
            Vegetables veg = new(validation);
            Operations operations = new(validation, ticketSeller);

            program.Menu(validation, operations, veg); //---Calls Menu() to initiate the UI
        }

        public void Menu(InputValidation validation, Operations operations, Vegetables veg)
        {
            while (true) //---A switch-statement within a while-loop for the user to navigate.
            {
                Console.Clear();
                Console.WriteLine("Please choose what you want to do:");
                Console.WriteLine("1. Register a pet");
                Console.WriteLine("2. See all pets");
                Console.WriteLine("3. Delete a pet's data");
                Console.WriteLine("4. Buy tickets to the Zoo");
                Console.WriteLine("5. Register an album");
                Console.WriteLine("6. See all albums");
                Console.WriteLine("7. Delete an album");
                Console.WriteLine("8. Calculate your growing season");
                Console.WriteLine("9. Close the application");

                int choice;

                choice = validation.ValidateIntInput("Menu Choice");

                switch (choice) //---All cases except 8. calls methods from the Operation-class
                {
                    case 1:
                        operations.AddPet();
                        break;

                    case 2:
                        operations.DisplayPets();
                        Console.WriteLine("Press enter to make a new choice");
                        Console.ReadLine();
                        break;

                    case 3:
                        operations.DeletePet();
                        Console.WriteLine("Press enter to make a new choice");
                        Console.ReadLine();
                        break;

                    case 4:
                        operations.BuyTickets();
                        break;

                    case 5:
                        operations.AddAlbum();
                        break;

                    case 6:
                        operations.DisplayAlbums();
                        Console.WriteLine("Press enter to make a new choice");
                        Console.ReadLine();
                        break;

                    case 7:
                        operations.DeleteAlbum();
                        Console.WriteLine("Press enter to make a new choice");
                        Console.ReadLine();
                        break;

                    case 8:
                        veg.PopulateVegDatabase();
                        break;

                    case 9:
                        operations.CloseApp();
                        break;
                }
            }
        }
    }
}
