using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Log
    {
        public Log()
        {

        }
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Mood")]
        public int MoodId { get; set; }
        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Mood Mood { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
