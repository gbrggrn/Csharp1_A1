using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class Pet(string species, string name, int age, bool isFemale) //---Essentially a data blueprint class. Holds data for a single pet.
    {
        private readonly string Species = species;
        private readonly string Name = name;
        private readonly int Age = age;
        private readonly bool IsFemale = isFemale;
        private string? gender;

        public string GetPrintFormatPet() //---Returns a formatted string when printing the pet-list
        {

            if (IsFemale == false)
            {
                gender = "male";
            }
            if (IsFemale == true)
            {
                gender = "female";
            }

            return $"Species: { Species } \nName: { Name } \nAge: { Age  } \nGender: { gender }";
        }

        public string GetPetName() //---Returns the pet Name as a string when called
        {
            return $"{Name}";
        }
    }
}
