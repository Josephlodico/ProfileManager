using ProfileManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Validators
{
    public class TextValidator: IValidator
    {
        public bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
