using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        private Category()
        {
            Recipes = new List<Recipe>();
        }

        public Category(string name)
        {
            Name = name;
            Recipes = new List<Recipe>();
        }
    }
}
