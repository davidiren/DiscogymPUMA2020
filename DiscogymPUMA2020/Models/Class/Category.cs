using System;
using System.Collections.Generic;
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

        public virtual ICollection<Exercise> Exercises { get; set; }
    }    
}
