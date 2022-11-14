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
        Dictionary<int, OfficeWorker> officeWorker_dict = new();
        Dictionary<int, PhysicalWorker> physicalWorker_dict = new();
        Dictionary<int, Trader> trader_dict = new();

        public void addOfficeWorkerToDist(OfficeWorker office_worker)
        {
            officeWorker_dict.Add(office_worker.id, office_worker);
        }
        public void addPhysicalWorkerToDist(PhysicalWorker physical_worker)
        {
            physicalWorker_dict.Add(physical_worker.id, physical_worker);
        }
        public void addTraderToDist(Trader trader)
            
        {
            trader_dict.Add(trader.id, trader);
        }

 
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }


        public void printOfficeWorkers()
        {
            foreach (var w in officeWorker_dict.Values)
            {
                Console.WriteLine($"id: {w.id} name: {w.name} surname: {w.surname} age: {w.age}");
            }
        }

      
    }
}
