namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Assert_NewInstanceOfTeleveisionDevice_IsCreatedSuccessfully()
        {
            // Arrange
            string brand = "TestBrand";
            double price = 499.99;
            int screenWidth = 1920;
            int screenHeigth = 1080;

            // Act
            var tv = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            // Assert
            Assert.AreEqual(brand, tv.Brand);
            Assert.AreEqual(price, tv.Price);
            Assert.AreEqual(screenWidth, tv.ScreenWidth);
            Assert.AreEqual(screenHeigth, tv.ScreenHeigth);
        }

        [Test]
        public void Test_Assert_SwitchOn_ReturnsCorrectInformation()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound On";

            // Act
            string output = tv.SwitchOn();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_SwitchOn_LastMuted_ReturnsCorrectInformation()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            tv.MuteDevice();
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound Off";

            // Act
            string output = tv.SwitchOn();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_ChangeChannel_NegativeChannelThrowsException()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-1));
        }

        [Test]
        public void Test_Assert_ChangeChannel_ValidArgument_ReturnsPositiveChannel()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            int newChannel = 5;

            // Act
            int channel = tv.ChangeChannel(newChannel);

            // Assert
            Assert.AreEqual(newChannel, channel);
        }

        [Test]
        public void Test_Assert_VolumeChange_Up_ChangesTheVolumeCorrectly()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            string expectedOutput = "Volume: 23";

            // Act
            string output = tv.VolumeChange("UP", 10);

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_VolumeChange_Up_MoreThan100Volume()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            
            string expectedOutput = "Volume: 100";

            // Act
            string output = tv.VolumeChange("UP", 100);

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_VolumeChange_Down_ChangesTheVolumeCorrectly()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            string expectedOutput = "Volume: 3";

            // Act
            string output = tv.VolumeChange("DOWN", 10);

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_VolumeChange_Down_LessThanZeroVolume()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            string expectedOutput = "Volume: 0";

            // Act
            string output = tv.VolumeChange("DOWN", 14);

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Test_Assert_MuteDevice_MutedDevice_IsUnmuted()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            tv.MuteDevice(); // Mute first

            // Act
            bool isMuted = tv.MuteDevice(); // Unmute

            // Assert
            Assert.IsFalse(isMuted);
        }

        [Test]
        public void Test_Assert_MuteDevice_UnmutedDevice_IsMuted()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);

            // Act
            bool isMuted = tv.MuteDevice(); // Mute

            // Assert
            Assert.IsTrue(isMuted);
        }

        [Test]
        public void Test_Assert_ToStringMethod_ReturnsCorrectOutput()
        {
            // Arrange
            var tv = new TelevisionDevice("TestBrand", 499.99, 1920, 1080);
            string expectedOutput = "TV Device: TestBrand, Screen Resolution: 1920x1080, Price 499.99$";

            // Act
            string output = tv.ToString();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}