namespace Railway.Tests
{
    using System;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_CreateNewStation_NameNull()
        {
            Assert.Throws<ArgumentException>(() => { RailwayStation railwayStation = new RailwayStation(null); });
        }

        [Test]
        public void Validate_CreateNewStation_NameWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => { RailwayStation railwayStation = new RailwayStation(" "); });
        }

        [Test]
        public void Validate_CreateNewStation_CorrectName()
        {
            RailwayStation railwayStation = new RailwayStation("Karnobat");

            var expectedResult = "Karnobat";
            var actualResult = railwayStation.Name;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Validate_Method_NewArrivalOnBoard()
        {
            RailwayStation railwayStation = new RailwayStation("Sofia");

            railwayStation.NewArrivalOnBoard("BUR->BEL");

            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_Method_TrainHasArrived_CheckDepartureTrains()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.NewArrivalOnBoard("BUR->SOF");
            station.TrainHasArrived("SOF->BUR");

            Assert.That(station.DepartureTrains.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_Method_TrainHasArrived()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.NewArrivalOnBoard("BUR->SOF");

            var actualResult = station.TrainHasArrived("SOF->BUR");
            var expectedResult = "SOF->BUR is on the platform and will leave in 5 minutes.";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Validate_Method_TrainHasArrived_Throws()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.NewArrivalOnBoard("BUR->SOF");

            var actualResult = station.TrainHasArrived("BUR->SOF");
            var expectedResult = "There are other trains to arrive before BUR->SOF.";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Validate_Method_TrainHasLeft_ValidData()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.TrainHasArrived("SOF->BUR");

            var actualResult = station.TrainHasLeft("SOF->BUR");

            Assert.That(actualResult, Is.True);
        }

        [Test]
        public void Validate_Method_TrainHasLeft_TrainDeququed()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.TrainHasArrived("SOF->BUR");

            Assert.That(station.DepartureTrains.Count == 1);

            station.TrainHasLeft("SOF->BUR");

            Assert.That(station.DepartureTrains.Count == 0);
        }

        [Test]
        public void Validate_Method_TrainHasLeft_InvalidData()
        {
            RailwayStation station = new RailwayStation("Karnobat");

            station.NewArrivalOnBoard("SOF->BUR");
            station.NewArrivalOnBoard("BUR->SOF");
            station.TrainHasArrived("SOF->BUR");
            station.TrainHasArrived("BUR->SOF");

            var actualResult = station.TrainHasLeft("BUR->SOF");

            Assert.That(actualResult, Is.False);
        }
    }
}