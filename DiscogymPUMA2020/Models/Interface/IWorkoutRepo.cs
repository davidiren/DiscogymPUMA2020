using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IWorkoutRepo
    {
        IEnumerable<Workout> GetWorkouts { get; }
        IEnumerable<Workout> GetWorkoutsByUser(int id);
        IEnumerable<Workout> GetWorkoutsByGym();
        Workout GetWorkout(int id);
        void AddWorkout(Workout workout);
        void RemoveWorkout(int? id);
        void UpdateWorkout(Workout workout);
    }
}
