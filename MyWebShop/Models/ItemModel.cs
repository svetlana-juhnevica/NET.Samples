using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebShop.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Item name: ")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Category Id: ")]
        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price, $: ")]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Item description: ")]
        public string Description { get; set; }
        
        public string Image { get; set; }
    }
}
