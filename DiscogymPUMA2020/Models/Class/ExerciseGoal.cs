using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class ExerciseGoal
    {
        public ExerciseGoal()
        {
            User = new HashSet<User>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
