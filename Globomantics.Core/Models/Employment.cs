using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class Employment : IValidatableObject
    {
        public string CurrentType { get; set; }
        public string CurrentEmployerName { get; set; }
        public double? CurrentAnnualIncome { get; set; }
        public int CurrentDuration { get; set; }

        public string PreviousType { get; set; }
        public string PreviousEmployerName { get; set; }
        public double? PreviousAnnualIncome { get; set; }
        public string PreviousDuration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (CurrentDuration < 2)
            {
                if (String.IsNullOrWhiteSpace(PreviousType) || String.IsNullOrWhiteSpace(PreviousEmployerName) || PreviousDuration == null)
                {
                    errors.Add(new ValidationResult("Previous employment required"));
                }
            }
            return errors;
        }
    }
}
