using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Validate_Constructor()
        {
            int waterCap = 100;
            int buttonsCount = 50;
            CoffeeMat cafe = new CoffeeMat(waterCap,buttonsCount);

            Assert.AreEqual(waterCap, cafe.WaterCapacity);
            Assert.AreEqual(buttonsCount, cafe.ButtonsCount);
            Assert.AreEqual(0, cafe.Income);

            
        }

        [Test]
        public void Validate_FillWaterTankAreAddWater()
        {
            int waterCap = 100;
            int buttonsCount = 50;
            int mililitresFilled = 100;
            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string actual = cafe.FillWaterTank();
            string expected = $"Water tank is filled with {mililitresFilled}ml";
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(100, cafe.WaterCapacity);
           

        }

        [Test]
        public void Validate_FillWaterTankAreEqul()
        {
            int waterCap = 100;
            int buttonsCount = 50;
            int mililitresFilled = 100;
            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            cafe.FillWaterTank();
            string actual = cafe.FillWaterTank();


            string expected = $"Water tank is already full!";

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(100, cafe.WaterCapacity);
            

        }

        [Test]
        public void Validate_AddDrink()
        {
            int waterCap = 100;
            int buttonsCount = 50;
           
            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;

            bool actual = cafe.AddDrink(name, price);  

            Assert.IsTrue(actual);

        }

        [Test]
        public void Validate_AddDrinkButtons0()
        {
            int waterCap = 100;
            int buttonsCount = 0;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;

            bool actual = cafe.AddDrink(name, price);

            Assert.IsFalse(actual);

        }

        [Test]
        public void Validate_AddDrinkNameSameDrink()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            bool actual = cafe.AddDrink(name, price);

            string name1 = "Moka";
            double price1 = 2.00;
            bool actual1 = cafe.AddDrink(name, price);

            Assert.IsFalse(actual1);

        }

        [Test]
        public void Validate_AddDrinkNameLowButtons()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            bool actual = cafe.AddDrink(name, price);

            string name1 = "Java";
            double price1 = 2.00;
            bool actual1 = cafe.AddDrink(name, price);

            string name3 = "Cappucino";
            double price3 = 2.00;
            bool actual3 = cafe.AddDrink(name, price);

            Assert.IsFalse(actual3);

        }

        [Test]
        public void Validate_BuyDrinkNotAvailableDrink()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            cafe.AddDrink(name, price);
            cafe.FillWaterTank();

            string drinkName = "Java";

            string actual = cafe.BuyDrink(drinkName);
            string expected = $"{drinkName} is not available!";


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_BuyDrinkNotAvailableWater()
        {
            int waterCap = 79;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            cafe.AddDrink(name, price);
            cafe.FillWaterTank();

            string drinkName = "Java";

            string actual = cafe.BuyDrink(drinkName);
            string expected = $"CoffeeMat is out of water!";


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_BuyDrink()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            cafe.AddDrink(name, price);
            cafe.FillWaterTank();

            string drinkName = "Moka";

            string actual = cafe.BuyDrink(drinkName);
            string expected = $"Your bill is {price:f2}$";


            Assert.AreEqual(price, cafe.Income);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_BuyDrinkBuySecondDrink()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            cafe.AddDrink(name, price);
            cafe.FillWaterTank();

            string drinkName = "Moka";
            string actual1 = cafe.BuyDrink(drinkName);
            string actual = cafe.BuyDrink(drinkName);
            string expected = $"CoffeeMat is out of water!";


            Assert.AreEqual(price, cafe.Income);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_CollectIcome()
        {
            int waterCap = 100;
            int buttonsCount = 50;

            CoffeeMat cafe = new CoffeeMat(waterCap, buttonsCount);

            string name = "Moka";
            double price = 2.00;
            cafe.AddDrink(name, price);

            cafe.FillWaterTank();

            string drinkName = "Moka";
            string actual = cafe.BuyDrink(drinkName);
            
            double collectedIncome = cafe.CollectIncome();

            
            Assert.AreEqual(0, cafe.Income);
            Assert.AreEqual(price, collectedIncome);
        }
    }
}