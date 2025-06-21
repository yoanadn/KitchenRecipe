using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        protected Category()
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
