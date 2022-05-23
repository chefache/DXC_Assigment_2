using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_Assigment_2.Data
{
    public class Module
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ExitCodeVolume { get; set; }

        public decimal DocumentationVolume { get; set; }

        public DateTime PlanedDeadend { get; set; }

        public DateTime TrueDeadend { get; set; }

        public int RegularId { get; set; }

        public virtual Regular Regular { get; set; }

        public int StageId { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
