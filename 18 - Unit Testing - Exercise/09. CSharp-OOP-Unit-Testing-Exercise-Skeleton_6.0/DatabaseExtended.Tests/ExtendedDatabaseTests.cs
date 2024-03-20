namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void CanCreateDatabase()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void CanCreateDatabaseWith16Person()
        {
            for (int i = 0; i < 16; i++)
            {
                Person person = new(i, $"J+{i}");
                database.Add(person);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.Add(new(111, "Pesho")));
            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void CanCreateDatabaseWithTheSameName()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.Add(new(13, "Joro")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void CanCreateDatabaseWithTheSameId()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.Add(new(12, "Pesho")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemovePersonFromDataBase()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            database.Remove();

            Assert.AreEqual(0, database.Count);

        }

        [Test]
        public void RemovePersonFromDataBaseWhenDatabaseIs0()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            database.Remove();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
               database.Remove());
            Assert.That(exception.Message, Is.EqualTo("Operation is not valid due to the current state of the object."));

        }
        [Test]
        public void FindByUserNameFindName()
        {
            Person person = new(12, "Joro");
            database.Add(person);

           var searchName = database.FindByUsername("Joro");
    
            Assert.AreEqual(person, searchName);

        }
        [Test]
        public void FindByUserNameFindNameTheyAreMissing()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                 database.FindByUsername("Pesho"));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));

        }

        [TestCase]
        public void FindByUserNameWithIsNullOrEmpty()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                 database.FindByUsername(null));
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null. (Parameter 'Username parameter is null!')"));

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                 database.FindByUsername(string.Empty));
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null. (Parameter 'Username parameter is null!')"));
        }

        [Test]
        public void FindByIDFindPerson()
        {
            Person person = new(12, "Joro");
            database.Add(person);

            var searchName = database.FindById(12);

            Assert.AreEqual(person, searchName);

        }
        [Test]
        public void FindByIdTheIdIsNegative()
        {
            Person person = new(5, "Joro");
            database.Add(person);

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                 database.FindById(-3));
            Assert.That(exception.Message, Is.EqualTo("Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')"));

        }

        [Test]
        public void FindByIdThePersonIsMissig()
        {
            Person person = new(5, "Joro");
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                 database.FindById(4));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));

        }

    }
}