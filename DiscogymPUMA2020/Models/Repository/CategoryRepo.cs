using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        protected readonly Context context;
        public CategoryRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Category> GetCategories => throw new NotImplementedException();

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
