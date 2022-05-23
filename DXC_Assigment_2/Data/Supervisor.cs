using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_Assigment_2.Data
{
    public class Supervisor
    {
        public Supervisor()
        {
            this.Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }
    }
}
