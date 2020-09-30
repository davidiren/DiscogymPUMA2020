using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Plan
    {
        public Plan()
        {

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int WorkoutId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
