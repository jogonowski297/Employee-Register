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
        public void checkWrongIQ()
        {

            bool check = registry.addWorkerToDictionary(new OfficeWorker()
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
                iq = 1500
            });
            Assert.That(check, Is.EqualTo(false));
        }

        [Test]
        public void checkWrongStrenght()
        {

            bool check = registry.addWorkerToDictionary(new PhysicalWorker()
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
                physical_strenght = 1500
            });
            Assert.That(check, Is.EqualTo(false));
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

        [Test]
        public void getWorkerWithCity()
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

            string city = "Torun";


            List<Dictionary<string, string>> cityList = registry.getWorkersFromCity(city);

            // Iloœæ pracownikow z Trounia
            Assert.That(cityList.Count, Is.EqualTo(1));

            // Miescowoœæ = Torun
            Assert.That(cityList[0]["Miescowoœæ"], Is.EqualTo("Torun"));
        }

        [Test]
        public void getCompanyValue()
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
            }, new Trader()
            {
                id = getIDCounter(),
                name = "Imie11",
                surname = "Nazwisko11",
                age = 41,
                experience = 20,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Torun",
                effectiveness = "WYSOKA",
                commission_amount = 10
            });

            List<Dictionary<string, string>> valueList = registry.valueForCorporation();

            // Iloœæ pracownikow 
            Assert.That(valueList.Count, Is.EqualTo(3));

            // Wartosc dla OfficeWorkera, PhysicalWorkera i Tradera.
            Assert.That(valueList[0]["Wartosc"], Is.EqualTo(960.000.ToString("N3")));
            Assert.That(valueList[1]["Wartosc"], Is.EqualTo(0.580.ToString("N3")));
            Assert.That(valueList[2]["Wartosc"], Is.EqualTo(2400.000.ToString("N3")));
        }
    }
}