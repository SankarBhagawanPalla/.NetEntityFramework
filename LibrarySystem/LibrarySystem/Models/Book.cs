using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter Book name")]
        [Display(Name = "Name")]
        [CustomValidation(typeof(Book), "BookNameValidation")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter author")]
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }

        public static ValidationResult BookNameValidation(string name, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Book;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(LibrarySystemContext)) as LibrarySystemContext;
            int duplicateCount = dbContext.Book
                                          .Count(x => x.BookId != instance.BookId && x.Name == name);
            if (duplicateCount > 0)
            {
                return new ValidationResult($"Book Name {name} already exists");
            }
            return ValidationResult.Success;
        }

    }
}
