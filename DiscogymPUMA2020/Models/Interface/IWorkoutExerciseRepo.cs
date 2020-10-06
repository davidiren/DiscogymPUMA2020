using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IWorkoutExerciseRepo
    {
        IEnumerable<WorkoutExercise> GetWorkoutExercises { get; }
        IEnumerable<WorkoutExercise> GetWorkoutExercisesByWorkout(int id);
        IEnumerable<WorkoutExercise> GetWorkoutExercisesByExercise(int id);
    }
}
