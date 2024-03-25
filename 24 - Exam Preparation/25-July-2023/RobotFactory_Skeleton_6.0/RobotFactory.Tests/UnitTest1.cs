using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("joro", 12);
        }

        [TearDown]
        public void Teardown()
        {
            factory = null;
        }
        [Test]
        public void CkeckCrotName()
        {
            string name = "joro";


            Assert.AreEqual(name, factory.Name);

        }

        [Test]
        public void CkeckCrotCapacity()
        {

            int capacity = 12;


            Assert.AreEqual(capacity, factory.Capacity);
        }

        [Test]
        public void AddToListRobots()
        {
            Robot robot = new("romba", 21.21, 25);
            factory.Robots.Add(robot);

            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void CkeckListIsNotNull()
        {
            Robot robot = new("romba", 21.21, 25);
            Supplement supp = new Supplement("arm", 25);

            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void ChekcProduceRobotMethodRobotsCountLowerThenCapacity()
        {
            Robot expextedRobot = new("romba", 21.21, 24);
            string expexctedMessage =
                $"Produced --> Robot model: {expextedRobot.Model} IS: {expextedRobot.InterfaceStandard}, Price: {expextedRobot.Price:f2}";

            string actualMessage = factory.ProduceRobot(expextedRobot.Model, expextedRobot.Price, expextedRobot.InterfaceStandard);

            Robot actualRobot = factory.Robots.Single();

            Assert.AreEqual(expextedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expextedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expextedRobot.Price, actualRobot.Price);

            Assert.AreEqual(expexctedMessage, actualMessage);
        }

        [Test]
        public void ChekcProduceRobotMethodRobotsCountBiggerThenCapacity()
        {
            factory = new Factory("joro", 0);
            string expexctedMessage = $"The factory is unable to produce more robots for this production day!";

            string actualMessage = factory.ProduceRobot("romba", 21.21, 24);


            Assert.AreEqual(expexctedMessage, actualMessage);
        }

        [Test]
        public void ChekcProduceSupplementsMethod()
        {
            Supplement expectedSupplement = new("Arm", 25);

            string expexctedMessage = factory.ProduceSupplement(expectedSupplement.Name, expectedSupplement.InterfaceStandard);
            string actualMessage = $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

            Supplement actualSupplement = factory.Supplements.Single();

            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);

            Assert.AreEqual(expexctedMessage, actualMessage);


        }

        [Test]
        public void ChekcUpgradeRobotMethodToReturnTrue()
        {
            _ = factory.ProduceRobot("romba", 21.21, 25);
            Robot robot = new("romba", 21.21, 25);
            Supplement supp = new Supplement("arm", 25);

            bool result = factory.UpgradeRobot(robot, supp);

            Supplement actualSuplements = robot.Supplements.Single();

            Assert.IsTrue(result);
            Assert.AreEqual(supp.Name, actualSuplements.Name);
            Assert.AreEqual(supp.InterfaceStandard, actualSuplements.InterfaceStandard);
        }

        [Test]
        public void ChekcUpgradeRobotMethodToReturnFalseWhenInterfaceIsDifferent()
        {
            _ = factory.ProduceRobot("romba", 21.21, 25);
            Robot robot = new("romba", 21.21, 25);
            Supplement supp = new Supplement("arm", 23);

            bool result = factory.UpgradeRobot(robot, supp);

            Assert.False(result);
            Assert.AreEqual(0, robot.Supplements.Count);
        }

        [Test]
        public void ChekcUpgradeRobotMethodToReturnFalseWhenInterfaceIsSame()
        {
            //_ = factory.ProduceRobot("romba", 21.21, 25);
            Robot robot = new("romba", 21.21, 22);
            Supplement supp = new Supplement("arm", 23);
            _ = factory.UpgradeRobot(robot, supp);

            Robot robot1 = new("romba", 21.21, 25);
            Supplement supp1 = new Supplement("arm", 23);
            _ = factory.UpgradeRobot(robot1, supp1);

            bool result = factory.UpgradeRobot(robot, supp);

            Assert.False(result);
            Assert.AreEqual(0, robot.Supplements.Count);
        }


        [Test]
        public void ChekcUpgradeRobotMethodToReturnFalseNotCreateRobot()
        {
            //_ = factory.ProduceRobot("romba", 21.21, 25);
            Robot robot = new("romba", 21.21, 25);
            Supplement supp = new Supplement("arm", 23);

            bool result = factory.UpgradeRobot(robot, supp);

            Assert.IsFalse(result);
        }

        [Test]
        public void ChekcSellRobotreturnNull()
        {
            //_ = factory.ProduceRobot("romba", 21.21, 25);
            //Robot robot = new("romba", 21.21, 25);

            var expectedRobot = factory.SellRobot(20.20);

            Assert.IsNull(expectedRobot);
        }

        [Test]
        public void ChekcSellRobotreturnRobot()
        {
            Robot expectedRobot = new("romba", 21, 25);
            _ = factory.ProduceRobot("romba", 21, 25);
            _ = factory.ProduceRobot("Iromba", 25, 25);
            _ = factory.ProduceRobot("Dromba", 30, 25);

            var actualRobot = factory.SellRobot(24);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedRobot.Supplements, actualRobot.Supplements);
        }
    }
}