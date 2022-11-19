using EmployeeRegister;
using System;
using EmployeeRegister.Workers;
using EmployeeRegister.Registry;
using System.Runtime.CompilerServices;

namespace EmployessRegister
{
    class Program
    {
        static int id_counter;
        static int office_id_counter;

        static void Main(string[] args)
        {
    

            RegistryWorkers registry = new RegistryWorkers();


            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Imie1",
                surname = "Aramana",
                age = 20,
                experience = 10,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                office_ID = $"{getOfficeIDCounter}a",
                iq = 100
            });

            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Imie2",
                surname = "Bozowski",
                age = 22,
                experience = 12,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                office_ID = $"{getOfficeIDCounter}a",
                iq = 122
            });

            registry.addWorkerToDictionary(new OfficeWorker()
            {
                id = getIDCounter(),
                name = "Imie3",
                surname = "Zwariowany",
                age = 22,
                experience = 12,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                office_ID = getOfficeIDCounter().ToString() + "a",
                iq = 70
            });

            registry.addWorkerToDictionary(new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "Imie4",
                surname = "Currk",
                age = 22,
                experience = 12,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                physical_strenght = 20
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "Imie5",
                surname = "Borek",
                age = 23,
                experience = 12,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                physical_strenght = 100
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "Imie6",
                surname = "Nazwisko6",
                age = 26,
                experience = 2,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                physical_strenght = 34
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "Imie7",
                surname = "Nazwisko7",
                age = 32,
                experience = 3,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                physical_strenght = 44
            }, new PhysicalWorker()
            {
                id = getIDCounter(),
                name = "Imie8",
                surname = "Nazwisko8",
                age = 67,
                experience = 8,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Elblag",
                physical_strenght = 14
            });

            registry.addWorkerToDictionary(new Trader()
            {
                id = getIDCounter(),
                name = "Imie9",
                surname = "Nazwisko9",
                age = 21,
                experience = 1,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Gdansk",
                effectiveness = "NISKA",
                commission_amount = 3
            }, new Trader()
            {
                id = getIDCounter(),
                name = "Imie10",
                surname = "Nazwisko10",
                age = 39,
                experience = 13,
                street = "Prosta",
                num_building = 2,
                num_apartment = 4,
                city = "Torun",
                effectiveness = "ŚREDNIA",
                commission_amount = 6
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

            Console.WriteLine("Sortowanie po liczbie lat doświadczenia (malejąco): ");
            registry.sortRegistryByExperienceToLow();

            Console.WriteLine("\nSortowanie po wieku (rosnaco): ");
            registry.sortRegistryByAgeToUp();

            Console.WriteLine("\nSortowanie po nazwisku (alfabetycznie): ");
            registry.sortRegistryBySurname();


            Console.WriteLine("\nWyświetlanie pracowników z Gdańska: ");
            var cityListGdansk = registry.getWorkersFromCity("Gdansk");
            for (int i = 0; i < cityListGdansk.Count; i++)
            {
                Console.WriteLine($"Imię: {cityListGdansk[i]["Imię"]} , Nazwisko: {cityListGdansk[i]["Nazwisko"]} ,  Miejscowosc: {cityListGdansk[i]["Miescowość"]} ");
            }


            Console.WriteLine("\nWyświetlanie pracowników z Torunia: ");
            var cityListTorun = registry.getWorkersFromCity("Torun");
            for (int i = 0; i < cityListTorun.Count; i++)
            {
                Console.WriteLine($"Imię: {cityListTorun[i]["Imię"]} , Nazwisko: {cityListTorun[i]["Nazwisko"]} ,  Miejscowosc: {cityListTorun[i]["Miescowość"]} ");
            }


            Console.WriteLine("\nSortowanie po liczbie lat doświadczenia (malejąco): ");
            var cityListValue = registry.valueForCorporation();
            for (int i = 0; i < cityListValue.Count; i++)
            {
                Console.WriteLine($"Imię: {cityListValue[i]["Imię"]} , Nazwisko: {cityListValue[i]["Nazwisko"]} ,  Wartość: {cityListValue[i]["Wartosc"]} ");
            }

            //List<Dictionary<string, string>> sortList = registry.sortRegistry();
            //string doswiadczenie = "Doswiadczenie";
            //string wiek = "Wiek";
            //string nazwisko = "Nazwisko";

            //for (int i = 0; i < sortList.Count; i++)
            //{
            //    Console.WriteLine($"Doświadczenie: {sortList[i][doswiadczenie]} , Wiek: {sortList[i][wiek]} ,  Nazwisko: {sortList[i][nazwisko]} ");
            //}



        }
        private static int getIDCounter()
        {
            id_counter++;
            return id_counter;
        }

        private static int getOfficeIDCounter()
        {
            office_id_counter++;
            return office_id_counter;
        }

    }
}