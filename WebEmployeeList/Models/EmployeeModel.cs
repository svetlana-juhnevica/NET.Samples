using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEmployeeList.Models
{
    public class EmployeeModel
    {

        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Surname: ")]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Year of birth: ")]
        public string BirthYear { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Department: ")]

        public string Department { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Position: ")]
        public string Position { get; set; }

       
    }
}

    

