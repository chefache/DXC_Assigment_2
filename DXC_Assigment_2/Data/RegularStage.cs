using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_Assigment_2.Data
{
    public class RegularStage
    {
        public int Id { get; set; }

        public int RegularId { get; set; }
        public virtual Regular Regular { get; set; }


        public int StageId { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
