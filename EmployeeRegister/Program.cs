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

            registry.addOfficeWorkerToDist(new OfficeWorker() 
            {
                id=getIDCounter(),
                name="Jan",
                surname="Kowalski",
                age = 34
            });

            registry.addOfficeWorkerToDist(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Anna",
                surname = "Nowak",
                age = 24
            });

            registry.addOfficeWorkerToDist(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Piotr",
                surname = "Piotrowski",
                age = 40
            });


        }
        private static int getIDCounter()
        {
            id_counter++;
            return id_counter;
        }

    }
}