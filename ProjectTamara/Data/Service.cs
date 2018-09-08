using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public int Votes { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
    }
}
