using EmployeeRegister;
using System;
using EmployeeRegister.Workers;

namespace EmployessRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            OfficeWorker office_worker = new OfficeWorker();
            PhysicalWorker physical_worker = new PhysicalWorker();
            Trader trader = new Trader();

            office_worker.surname = "Kowalski";
            office_worker.city = "Gdansk";
            office_worker.iq = 100;


            Console.WriteLine($"Surname: {office_worker.surname}\nCity: {office_worker.city}\nIQ: {office_worker.iq}");


        }
    }
}