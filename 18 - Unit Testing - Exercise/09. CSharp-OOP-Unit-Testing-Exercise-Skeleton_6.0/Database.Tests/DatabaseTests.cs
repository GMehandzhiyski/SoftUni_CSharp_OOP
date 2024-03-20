namespace Database.Tests
{
    using System;
    using System.ComponentModel;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }


        [Test]
        public void CanCreateDatabase() 
        {
            database.Add(1);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void CanCreateDatabaseFull()
        {
            database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

            Assert.AreEqual(16, database.Count);
        }
       
        [Test]
        public void CanCreateDatabaseWithMoreThan16()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

           InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                database.Add(4));
            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveElementFromDatabase()
        {
            database = new(2,3);

            database.Remove();

            Assert.AreEqual(1, database.Count); 
        }

        [Test]
        public void RemoveElementFromEmptyDatabase()
        {
        
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                 database.Remove());
            Assert.That(exception.Message, Is.EqualTo("The collection is empty!"));
        }


        [Test]
        public void TestFetchMetohod()
        {
            database = new(2,3);

           int[] result= database.Fetch();

            Assert.That(new[] {2,3},Is.EquivalentTo(result));
          
        }
    }
}
