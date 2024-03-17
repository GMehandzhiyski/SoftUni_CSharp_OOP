using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {

        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
 
            dummy = new Dummy(5, 2);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(dummy.Health, 5);
         
        }

        [Test]
        public void Test2()
        {
            dummy.TakeAttack(3);
            Assert.AreEqual(dummy.Health, 2);
        }

        [Test]
        public void Test3()
        {
            dummy.TakeAttack(6);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test4()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(dummy.GiveExperience(), 2);
        }
    }
}