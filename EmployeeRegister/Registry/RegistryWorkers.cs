using EmployeeRegister.Workers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister.Registry
{
    public class RegistryWorkers
    { 
        Dictionary<int, Worker> register = new();



        public void addWorkerToDictionary(params Worker[] obj)
        {
            foreach (Worker worker in obj)
                register.Add(worker.id, worker);
        }

        public void removeWorkerFromDictionary(int id)
        {
            register.Remove(id);
        }

        public void test()
        {
            foreach (var obj in register.Values)
            {
                var o = obj as OfficeWorker;
                var o2 = obj as PhysicalWorker;
                if (o != null)
                    Console.WriteLine($"DSADASD: {o.name}");
                if (o2 != null)
                    Console.WriteLine($"111: {o2.name}");

            }
            
        }

    }
}
