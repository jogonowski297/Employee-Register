using NUnit.Framework;
using System.Diagnostics;
using EmployeeRegister.Workers;

namespace EmployeeRegister.InitTests
{
    public class Tests
    {
        private OfficeWorker office_worker;
        private PhysicalWorker physical_worker;
        private Trader trader;

        [SetUp]
        public void Setup()
        {
            office_worker = new OfficeWorker();
            physical_worker = new PhysicalWorker();
            trader = new Trader();
        }

        [Test]
        public void Test1()
        {
            office_worker.surname = "Kowalski";
            office_worker.city = "Gdansk";
            office_worker.iq = 100;

            Assert.That(office_worker.surname, Is.EqualTo("Kowalski"));
            Assert.That(office_worker.city, Is.EqualTo("Gdansk"));
            Assert.That(office_worker.iq, Is.EqualTo(100));
        }
    }
}