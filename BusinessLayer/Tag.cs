using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        protected Tag()
        {
            Recipes = new List<Recipe>();
        }

        public Tag(string name)
        {
            Name = name;
            Recipes = new List<Recipe>();
        }
    }
}
