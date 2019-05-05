using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.ViewModel;

namespace InfinityTask.Helper
{
    public class DateValidation:ValidationAttribute
    {
       public DateTime PublishDate { get; set; }

       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
       {
           var newBlog = (NewBlog) validationContext.ObjectInstance;


           string errorMessage = "Date can't be lower than today";
           if (newBlog.PublishDate < DateTime.Now)
           {
               return new ValidationResult(errorMessage);
           }

           return ValidationResult.Success;
       }
    }
}
