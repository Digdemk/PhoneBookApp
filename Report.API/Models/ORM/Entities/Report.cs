using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Models.ORM.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime addDate { get; set; }

    }
}
