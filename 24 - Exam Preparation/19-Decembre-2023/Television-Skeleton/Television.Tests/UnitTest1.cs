namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_Cosntructor()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);


            Assert.AreEqual(brand, tv.Brand);
            Assert.AreEqual(price, tv.Price);
            Assert.AreEqual(screenWidth, tv.ScreenWidth);
            Assert.AreEqual(screenHeigth, tv.ScreenHeigth);
        }

        [Test]
        public void Validate_Prop()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;
            int lastChannel = 0;
            int lastVolume = 13;
            bool lastMuted = false;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);


            Assert.AreEqual(lastChannel, tv.CurrentChannel);
            Assert.AreEqual(lastVolume, tv.Volume);
            Assert.AreEqual(lastMuted, tv.IsMuted);

        }

        [Test]
        public void Validate_SwitchOn_ON()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;
            int lastChannel = 0;
            int lastVolume = 13;
            bool lastMuted = false;
            string sound = "On";

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            string expected = $"Cahnnel {lastChannel} - Volume {lastVolume} - Sound {sound}";
            string actual = tv.SwitchOn();
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_SwitchOn_OFF()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;
            int lastChannel = 0;
            int lastVolume = 13;
            bool lastMuted = false;
            string sound = "Off";

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            tv.MuteDevice();
            string expected = $"Cahnnel {lastChannel} - Volume {lastVolume} - Sound {sound}";
            string actual = tv.SwitchOn();
            Assert.AreEqual(expected, actual);

        }


        [Test]
        public void Validate_ChangeChanneThrow()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;
      

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-1));

        }


        [Test]
        public void Validate_ChangeChanne_1()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;
          
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            var expected = 1;
            var actual = tv.ChangeChannel(expected);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeUP_10()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "UP";
            int units = 10;
            int lastVolume = 23;


            var actual = tv.VolumeChange(direction,units);
            var expected = $"Volume: {lastVolume}"; ;
            
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeUP_Minus10()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "UP";
            int units = -10;
            int lastVolume = 23;


            var actual = tv.VolumeChange(direction, units);
            var expected = $"Volume: {lastVolume}"; ;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeUP_102()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "UP";
            int units = 102;
            int lastVolume = 100;


            var actual = tv.VolumeChange(direction, units);
            var expected = $"Volume: {lastVolume}"; ;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeDown_10()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "DOWN";
            int units = 14;
            int lastVolume = 0;


            var actual = tv.VolumeChange(direction, units);
            var expected = $"Volume: {lastVolume}"; ;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeDown_Minus10()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "Down";
            int units = -10;
            int lastVolume = 13;


            var actual = tv.VolumeChange(direction, units);
            var expected = $"Volume: {lastVolume}"; ;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_VolumeChangeDown_102()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
            string direction = "Down";
            int units = 19;
            int lastVolume = 13;


            var actual = tv.VolumeChange(direction, units);
            var expected = $"Volume: {lastVolume}"; ;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Validate_MuteDevice_True()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);


            var actual = tv.MuteDevice();
            

            Assert.IsTrue(actual);

        }

        [Test]
        public void Validate_MuteDevice_False()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            tv.MuteDevice();
            var actual = tv.MuteDevice();


            Assert.IsFalse(actual);

        }

        [Test]
        public void Validate_ToString()
        {
            string brand = "LG";
            double price = 100;
            int screenWidth = 1024;
            int screenHeigth = 1048;

            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
         

            var actual = tv.ToString();
            var expected = $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$";

            Assert.AreEqual(expected, actual);

        }


    }
}
