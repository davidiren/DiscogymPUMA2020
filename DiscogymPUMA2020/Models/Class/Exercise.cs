using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Exercise
    {
        public Exercise()

            {

            }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ExerciseLevelId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string Video { get; set; }

        public virtual Category Category { get; set; }
        public virtual ExerciseLevel ExerciseLevel { get; set; }

    }
}
