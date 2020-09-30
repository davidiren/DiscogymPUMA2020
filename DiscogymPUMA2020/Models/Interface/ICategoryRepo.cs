using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategories { get; }

        Category GetCategory(int id);
    }
}
