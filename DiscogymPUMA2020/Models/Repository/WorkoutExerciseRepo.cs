﻿using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<WorkoutExercise> GetWorkoutExercises => context.WorkoutExercise;

        public void AddWorkoutExercise(WorkoutExercise workoutExercise)
        {
            context.WorkoutExercise.Add(workoutExercise);
            context.SaveChangesAsync();
        }

        public IEnumerable<WorkoutExercise> GetWorkoutExercisesByCategory(int id)
        {
            return context.WorkoutExercise.Where(r => r.Exercise.CategoryId == id)
                .Include(r => r.Exercise);
        }

        public IEnumerable<WorkoutExercise> GetWorkoutExercisesByExercise(int id)
        {
            return context.WorkoutExercise.Where(r => r.ExerciseId == id)
                .Include(r => r.Exercise);
        }

        public IEnumerable<WorkoutExercise> GetWorkoutExercisesByWorkout(int id)
        {
            return context.WorkoutExercise.Where(r => r.WorkoutId == id)
                .Include(r => r.Workout)
                .Include(r => r.Exercise)
                    .ThenInclude(r => r.Category);
        }
    }
}
