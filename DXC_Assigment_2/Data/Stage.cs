using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_Assigment_2.Data
{
    public class Stage
    {
        public Stage()
        {
            this.Modules = new HashSet<Module>();
            this.RegularStages = new HashSet<RegularStage>();
        }

        public int Id { get; set; }

        public DateTime Deadend { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

        public int SupervisorId { get; set; }

        public virtual Supervisor Supervisor { get; set; }

        public virtual ICollection<RegularStage> RegularStages { get; set; }
    }
}
