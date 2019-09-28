using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please provide a Destination name")]
        [StringLength(30, MinimumLength = 2)]
        [CustomValidation(typeof(Destination), "DestinationNameValidation")]
        public string Name { get; set; }
        [RegularExpression(@"^[\d]{5}$", ErrorMessage = "Enter valid zipcode")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [CustomValidation(typeof(Destination), "VaidateFutureTravelDate")]
        [DataType(DataType.Date)]
        [Display(Name = "Travel Date")]
        public DateTime? TravelDate { get; set; }
        [Display(Name = "Flight Service Availability")]
        public bool IsFlightServiceAvailable { get; set; }
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Enter numericals only")]
        [Display(Name = "Total Fair")]
        public decimal TotalFair { get; set; }
        [Display(Name = "Rating")]
        public int Rating
        {
            get
            {
                if (TotalFair < 150)
                {
                    return 5;
                }
                if (150 <= TotalFair && TotalFair < 250)
                {
                    return 4;
                }
                if (250 <= TotalFair && TotalFair < 300)
                {
                    return 3;
                }
                if (300 <= TotalFair && TotalFair < 350)
                {
                    return 2;
                }
                if (350 <= TotalFair)
                {
                    return 1;
                }
                return 0;
            }
        }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public Country Location { get; set; }

        public static ValidationResult VaidateFutureTravelDate(DateTime? travelDate, ValidationContext context)
        {
            if (travelDate == null)
            {
                return ValidationResult.Success;
            }
            var allowedDate = DateTime.Today.AddYears(1);
            if (DateTime.Today <= travelDate && travelDate < allowedDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(errorMessage: $"Travel date must be within {allowedDate.ToShortDateString()}");
        }

        public static ValidationResult DestinationNameValidation(string name, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Destination;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(CoreCrudContext)) as CoreCrudContext;
            int duplicateCount = dbContext.Destination
                                          .Count(x => x.Id != instance.Id && x.Name == name);
            if (duplicateCount > 0)
            {
                return new ValidationResult($"Name {name} already exists");
            }
            return ValidationResult.Success;
        }

    }
}
