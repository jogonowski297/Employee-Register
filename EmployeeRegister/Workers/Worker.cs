﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister.Workers
{
    public class Worker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string experience { get; set; }

        public string street { get; set; }
        public string num_building { get; set; }
        public string num_apartment { get; set; }
        public string city { get; set; }

    }
}
