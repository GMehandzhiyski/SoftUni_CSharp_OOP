namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Validate_CreateNewStation_NameNull()
        {
            Assert.Throws<ArgumentException>(() => { RailwayStation newRailway= new RailwayStation(null); });
        }

        [Test]
        public void Validate_CreateNewStation_NameWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => { RailwayStation newRailway = new RailwayStation(" "); });
        }

        [Test]
        public void Validate_CreateNewStation()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            var expected = "Karnobat";
            var actual = newRailway.Name;

            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void Arrival_CreateNew()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");

            var expected = 1 ;
            var actual = newRailway.ArrivalTrains.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DepartureTrains_CreateNew()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");
            newRailway.TrainHasArrived("SOF");

            var expected = 1;
            var actual = newRailway.DepartureTrains.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrainHasArrived_WrongTrain()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");
            newRailway.NewArrivalOnBoard("PLD");

            var actual = newRailway.TrainHasArrived("PLD");
            var expected = $"There are other trains to arrive before PLD.";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TrainHasArrived_Enqueue()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");
            newRailway.TrainHasArrived("SOF");

            var actual = 1;
            var expected = newRailway.DepartureTrains.Count;

            Assert.AreEqual(actual,(expected));
        }

        [Test]
        public void TrainHasArrived_Dequeue()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");
            newRailway.TrainHasArrived("SOF");

            var actual = 0;
            var expected = newRailway.ArrivalTrains.Count;

            Assert.AreEqual(actual, (expected));
        }

        [Test]
        public void TrainHasArrived_ThrowOK()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("SOF");
            

            var actual = newRailway.TrainHasArrived("SOF");
            var expected = $"SOF is on the platform and will leave in 5 minutes.";

            Assert.That(actual, Is.EqualTo (expected));
        }

        [Test]
        public void TrainHasLeft_DiferentTrain()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("PLD");
            newRailway.TrainHasArrived("PLD");

            var actual = newRailway.TrainHasLeft("SOF");
            var expected = false;

            Assert.AreEqual(actual,(expected));
        }

        [Test]
        public void TrainHasLeft_SameTrain()
        {
            RailwayStation newRailway = new RailwayStation("Karnobat");

            newRailway.NewArrivalOnBoard("PLD");
            newRailway.TrainHasArrived("PLD");

            var actual = newRailway.TrainHasLeft("PLD");
            var expected = true;

            Assert.AreEqual(actual, (expected));
        }
    }

}

