using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Model
{
    public class DataModel
    {
        public string ValueName { get; set; }
        public string Operation { get; set; }
        public string InputValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
