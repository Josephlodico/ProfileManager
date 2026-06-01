using ProfileManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileManager.Validators
{
    public class NameValidator : IValidator
    {
        private readonly int _maxLength;

        public NameValidator(int maxLenght)
        {
            _maxLength = maxLenght;
        }

        public bool IsValid(string input)
        {
            //Check if empty
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Name cannot be empty.");
                return false;
            }

            if (input.Length > _maxLength)
            {
                Console.WriteLine($"Name cannot be more than {_maxLength} characters long.");
                return false;
            }
            return input.All(char.IsLetter);
        }
    }
}
