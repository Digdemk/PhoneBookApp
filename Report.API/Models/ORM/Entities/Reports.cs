using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Report.API.Models.ORM.Entities
{
    public class Reports
    {
        public int Id { get; set; }

        private bool isdelete = false;
        public bool Isdeleted
        {
            get
            {
                return isdelete;
            }
            set
            {
                isdelete = value;
            }
        }
        public DateTime AddDate { get; set; } = DateTime.Now;

        private bool _status = false;
        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }



    }
}
