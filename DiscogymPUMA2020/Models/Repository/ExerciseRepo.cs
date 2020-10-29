using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class ExerciseRepo : IExerciseRepo
    {
        protected readonly Context context;
        public ExerciseRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Exercise> GetExercises => context.Exercise.Include(r => r.Category);

        public Exercise GetExercise(int? id)
        {
           var e =  context.Exercise.Include(r => r.Category)
                .Include(r => r.ExerciseLevel)
                .FirstOrDefault(m => m.Id == id);
            context.SaveChangesAsync();
            return e;
        }

        public IEnumerable<Exercise> GetExercisesByCategory(int id)
        {
            return context.Exercise.Where(r => r.CategoryId == id)
                .Include(r => r.Category).Include(r => r.ExerciseLevel);
        }

        public IEnumerable<Exercise> GetExercisesByLevel(int id)
        {
            return context.Exercise.Where(r => r.LevelId == id)
                .Include(r => r.ExerciseLevel);
        }
    }
}
