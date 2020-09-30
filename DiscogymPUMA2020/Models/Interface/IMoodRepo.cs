using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IMoodRepo
    {
        IEnumerable<Mood> GetMoods { get; }
        Mood GetMood(int id);
    }
}
