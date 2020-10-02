using DiscogymPUMA2020.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class UserRepo : IUserRepo
    {
        protected readonly Context context;
        public UserRepo(Context _context)
        {
            context = _context;
        }
    }
}
