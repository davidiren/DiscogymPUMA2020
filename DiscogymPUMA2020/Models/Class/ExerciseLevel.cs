using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class ExerciseLevel
    {
        public ExerciseLevel()
        {
            Users = new HashSet<User>();
            Exercises = new HashSet<Exercise>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
