namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new("Citroen", "C3", 2.3, 15);
        }

        [TearDown]
        public void TearDown()
        {
            car = null;
        }


        [Test]
        public void AddNewCarInConstrictor1()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.IsNotNull(car);
        }

        [Test]
        public void AddNewCarInConstrictor2()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.AreEqual("Citroen",car.Make);
            Assert.AreEqual("C3", car.Model);
            Assert.AreEqual(5.2, car.FuelConsumption);
            Assert.AreEqual(45, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void RefuelWith0()
        {
            car = new("Citroen", "C3", 5.2, 45);

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                car.Refuel(0));
            Assert.That(exception.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelWithOverCapatity()
        {
            car = new("Citroen", "C3", 5.2, 45);
            car.Refuel(50);

            Assert.AreEqual(45, car.FuelCapacity);
        }

        [Test]
        public void DriveWith≈noughFuel()
        {
            car = new("Citroen", "C3", 5.2, 45);
            car.Refuel(10);
            car.Drive(100);
            

            Assert.AreEqual(4.7999999999999998d, car.FuelAmount);
        }

        [Test]
        public void DriveWithNot≈noughFuel()
        {
            car = new("Citroen", "C3", 5.2, 45);
            car.Refuel(1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                car.Drive(100));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void CreateCarWithCorrectMake()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.AreEqual("Citroen", car.Make);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateCarWithWithNullOrEmptyMake(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
              new Car(make, "C3", 5.2 ,45));
            Assert.That(exception.Message, Is.EqualTo("Make cannot be null or empty!"));
        }


        [Test]
        public void CreateCarWithCorrectModel()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.AreEqual("C3", car.Model);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateCarWithWithNullOrEmptyModel(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
              new Car("Citroen", model, 5.2, 45));
            Assert.That(exception.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void CreateCarWithCorrectFuelConsumption()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.AreEqual(5.2000000000000002d, car.FuelConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void CreateCarWithWithNullOrEmptyFuelConsumption(double fuelConspmtion)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
              new Car("Citroen", "C3", fuelConspmtion, 45));
            Assert.That(exception.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void CreateCarWithCorrectFuelAmount()
        {
            car.Refuel(100);

            Assert.AreEqual(15.0, car.FuelAmount);
        }

          [Test]
        public void CreateCarWithCorrectFuelCapacity()
        {
            car = new("Citroen", "C3", 5.2, 45);

            Assert.AreEqual(45.0000000000000002d, car.FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void CreateCarWithWithNullOrEmptyFuelCapacity(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
              new Car("Citroen", "C3", 5.2, fuelCapacity));
            Assert.That(exception.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

    }
}