using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Workout
    {
        public Workout()
        {
            Plans = new HashSet<Plan>();
            WorkoutExercises = new HashSet<WorkoutExercise>();
            FavoriteExercises = new HashSet<FavoriteExercise>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkoutTime { get; set; }
        public bool? Gym { get; set; }
        [ForeignKey("User")]
        public int CreatedByUserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public virtual ICollection<FavoriteExercise> FavoriteExercises { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
