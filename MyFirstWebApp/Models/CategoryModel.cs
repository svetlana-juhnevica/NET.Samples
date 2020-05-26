using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class CategoryModel
    {
        
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name="Name: ")]
        public string Name { get; set; }
    }
}
