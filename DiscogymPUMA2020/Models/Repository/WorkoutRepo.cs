using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class WorkoutRepo : IWorkoutRepo
    {
        protected readonly Context context;
        public WorkoutRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Workout> GetWorkouts => throw new NotImplementedException();

        public void AddWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        public Workout GetWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Workout> GetWorkoutsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveWorkout(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }
    }
}
