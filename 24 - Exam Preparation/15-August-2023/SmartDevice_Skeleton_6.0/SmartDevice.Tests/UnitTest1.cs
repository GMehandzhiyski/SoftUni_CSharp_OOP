namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Validate_CreateNewStation_NameNull()
        //{
        //    Assert.Throws<ArgumentException>(() => { RailwayStation newRailway= new RailwayStation(null); });
        //}

        [Test]
        public void Validate_Ctor()
        {
            Device newDevice = new Device(3);

            var expected = 3;
            //var actual = newDevice.MemoryCapacity;

            Assert.AreEqual(expected, newDevice.MemoryCapacity);
            Assert.AreEqual(expected, newDevice.AvailableMemory );
            Assert.AreEqual(0, newDevice.Photos);
            Assert.AreEqual(0, newDevice.Applications.Count);
        }

        [Test]
        public void Validate_CheckAvalivableMemoryProp()
        {
            Device newDevice = new Device(3);

            var expected = 3;
            var actual = newDevice.AvailableMemory;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_CheckPhotosProp()
        {
            Device newDevice = new Device(3);

            var expected = 0;
            var actual = newDevice.Photos;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_CheckApplicationsProp()
        {
            Device newDevice = new Device(3);

            var expected = 0;
            var actual = newDevice.Applications.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_TakePhotoBigger()
        {
            Device newDevice = new Device(3);

            var expected = false;
            var actual = newDevice.TakePhoto(5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_TakePhotoEqual()
        {
            int memoryCapacity = 2048;
            int photosSize = 100;
            Device newDevice = new Device(memoryCapacity);

            
            var actual = newDevice.TakePhoto(photosSize);

            Assert.IsTrue(actual);
            Assert.AreEqual(memoryCapacity - photosSize, newDevice.AvailableMemory);
            Assert.AreEqual(1, newDevice.Photos);
        }

        [Test]
        public void Validate_TakePhotolower()
        {
            Device newDevice = new Device(3);

            var expected = true;
            var actual = newDevice.TakePhoto(3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_InstallAppThrow()
        {
            Device newDevice = new Device(3);

            Assert.Throws<InvalidOperationException>(() => newDevice.InstallApp("AAA", 5));
        }


        //Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
        [Test]
        public void Validate_InstallAppSizelower()
        {
            Device newDevice = new Device(3000);

            //var expected = true;
            var actual = newDevice.InstallApp("MyApp", 2048);
            var leftMemory = 3000 - 2048;

            Assert.AreEqual((leftMemory), newDevice.AvailableMemory);
            Assert.AreEqual(1, newDevice.Applications.Count);
            Assert.AreEqual($"MyApp is installed successfully. Run application?", actual);
        }

        [Test]
        public void Validate_FormatDevicePhotos()
        {
            Device newDevice = new Device(3300);
            newDevice.TakePhoto(2);
            newDevice.InstallApp("MyApp", 2);

            newDevice.FormatDevice();

            var expected = 0;
            var actual = newDevice.Photos;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_FormatDeviceApplication()
        {
            Device newDevice = new Device(3300);
            newDevice.TakePhoto(2);
            newDevice.InstallApp("MyApp", 2);

            newDevice.FormatDevice();

            var expected = 0;
            var actual = newDevice.Applications.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_FormatDeviceAvaivableMemory()
        {
            Device newDevice = new Device(3300);
            newDevice.TakePhoto(2);
            newDevice.InstallApp("MyApp", 2);

            newDevice.FormatDevice();

            var expected = newDevice.MemoryCapacity;
            var actual = newDevice.AvailableMemory;

            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void Validate_GetDeviceStatus()
        {
            Device newDevice = new Device(3300);
            newDevice.TakePhoto(2);
            newDevice.InstallApp("MyApp", 2);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {newDevice.MemoryCapacity} MB, Available Memory: {newDevice.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {newDevice.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", newDevice.Applications)}");

            var expected = stringBuilder.ToString().TrimEnd();
            var actual = newDevice.GetDeviceStatus();

            Assert.AreEqual(expected,  actual);
        }

    }
}