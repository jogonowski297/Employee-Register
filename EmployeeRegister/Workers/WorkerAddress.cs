using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister.Workers
{
    public struct WorkerAddress
    {
        private string street { get; set; }
        public string num_building { get; set; }
        public string num_apartment { get; set; }
        public string city { get; set; }
    }
}
