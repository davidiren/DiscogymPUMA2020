using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Mood
    {
        public Mood()
        {
            Logs = new HashSet<Log>();
        }
        public int Id { get; set;}
        public string Name { get; set;}

        public virtual ICollection<Log> Logs { get; set; }

    }
}
