using NUnit.Framework;
using System.Diagnostics;
using EmployeeRegister.Workers;
using EmployeeRegister.Registry;
using Microsoft.Win32;

namespace EmployeeRegister.InitTests
{
    public class Tests
    {
        static int id_counter;
        static int office_id_counter;
        RegistryWorkers registry = new RegistryWorkers();

        private int getIDCounter()
        {
            id_counter++;
            return id_counter;
        }

        private int getOfficeIDCounter()
        {
            office_id_counter++;
            return office_id_counter;
        }

        [SetUp]
        public void Setup()
        {
            registry.register.Clear();
            id_counter = 0;
            office_id_counter = 0;
        }

        [Test]
        public void addWorker()
        {

            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "nowy",
                surname = "NOWY",
                age = 40,
                experience = 8,
                street = "D³uga",
                num_building = 2,
                num_apartment = 4,
                city = "Torun",
                office_ID = $"{getOfficeIDCounter}a",
                iq = 120
            });
            Assert.That(registry.register.Count, Is.EqualTo(1));
        }

        [Test]
        public void removeWorker()
        {
            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "nowy2",
                surname = "NOWY2",
                age = 40,
                experience = 8,
                street = "D³uga",
                num_building = 2,
                num_apartment = 4,
                city = "Torun",
                office_ID = $"{getOfficeIDCounter}a",
                iq = 120
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "nowy3",
                surname = "NOWY3",
                age = 69,
                experience = 2,
                street = "Leœna",
                num_building = 2,
                num_apartment = 4,
                city = "Warszawa",
                physical_strenght = 20
            });
            
            // usunie pracownika o id = 1 (czyli nowy2)
            registry.removeWorkerFromDictionary(1);

            Assert.That(registry.register.Count, Is.EqualTo(1));
        }

        [Test]
        public void addManyWorkers()
        { 
            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "nowy2",
                surname = "NOWY2",
                age = 40,
                experience = 8,
                street = "D³uga",
                num_building = 2,
                num_apartment = 4,
                city = "Torun",
                office_ID = $"{getOfficeIDCounter}a",
                iq = 120
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "nowy3",
                surname = "NOWY3",
                age = 69,
                experience = 2,
                street = "Leœna",
                num_building = 2,
                num_apartment = 4,
                city = "Warszawa",
                physical_strenght = 20
            });

            Assert.That(registry.register.Count, Is.EqualTo(2));
        }
    }
}