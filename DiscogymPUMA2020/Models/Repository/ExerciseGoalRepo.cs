using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class ExerciseGoalRepo : IExerciseGoalRepo
    {
        protected readonly Context context;

        public ExerciseGoalRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<ExerciseGoal> GetExerciseGoals => throw new NotImplementedException();

        public ExerciseGoal GetExerciseGoal(int id)
        {
            throw new NotImplementedException();
        }
    }
}
