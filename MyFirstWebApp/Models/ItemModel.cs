using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class ItemModel
    {
        
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }
        [Required]
       
        [Display( Name= "Price, $: ")]
        public int Price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Description = "Description: ")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Location: ")]

        public string Location { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Category: ")]

        public string CategoryName { get; set; }
        public CategoryModel Category { get; set; }
    }
}
