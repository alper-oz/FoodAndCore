using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndCore.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public double Price { get; set; }
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}
