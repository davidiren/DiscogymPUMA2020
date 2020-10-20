using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models
{
    public class CategoryViewModel
    {
        
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<string> SelectedCategories { get; set; }

        public CategoryViewModel(IEnumerable<SelectListItem> categories)
        {
            Categories = categories;
            SelectedCategories = new List<string>();
        }
    }
}
