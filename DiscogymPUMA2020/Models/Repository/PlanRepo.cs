using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class PlanRepo : IPlanRepo
    {
        protected readonly Context context;
        public PlanRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Plan> GetPlans => throw new NotImplementedException();

        public void AddPlan(Plan plan)
        {
            throw new NotImplementedException();
        }

        public Plan GetPlan(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plan> GetPlansByUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plan> GetPlansByWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePlan(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlan(Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
