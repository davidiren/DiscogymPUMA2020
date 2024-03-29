﻿using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Workout> GetWorkouts => context.Workout;

        public void AddWorkout(Workout workout)
        {
            context.Workout.Add(workout);
            context.SaveChangesAsync();
        }

        public Workout GetWorkout(int id)
        {
            return context.Workout.Include(r => r.WorkoutExercises).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Workout> GetWorkoutsByGym(bool gym)
        {
            return context.Workout.Where(r => r.Gym == gym).Include(r => r.WorkoutExercises);
        }

        public IEnumerable<Workout> GetWorkoutsByName(int? id, string name)
        {
            var w = context.Workout.Where(r => r.CreatedByUserId == id)
                                   .Where(r => r.Name == name)
                                   .Include(r => r.WorkoutExercises);
            context.SaveChangesAsync();
            return w;
        }

        public IEnumerable<Workout> GetWorkoutsByUser(int id)
        {
            return context.Workout.Where(r => r.CreatedByUserId == id)
                .Include(r => r.User);
        }

        public void RemoveWorkout(int? id)
        {
            Workout workout = context.Workout.Find(id);
            context.Workout.Remove(workout);
            context.SaveChangesAsync();
        }

        public void UpdateWorkout(Workout workout)
        {
            context.Workout.Update(workout);
            context.SaveChangesAsync();
        }
    }
}
