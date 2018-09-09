using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class Comment
    {
        public string CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateCommented { get; set; }
        public virtual Beneficiary Commenter { get; set; }
        public virtual Service CommentedOn { get; set; }
    }
}
