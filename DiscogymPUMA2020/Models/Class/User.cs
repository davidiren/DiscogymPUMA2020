using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class User
    {
        public User()
        {
            FavoriteExercises = new HashSet<FavoriteExercise>();
            Plans = new HashSet<Plan>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string Pswd { get; set; }
        public string Name { get; set; }
        [ForeignKey("ExerciseGoal")]
        public int ExerciseGoalId { get; set; }
        [ForeignKey("ExerciseLevel")]
        public int ExerciseLevelId { get; set; }

        public virtual ExerciseGoal ExerciseGoal { get; set; }
        public virtual ExerciseLevel ExerciseLevel { get; set; }
        public virtual ICollection<FavoriteExercise> FavoriteExercises { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<Log> Logs { get; set; }

    }
}
