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
        public Dictionary<int, Worker> register = new();

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

            foreach (var obj in register.Keys)
            {
 
                var o = register[obj] as OfficeWorker;
                var o2 = register[obj] as PhysicalWorker;
                var o3 = register[obj] as Trader;

                if (o != null)
                    Console.WriteLine($"OfficeWorker: {o.name}, Obj: {obj}");

                if (o2 != null)
                    Console.WriteLine($"PhysicalWorker: {o2.name}, Obj: {obj}");

                if (o3 != null)
                    Console.WriteLine($"Trader: {o3.name}, Obj: {obj}");

            }
            
        }

        public void sortRegistryByExperienceToLow()
        {
            Console.WriteLine("SORT Experience:");
            foreach (var item in register.OrderByDescending(i => i.Value.experience))
            {
                Console.WriteLine($"{item.Value.experience}");
            }
        }

        public void sortRegistryByAgeToUp()
        {
            Console.WriteLine("SORT Age:");
            foreach (var item in register.OrderBy(i => i.Value.age))
            {
                Console.WriteLine($"{item.Value.age}");
            }
        }

        public void sortRegistryBySurname()
        {
            Console.WriteLine("SORT surname:");
            foreach (var item in register.OrderBy(i => i.Value.surname))
            {
                Console.WriteLine($"{item.Value.surname}");
            }
        }

        public void getWorkersFromCity(string city)
        {
            foreach (var i in register.Values)
            {
                var ow = i as OfficeWorker;
                var pw = i as PhysicalWorker;
                var t = i as Trader;

                if (ow != null && ow.city == city)
                    Console.WriteLine($"Imię: {ow.name}, Nazwisko: {ow.surname}, Wiek: {ow.age}, Doświadczenie: {ow.experience}, Miescowość: {ow.city}, Ulica: {ow.street}, Nr. Budynku: {ow.num_building}");

                if (pw != null && pw.city == city)
                    Console.WriteLine($"Imię: {pw.name}, Nazwisko: {pw.surname}, Wiek: {pw.age}, Doświadczenie: {pw.experience}, Miescowość: {pw.city}, Ulica: {pw.street}, Nr. Budynku: {pw.num_building}");

                if (t != null && t.city == city)
                    Console.WriteLine($"Imię: {t.name}, Nazwisko: {t.surname}, Wiek: {t.age}, Doświadczenie: {t.experience}, Miescowość: {t.city}, Ulica: {t.street}, Nr. Budynku: {t.num_building}");

                
            }
        }

        public void valueForCorporation()
        {
            foreach (var i in register.Values)
            {
                var ow = i as OfficeWorker;
                var pw = i as PhysicalWorker;
                var t = i as Trader;

                if (ow != null)
                {
                    var ow_value = ow.experience * ow.iq;
                    Console.WriteLine($"Imię: {ow.name}, Nazwisko: {ow.surname}, Wartość: {ow_value}, Wiek: {ow.age}, Doświadczenie: {ow.experience}, IQ: {ow.iq}, Miescowość: {ow.city}");
                }

                if (pw != null)
                {
                    var pw_value = (pw.experience * pw.physical_strenght)/pw.age;
                    Console.WriteLine($"Imię: {pw.name}, Nazwisko: {pw.surname}, Wartość: {pw_value}, Wiek: {pw.age}, Doświadczenie: {pw.experience}, Miescowość: {pw.city}");
                }

                if (t != null)
                {
                    var t_value = 0;
                    if (t.effectiveness == "NISKA")
                        t_value = (t.experience * 60);

                    if (t.effectiveness == "ŚREDNIA")
                        t_value = (t.experience * 90);

                    if (t.effectiveness == "WYSOKA")
                        t_value = (t.experience * 120);

                    Console.WriteLine($"Imię: {t.name}, Nazwisko: {t.surname}, Wartość: {t_value}, Wiek: {t.age}, Doświadczenie: {t.experience}, Miescowość: {t.city}");
                }

            }
        }

    }
}
