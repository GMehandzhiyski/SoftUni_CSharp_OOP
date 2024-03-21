namespace FightingArena.Tests
{
    using System;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        //private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void SetUp() 
        {
            warrior = new("joro", 20, 40);
        }

        [TearDown]

        public void TearDown() 
        {
            warrior = null;
        }


        [Test]
        public void CreateWarriorCorretName()
        {
            warrior = new("joro", 15, 45);

            Assert.AreEqual("joro", warrior.Name);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateWarriorNameWithNullOrWhiteSpace(string name)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
             new Warrior(name,25,40));
            Assert.That(exception.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void CreateWarriorCorrectDamage()
        {
            warrior = new("joro", 25, 40);

            Assert.AreEqual(25, warrior.Damage);

        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void CreateWarriorWit0AndNegativeDamage(int damage)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
             new Warrior("joro", damage, 40));
            Assert.That(exception.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void CreateWarriorCorrectHP()
        {
            warrior = new("joro", 25, 40);

            Assert.AreEqual(40, warrior.HP);

        }

        [Test]
        public void CreateWarriorWit0HP()
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
             new Warrior("joro", 25, -2));
            Assert.That(exception.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackMethodHPUnderAndEqualToAttacker()
        {
            var attacker = new  Warrior("Pesho", 10, 20);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(warrior));
            Assert.That(exception.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackMethodHPUnderAndEqualToWarrior()
        {
            var attacker = new Warrior("Pesho", 10, 20);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(attacker));
            Assert.That(exception.Message, Is.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackMethodWhenWarriorDamageiSBiggerThenHP()
        {
            warrior = new("joro", 32, 40);
            var attacker = new Warrior("Pesho", 10, 31);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(warrior));
            Assert.That(exception.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackMethod()
        {
            var attacker = new Warrior("Pesho", 30, 40);
            warrior = new("joro", 15, 45);
            
            warrior.Attack(attacker);

            Assert.AreEqual(25, attacker.HP);
             
        }
        [Test]
        public void AttackMethodAttackerDamageBiggerThanWarrior()
        {
            var attacker = new Warrior("Pesho", 50, 40);
            warrior = new("joro", 32, 39);

            attacker.Attack(warrior);

            Assert.AreEqual(0, warrior.HP);

        }
        [Test]
        public void AttackMethodAttackerDamageLowerThanWarrior()
        {
            var attacker = new Warrior("Pesho", 45, 35);
            warrior = new("joro", 15, 45);

            warrior.Attack(attacker);

            Assert.AreEqual(0, warrior.HP);
            Assert.AreEqual(20, attacker.HP);
        }

    }
}