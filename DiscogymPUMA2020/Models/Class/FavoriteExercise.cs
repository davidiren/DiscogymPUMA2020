using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class FavoriteExercise
    {
        public FavoriteExercise(){ }

        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public virtual User User { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
