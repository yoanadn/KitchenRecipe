using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Range(1, 1440)]
        public int PreparationTime { get; set; }

        [Range(1, 100)]
        public int Servings { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        protected Recipe()
        {
            Ingredients = new List<Ingredient>();
            Tags = new List<Tag>();
        }

        public Recipe(string title, string instructions, int preparationTime, int servings, int categoryId)
        {
            Title = title;
            Instructions = instructions;
            PreparationTime = preparationTime;
            Servings = servings;
            CategoryId = categoryId;
            Ingredients = new List<Ingredient>();
            Tags = new List<Tag>();
        }
    }
}
