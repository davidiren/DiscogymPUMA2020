using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IUserRepo
    {
        public User GetUser(int id);
        public User GetUserByName(string name);
    }
}
