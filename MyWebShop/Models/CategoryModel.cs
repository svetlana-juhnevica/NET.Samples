using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebShop.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Category name: ")]
        public string Name { get; set; }

        
        [Display(Name = "Parent Id: ")]
        public int? ParentId { get; set; }
        public int ItemCount { get; set; }
    }
}
