using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class WorkoutExerciseRepo : IWorkoutExerciseRepo
    {
        protected readonly Context context;
        public WorkoutExerciseRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<WorkoutExercise> GetWorkoutExercises => throw new NotImplementedException();

        public WorkoutExercise GetWorkoutExercise(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkoutExercise> GetWorkoutExercisesByExercise(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkoutExercise> GetWorkoutExercisesByWorkout(int id)
        {
            throw new NotImplementedException();
        }
    }
}
