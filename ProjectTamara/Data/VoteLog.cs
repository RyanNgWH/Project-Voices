using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class VoteLog
    {
        public string VoteLogId { get; set; }
        public virtual Service CorrService { get; set; }
        public virtual Beneficiary Beneficiary { get; set; }
    }
}
