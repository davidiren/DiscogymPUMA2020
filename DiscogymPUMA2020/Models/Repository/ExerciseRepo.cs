using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Exercise> GetExercises => context.Exercise;

        public Exercise GetExercise(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetExercisesByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetExercisesByLevel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
