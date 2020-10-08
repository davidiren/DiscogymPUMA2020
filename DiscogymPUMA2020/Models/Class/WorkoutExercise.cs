using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class WorkoutExercise
    {
        public WorkoutExercise() { }

        public int Id { get; set; }
        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }
        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
