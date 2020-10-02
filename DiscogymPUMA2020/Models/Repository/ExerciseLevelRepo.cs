using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class ExerciseLevelRepo : IExerciseLevelRepo
    {
        protected readonly Context context;
        public ExerciseLevelRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<ExerciseLevel> GetExerciseLevels => context.ExerciseLevel;

        public ExerciseLevel GetExerciseLevel(int id)
        {
            ExerciseLevel exerciseLevel = context.ExerciseLevel.Find(id);
            return exerciseLevel;
        }
    }
}
