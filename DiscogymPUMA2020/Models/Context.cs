using DiscogymPUMA2020.Models.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseGoal> ExerciseGoal { get; set; }
        public DbSet<FavoriteExercise> FavoriteExercise { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Mood> Mood { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercise { get; set; }

    }
}
