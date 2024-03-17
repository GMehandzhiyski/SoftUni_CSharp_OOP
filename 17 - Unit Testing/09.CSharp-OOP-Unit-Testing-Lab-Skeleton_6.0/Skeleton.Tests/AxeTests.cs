using System;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp() 
        {
            axe = new Axe(3, 2);
            dummy = new Dummy(5,2); 
        }
        
        [Test]
        public void Test1()
        {
            Assert.AreEqual(axe.AttackPoints, 3);
            Assert.AreEqual(axe.DurabilityPoints, 2);
        }

        [Test]
        public void Test2()
        {
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 1);
        }

        [Test]
        public void Test3()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void Test4()
        {
            axe = new Axe(5, -50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}