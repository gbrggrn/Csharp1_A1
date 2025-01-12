using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class Operations //---Holds the main logic for all cases except Vegetables (case 8)
    {
        private List<Pet> pets = new List<Pet>();
        private List<Album> albums = new List<Album>();
        private readonly InputValidation validation;
        private readonly TicketSeller ticketSeller;

        public Operations(InputValidation validation, TicketSeller ticketSeller) //---Allows the Operations class to access both InputValidation-, and TicketSeller-class methods.
        {
            this.validation = validation;
            this.ticketSeller = ticketSeller;
        }

        public void AddPet() //---Holds logic to add a pet to the list
        {
            Console.Clear();

            string species;
            string name;
            int age;
            bool isFemale;

            Console.WriteLine("+++ Add a Pet +++");

            species = validation.ValidateStringInput("Species");
            name = validation.ValidateStringInput("Name");
            age = validation.ValidateIntInput("Age");
            isFemale = validation.ValidateGenderInput(species);

            Pet pet = new(species, name, age, isFemale); //---Creates a new instance of pet with the input previously entered

            pets.Add(pet); //---Adds the instance of pet to the list pets

            Console.WriteLine();
            Console.WriteLine(name + " the " + species + " has been added to the list.");
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        public void DisplayPets() //---Holds logic to display all registered pets
        {
            if (ListCounter(pets, "pets") == true)
            {
                return;
            }

            foreach (var pet in pets) //---Iterate through each saved instance of pet in the list and print formatted data
            {
                Console.WriteLine();
                Console.WriteLine(pet.GetPrintFormatPet());
                Console.WriteLine();
            }
        }

        public void DeletePet() //---Holds logic to delete an instance of pet from the list
        {
            Console.Clear();

            if (ListCounter(pets, "pets") == true)
            {
                return;
            }

            DisplayPets();

            Console.WriteLine("Please enter the name of the pet you wish to remove");

            string petToDelete = validation.ValidateStringInput("Name");

            for (int i = 0; i < pets.Count; i++) //---Iterates through pets-list
            {
                if (pets[i].GetPetName() == petToDelete) //---Checks the name of each instance to match the input
                {
                    pets.Remove(pets[i]); //---Input matches name of an instance, that instance of pet is removed from the list
                    Console.WriteLine(petToDelete + " has been removed");
                    return;
                }
            }

            Console.WriteLine();
            Console.WriteLine("There is no pet named " + petToDelete);
        }

        public void BuyTickets() //---Holds logic to buy tickets.
        {
            Console.Clear();

            string name;
            int numOfAdults;
            int numOfChildren;

            Console.WriteLine();
            Console.WriteLine("+++ Buy Zoo Tickets +++");
            Console.WriteLine("Adults: 2.50$");
            Console.WriteLine("Children 20% discount");
            Console.WriteLine();

            name = validation.ValidateStringInput("Name");
            numOfAdults = validation.ValidateIntInput("How many adults");
            numOfChildren = validation.ValidateIntInput("How many children");

            ticketSeller.CalculatePrice(name, numOfAdults, numOfChildren);

            Console.Clear();

            Console.WriteLine("+++ Your receipt +++");
            Console.WriteLine(ticketSeller.ReceiptPrintFormat());
            Console.WriteLine("Thank you " + name + "! Enjoy the Zoo!");
            Console.WriteLine();
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        public void AddAlbum() //---Holds logic to save an album to a list, basically works the same as AddPet().
        {
            Console.Clear();

            string albumName;
            string artistName;
            int numOfTracks;

            Console.WriteLine();
            Console.WriteLine("+++ Add a New Album +++");
            Console.WriteLine();

            albumName = validation.ValidateStringInput("Album Title");
            artistName = validation.ValidateStringInput("Artist Name");
            numOfTracks = validation.ValidateIntInput("Number of tracks");

            Album album = new(albumName, artistName, numOfTracks);

            albums.Add(album);

            Console.WriteLine();
            Console.WriteLine(albumName + " by " + artistName + " has been added.");
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        public void DisplayAlbums() //---Holds logic to print the album-list. Basically works the same as DisplayPets()
        {
            if (ListCounter(albums, "albums") == true)
            {
                return;
            }

            foreach (var album in albums)
            {
                Console.WriteLine();
                Console.WriteLine(album.GetPrintFormatAlbum());
                Console.WriteLine();
            }
        }

        public void DeleteAlbum() //---Holds logic to delete an album from the list. Basically works the same as DeletePet()
        {
            Console.Clear();

            if (ListCounter(albums, "albums") == true)
            {
                return;
            }

            DisplayAlbums();

            Console.WriteLine("Please enter the name of the album you wish to remove: ");

            string removeTitle = validation.ValidateStringInput("Album Name");

            for (int i = 0; i < albums.Count; i++)
            {
                if (albums[i].GetAlbumTitle() == removeTitle)
                {
                    albums.Remove(albums[i]);
                    Console.WriteLine("The album " + removeTitle + " has been removed");
                    return;
                }
            }

            Console.WriteLine("There is no album with the title " + removeTitle);
        }

        public void CloseApp() //---Logic for closing the app.
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to exit the application?");
                Console.WriteLine("y/n");

                string closeOrNot = validation.ValidateStringInput("Answer");

                if (closeOrNot == "y" || closeOrNot == "n")
                {
                    if (closeOrNot == "y")
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }

                    if (closeOrNot == "n")
                    {
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Answer has to be y/n");
                    Console.WriteLine("Press enter to try again");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        public bool ListCounter<T>(List<T> list, string message)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("There are no registered " + message + " yet!");
                return true;
            }

            return false;
        }
    }
}
