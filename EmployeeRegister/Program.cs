using EmployeeRegister;
using System;
using EmployeeRegister.Workers;
using EmployeeRegister.Registry;
using System.Runtime.CompilerServices;

namespace EmployessRegister
{
    class Program
    {
        static int id_counter = 0;
        static void Main(string[] args)
        {
    

            RegistryWorkers registry = new RegistryWorkers();


            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Jan",
                surname = "Kowalski",
                age = 34,
                iq = 100
            }) ;

            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Tom",
                surname = "Stiff",
                age = 23,
                iq = 120
            });

            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "John",
                surname = "Boobo",
                age = 24,
                iq = 96
            });

            registry.addWorkerToDictionary(new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "John",
                surname = "Boobo",
                age = 24,
                physical_strenght = "good"
            });

            registry.removeWorkerFromDictionary(2);

            registry.test();



        }
        private static int getIDCounter()
        {
            id_counter++;
            return id_counter;
        }

    }
}