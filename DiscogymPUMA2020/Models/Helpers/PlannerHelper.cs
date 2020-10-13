using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Helpers
{
    public class PlannerHelper
    {
        public IEnumerable<DayAndDate> Week { get; set; }
        public IEnumerable<Plan> Plans { get; set; }

    }
}
