using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IPlanRepo
    {
        IEnumerable<Plan> GetPlans { get; }
        IEnumerable<Plan> GetPlansByWorkout(int id);
        IEnumerable<Plan> GetPlansByUser(int id);
        IEnumerable<Plan> GetPlansByDate(DateTime dateTime);
        Plan GetPlan(int id);
        void AddPlan(Plan plan);
        void RemovePlan(int? id);
        void UpdatePlan(Plan plan);
    }
}
