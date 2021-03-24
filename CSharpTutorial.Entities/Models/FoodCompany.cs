using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpTutorial.Entities.Models
{
    public class FoodCompany
    {
        [Key]
        public Guid FoodCompanyID { get; set; }

        [Required]
        public string FoodCompanyName { get; set; }
    }
}
