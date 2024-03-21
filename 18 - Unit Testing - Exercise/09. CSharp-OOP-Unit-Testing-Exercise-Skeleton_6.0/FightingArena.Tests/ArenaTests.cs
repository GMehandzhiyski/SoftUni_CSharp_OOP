namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [TearDown]

        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void ChechCountOfList()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void AddWarriorsToList()
        {
            Warrior warrior = new("joro", 20, 40);
            arena.Enroll(warrior);
            Warrior warrior2 = new("jor", 21, 41);
            arena.Enroll(warrior2);

            Assert.AreEqual(2, arena.Count);
        }


        [Test]
        public void EnrolmethodTheSameNameWarrior()
        {
            Warrior warrior = new("joro", 20, 40);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
              arena.Enroll(warrior));
            Assert.That(exception.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        //[Test]
        //public void FightWithGoodCase()
        //{
        //    Warrior attacker = new("joro", 20, 40);
        //    arena.Enroll(attacker);
        //    Warrior defender = new("jor", 21, 41);
        //    arena.Enroll(defender);

        //    attacker.Attack(defender);

        //    Assert.AreEqual(2, arena.Count);
        //}

        [Test]
        public void MissingAttacker()
        {
            Warrior attacker = new("joro", 20, 40);
            arena.Enroll(attacker);
            Warrior defender = new("jor", 21, 41);
            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
              arena.Fight("Pesh","joro"));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name Pesh enrolled for the fights!"));
        }


        [Test]
        public void MissingDefender()
        {
            Warrior attacker = new("joro", 20, 40);
            arena.Enroll(attacker);
            Warrior defender = new("jor", 21, 41);
            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
              arena.Fight("joro", "Pesh"));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name Pesh enrolled for the fights!"));
        }

        [Test]
        public void FightGoodCase()
        {
            Warrior attacker = new("joro", 15, 35);
            arena.Enroll(attacker);
            Warrior defender = new("jor", 15, 45);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(30, defender.HP);
        }

    }
}
