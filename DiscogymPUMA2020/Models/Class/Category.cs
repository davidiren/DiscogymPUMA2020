using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Category
    {
        public Category()
        {
            Exercises = new HashSet<Exercise>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }    
}
