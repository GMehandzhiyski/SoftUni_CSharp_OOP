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

        [Test]
        public void Validate_Constructor()
        {
            Device tv = new Device(2048);

            Assert.AreEqual(tv.MemoryCapacity, tv.AvailableMemory);
            Assert.AreEqual(0, tv.Photos);
            Assert.AreEqual(0, tv.Applications.Count);

        }

        [Test]
        public void Validate_TakePhotoTRUE()
        {
            Device tv = new Device(2048);

            Assert.IsTrue(tv.TakePhoto(1024));
            Assert.AreEqual(1024, tv.AvailableMemory);
            Assert.AreEqual(1, tv.Photos);
            
        }

        [Test]
        public void Validate_TakePhotoEqual()
        {
            Device tv = new Device(2048);

            Assert.IsTrue(tv.TakePhoto(2048));
            Assert.AreEqual(0, tv.AvailableMemory);
            Assert.AreEqual(1, tv.Photos);

        }

        [Test]
        public void Validate_TakePhotoFALSE()
        {
            Device tv = new Device(2048);


            Assert.AreEqual(tv.AvailableMemory, tv.AvailableMemory);
            Assert.AreEqual(0, tv.Photos);
            Assert.IsFalse(tv.TakePhoto(3000));
        }

        [Test]
        public void Validate_InstallAppSizeLow()
        {
            Device tv = new Device(2048);


            Assert.AreEqual($"MyApp is installed successfully. Run application?", tv.InstallApp("MyApp",128));
            Assert.AreEqual(1920, tv.AvailableMemory);
            Assert.AreEqual(1, tv.Applications.Count);
          
        }

        [Test]
        public void Validate_InstallAppSizeEqual()
        {
            Device tv = new Device(2048);


            Assert.AreEqual($"MyApp is installed successfully. Run application?", tv.InstallApp("MyApp", 2048));
            Assert.AreEqual(0, tv.AvailableMemory);
            Assert.AreEqual(1, tv.Applications.Count);

        }

        [Test]
        public void Validate_InstallAppSizeHigh()
        {
            Device tv = new Device(2048);

            Assert.Throws<InvalidOperationException>(() => tv.InstallApp("MyApp", 3000));
            Assert.AreEqual(2048, tv.AvailableMemory);
            Assert.AreEqual(0, tv.Applications.Count);

        }

        [Test]
        public void Validate_IFormatDevice()
        {
            Device tv = new Device(2048);
            tv.TakePhoto(5);
            tv.InstallApp("MyApp", 1024);
            tv.FormatDevice();

            Assert.AreEqual(0, tv.Photos);
            Assert.AreEqual(tv.MemoryCapacity, tv.AvailableMemory);
            Assert.AreEqual(0, tv.Applications.Count);

        }

        [Test]
        public void Validate_GetDeviceStatus()
        {
            Device tv = new Device(2048);
            tv.TakePhoto(5);
            tv.TakePhoto(5);
            tv.InstallApp("MyApp", 1024);
            tv.InstallApp("YouarApp", 512);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {tv.MemoryCapacity} MB, Available Memory: {tv.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {tv.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", tv.Applications)}");

            string expexted = stringBuilder.ToString().TrimEnd();

            string actual = tv.GetDeviceStatus();
            Assert.AreEqual(expexted, actual);
            

        }
    }
}