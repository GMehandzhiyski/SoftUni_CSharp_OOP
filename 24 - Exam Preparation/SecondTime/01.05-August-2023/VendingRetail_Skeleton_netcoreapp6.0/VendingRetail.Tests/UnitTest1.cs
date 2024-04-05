using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Validate_Ctror()
        {
            CoffeeMat coffee = new CoffeeMat(100, 50);

            Assert.AreEqual(100, coffee.WaterCapacity);
            Assert.AreEqual(50, coffee.ButtonsCount);
            Assert.AreEqual(0, coffee.Income);
            Assert.IsNotNull(coffee);

        }

        [Test]
        public void Validate_FillWaterTankGoodCased()
        {
            CoffeeMat coffee = new CoffeeMat(100, 50);

            Assert.AreEqual($"Water tank is filled with {100}ml", coffee.FillWaterTank());
           
        }


        [Test]
        public void Validate_FillWaterTankIFCase()
        {
            CoffeeMat coffee = new CoffeeMat(100, 50);

            coffee.FillWaterTank();

            Assert.AreEqual($"Water tank is already full!", coffee.FillWaterTank());
        }

        [Test]
        public void Validate_AddDrinkAddDrink()
        {

            CoffeeMat coffee = new CoffeeMat(100, 50);

            Assert.IsTrue(coffee.AddDrink("Moka", 2.00));
           
        }

        [Test]
        public void Validate_AddDrinkElseCase()
        {

            CoffeeMat coffee = new CoffeeMat(100, 0);

            coffee.AddDrink("Cafe",3);

         
            Assert.IsFalse(coffee.AddDrink("Moka",2.00));
        }

        [Test]
        public void Validate_AddDrinkAddDrinkLowButtons()
        {

            CoffeeMat coffee = new CoffeeMat(5000, 3);
            coffee.AddDrink("cafe", 4);
            coffee.AddDrink("cappucino", 5);
            coffee.AddDrink("milk", 4);
            coffee.AddDrink("tea", 5);

            Assert.IsFalse(coffee.AddDrink("Moka", 2.00));

        }

        [Test]
        public void Validate_AddDrinkSameDrinkAgain()
        {

            CoffeeMat coffee = new CoffeeMat(100, 50);

            coffee.AddDrink("Moka", 2.0);
            Assert.IsFalse(coffee.AddDrink("Moka", 2.00));
        }


        [Test]
        public void Validate_BuyDrinkWaterTankUnder80()
        {

            CoffeeMat coffee = new CoffeeMat(100, 50);

            coffee.FillWaterTank();
            coffee.AddDrink("Moka", 2.0);
            coffee.BuyDrink("Moka");
            coffee.BuyDrink("Moka");
            coffee.BuyDrink("Moka");

            Assert.AreEqual($"CoffeeMat is out of water!", coffee.BuyDrink("Moka"));
        }

        [Test]
        public void Validate_BuyDrinkNotAvalivableDrink()
        {

            CoffeeMat coffee = new CoffeeMat(200, 50);

            coffee.FillWaterTank();
            coffee.AddDrink("Moka", 2.0);
            var actual = coffee.BuyDrink("Mok");

            Assert.AreEqual($"Mok is not available!", actual);
           
        }


        [Test]
        public void Validate_BuyDrink()
        {

            CoffeeMat coffee = new CoffeeMat(200, 50);

            coffee.FillWaterTank();
            coffee.AddDrink("Moka", 2.00);
            var actual = coffee.BuyDrink("Moka");
            double price = 2;
            Assert.AreEqual($"Your bill is {price:f2}$", actual);
            Assert.AreEqual(2, coffee.Income);

        }

        [Test]
        public void Validate_CollectIncome()
        {

            CoffeeMat coffee = new CoffeeMat(200, 50);

            coffee.FillWaterTank();
            coffee.AddDrink("Moka", 2.00);
            coffee.BuyDrink("Moka");
            var actual = coffee.CollectIncome();

            Assert.AreEqual(2.00, actual);
            Assert.AreEqual(0, coffee.Income);

        }


        [Test]
        public void Validate_CollectIncome2()
        {

            CoffeeMat coffee = new CoffeeMat(200, 50);

            coffee.FillWaterTank();
            coffee.AddDrink("Moka", 2.00);
            coffee.BuyDrink("Moka");
            coffee.BuyDrink("Moka");
            var actual = coffee.CollectIncome();

            Assert.AreEqual(4.00, actual);
            Assert.AreEqual(0, coffee.Income);

        }
    }
}