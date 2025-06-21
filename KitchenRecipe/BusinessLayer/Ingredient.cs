using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Quantity { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        private Ingredient() { }

        public Ingredient(string name, string quantity, int recipeId)
        {
            Name = name;
            Quantity = quantity;
            RecipeId = recipeId;
        }
    }
}
