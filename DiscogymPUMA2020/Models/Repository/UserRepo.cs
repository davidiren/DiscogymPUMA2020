using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
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

        public User GetUser(int id) 
        {
            return context.User.Find(id);
        }

        public User GetUserByName(string name)
        {
            return context.User.Where(r => r.Name == name).FirstOrDefault();
        }
    }
}
