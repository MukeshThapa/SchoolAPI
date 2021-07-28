using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required*")]


        [Display(Name = "Standard")]

        public int StandardRefId { get; set; }
        //[ForeignKey("StandardRefId")]
        //public Standard Standard { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string Mobile { get; set; }

        public string Description { get; set; }

    }
}
