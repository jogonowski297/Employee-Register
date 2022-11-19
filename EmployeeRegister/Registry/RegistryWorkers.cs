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

        public bool addWorkerToDictionary(params Worker[] obj)
        {


            foreach (Worker worker in obj)
            {
                var ow = worker as OfficeWorker;
                var fw = worker as PhysicalWorker;
                var t = worker as Trader;

                if (ow != null)
                    if (!checkIQ(ow.iq))
                        return false;

                if (fw != null)
                    if (!checkStrenght(fw.physical_strenght))
                        return false;


                register.Add(worker.id, worker);
            }
            return true;
        }

        public void removeWorkerFromDictionary(int id)
        {
            register.Remove(id);
        }

        public bool checkIQ(int iq)
        {
            if (iq >= 70 && iq <= 150)
                return true;
            return false;
        }

        public bool checkStrenght(int strenght)
        {
            if (strenght >= 1 && strenght <= 100)
                return true;
            return false;
        }

        public List<Dictionary<string, string>> sortRegistry()
        {
            List<Dictionary<string, string>> sortList = new List<Dictionary<string, string>>();

            Console.WriteLine("SORT Experience:");
            foreach (var item in register.OrderByDescending(i => i.Value.experience).ThenBy(i => i.Value.age).ThenBy(i => i.Value.surname))
            {
                sortList.Add(new Dictionary<string, string>());
                sortList[sortList.Count - 1].Add("Imię", item.Value.name);
                sortList[sortList.Count - 1].Add("Nazwisko", item.Value.surname);
                sortList[sortList.Count - 1].Add("Doswiadczenie", item.Value.experience.ToString());
                sortList[sortList.Count - 1].Add("Wiek", item.Value.age.ToString());
                //Console.WriteLine($"{item.Value.experience}");
            }

            return sortList;
        }

        public void sortRegistryByExperienceToLow()
        {
            foreach (var item in register.OrderByDescending(i => i.Value.experience))
            {
                Console.WriteLine($"{item.Value.name} {item.Value.surname} {item.Value.experience}");
            }
        }

        public void sortRegistryByAgeToUp()
        {
            foreach (var item in register.OrderBy(i => i.Value.age))
            {
                
                Console.WriteLine($"{item.Value.name} {item.Value.surname} {item.Value.age}");
            }
        }

        public void sortRegistryBySurname()
        {
            foreach (var item in register.OrderBy(i => i.Value.surname))
            {
                Console.WriteLine($"{item.Value.name} {item.Value.surname}");
            }
        }

        public List<Dictionary<string, string>> getWorkersFromCity(string city)
        {
            List<Dictionary<string, string>> cityList = new List<Dictionary<string, string>>();

            foreach (int i in register.Keys)
            {

                var ow = register[i] as OfficeWorker;
                var pw = register[i] as PhysicalWorker;
                var t = register[i] as Trader;


                if (ow != null && ow.city == city)
                {
                    cityList.Add(new Dictionary<string, string>());
                    cityList[cityList.Count - 1].Add("Imię", ow.name);
                    cityList[cityList.Count - 1].Add("Nazwisko", ow.surname);
                    cityList[cityList.Count - 1].Add("Wiek", ow.age.ToString());
                    cityList[cityList.Count - 1].Add("Doświadczenie", ow.experience.ToString());
                    cityList[cityList.Count - 1].Add("Miescowość", ow.city);
                    cityList[cityList.Count - 1].Add("Ulica", ow.street);
                    cityList[cityList.Count - 1].Add("Nr.Budynku", ow.num_building.ToString());
                    continue;
                }

                if (pw != null && pw.city == city)
                {
                    cityList.Add(new Dictionary<string, string>());
                    cityList[cityList.Count - 1].Add("Imię", pw.name);
                    cityList[cityList.Count - 1].Add("Nazwisko", pw.surname);
                    cityList[cityList.Count - 1].Add("Wiek", pw.age.ToString());
                    cityList[cityList.Count - 1].Add("Doświadczenie", pw.experience.ToString());
                    cityList[cityList.Count - 1].Add("Miescowość", pw.city);
                    cityList[cityList.Count - 1].Add("Ulica", pw.street);
                    cityList[cityList.Count - 1].Add("Nr.Budynku", pw.num_building.ToString());
                    continue;
                }

                if (t != null && t.city == city)
                {
                    cityList.Add(new Dictionary<string, string>());
                    cityList[cityList.Count - 1].Add("Imię", t.name);
                    cityList[cityList.Count - 1].Add("Nazwisko", t.surname);
                    cityList[cityList.Count - 1].Add("Wiek", t.age.ToString());
                    cityList[cityList.Count - 1].Add("Doświadczenie", t.experience.ToString());
                    cityList[cityList.Count - 1].Add("Miescowość", t.city);
                    cityList[cityList.Count - 1].Add("Ulica", t.street);
                    cityList[cityList.Count - 1].Add("Nr.Budynku", t.num_building.ToString());
                    continue;
                }

            }
            return cityList;
            
        }

        public List<Dictionary<string, string>> valueForCorporation()
        {
            List<Dictionary<string, string>> valueList = new List<Dictionary<string, string>>();
            foreach (var i in register.Values)
            {
                var ow = i as OfficeWorker;
                var pw = i as PhysicalWorker;
                var t = i as Trader;

                if (ow != null)
                {
                    string ow_value = Decimal.Multiply(ow.experience,ow.iq).ToString("N3");
                    valueList.Add(new Dictionary<string, string>());
                    valueList[valueList.Count - 1].Add("Imię", ow.name);
                    valueList[valueList.Count - 1].Add("Nazwisko", ow.surname);
                    valueList[valueList.Count - 1].Add("Wartosc", ow_value);
                    valueList[valueList.Count - 1].Add("Wiek", ow.age.ToString());
                    valueList[valueList.Count - 1].Add("Doświadczenie", ow.experience.ToString());
                    valueList[valueList.Count - 1].Add("Miescowość", ow.city);
                    continue;
                }

                if (pw != null)
                {
                    string pw_value = Decimal.Divide(pw.experience * pw.physical_strenght, pw.age).ToString("N3");

                    valueList.Add(new Dictionary<string, string>());
                    valueList[valueList.Count - 1].Add("Imię", pw.name);
                    valueList[valueList.Count - 1].Add("Nazwisko", pw.surname);
                    valueList[valueList.Count - 1].Add("Wartosc", pw_value);
                    valueList[valueList.Count - 1].Add("Wiek", pw.age.ToString());
                    valueList[valueList.Count - 1].Add("Doświadczenie", pw.experience.ToString());
                    valueList[valueList.Count - 1].Add("Miescowość", pw.city);
                    continue;
                }

                if (t != null)
                {
                    string t_value = "";
                    if (t.effectiveness == "NISKA")
                        t_value = Decimal.Multiply(t.experience,60).ToString("N3");

                    if (t.effectiveness == "ŚREDNIA")
                        t_value = Decimal.Multiply(t.experience,90).ToString("N3");

                    if (t.effectiveness == "WYSOKA")
                        t_value = Decimal.Multiply(t.experience,120).ToString("N3");

                    valueList.Add(new Dictionary<string, string>());
                    valueList[valueList.Count - 1].Add("Imię", t.name);
                    valueList[valueList.Count - 1].Add("Nazwisko", t.surname);
                    valueList[valueList.Count - 1].Add("Wartosc", t_value);
                    valueList[valueList.Count - 1].Add("Wiek", t.age.ToString());
                    valueList[valueList.Count - 1].Add("Doświadczenie", t.experience.ToString());
                    valueList[valueList.Count - 1].Add("Miescowość", t.city);
                    continue;

                }

            }
            return valueList;
        }

    }
}
