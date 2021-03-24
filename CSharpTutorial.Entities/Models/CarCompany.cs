using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharpTutorial.Entities.Models
{
    public class CarCompany
    {
        [Key]
        public Guid CarID { get; set; }

        [Required]
        public string CarCompanyName { get; set; }

        [ForeignKey("PersonEntity")]
        public Guid PersonEntityID { get; set; }
        public PersonEntity PersonEntity{get; set;}
    }
}
