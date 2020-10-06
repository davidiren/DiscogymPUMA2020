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
            User = new HashSet<User>();
            Exercise = new HashSet<Exercise>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Exercise> Exercise { get; set; }
    }
}
