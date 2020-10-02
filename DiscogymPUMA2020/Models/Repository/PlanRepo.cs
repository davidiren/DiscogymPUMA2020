using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Plan> GetPlans => context.Plan;

        public void AddPlan(Plan plan)
        {
            context.Plan.Add(plan);
            context.SaveChangesAsync();
        }

        public Plan GetPlan(int id)
        {
            Plan plan = context.Plan.Find(id);
            return plan;
        }

        public IEnumerable<Plan> GetPlansByUser(int id)
        {
            return context.Plan.Where(r => r.UserId == id)
                .Include(r => r.User);
        }

        public IEnumerable<Plan> GetPlansByWorkout(int id)
        {
            return context.Plan.Where(r => r.WorkoutId == id)
                .Include(r => r.Workout);
        }

        public void RemovePlan(int? id)
        {
            Plan plan = context.Plan.Find(id);
            context.Plan.Remove(plan);
            context.SaveChangesAsync();
        }

        public void UpdatePlan(Plan plan)
        {
            context.Plan.Update(plan);
            context.SaveChangesAsync();
        }
    }
}
