using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IExerciseRepo
    {
        IEnumerable<Exercise> GetExercises { get; }
        IEnumerable<Exercise> GetExercisesByCategory(int id);
        IEnumerable<Exercise> GetExercisesByLevel(int id);
        Exercise GetExercise(int id);
    }
}
