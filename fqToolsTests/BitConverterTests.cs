using Microsoft.VisualStudio.TestTools.UnitTesting;
using fqTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fqTools.Tests
{
    [TestClass()]
    public class BitConverterTests
    {
        [TestMethod()]
        public void GetBytesTestShort()
        {
            byte[] expected = new byte[] { 0xCF, 0xC7 };
            short value = -12345;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestUShort()
        {
            byte[] expected = new byte[] { 0xCF, 0xC7 };
            ushort value = 53191;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestInt32()
        {
            byte[] expected = new byte[] { 0xF8, 0xA4, 0x32, 0xEB };
            Int32 value = -123456789;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestUInt32()
        {
            byte[] expected = new byte[] { 0x7, 0x5B, 0xCD, 0x15 };
            UInt32 value = 123456789;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestInt64()
        {
            byte[] expected = new byte[] { 0xFF, 0xFF, 0xFF, 0xFD, 0xB3, 0x4F, 0xE9, 0x16 };
            Int64 value = -9876543210;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestUInt64()
        {
            byte[] expected = new byte[] { 0x00, 0x00, 0x00, 0x2, 0x4C, 0xB0, 0x16, 0xEA };
            UInt64 value = 9876543210;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestSingle()
        {
            byte[] expected = new byte[] { 0x3B, 0x80, 0x00, 0x00 };
            float value = 3.9062500E-003F;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBytesTestDouble()
        {
            byte[] expected = new byte[] { 0x01, 0xAA, 0x74, 0xFE, 0x1C, 0x1E, 0x88, 0xDF };
            double value = 1.2345678901234500E-300;
            byte[] actual;
            actual = BitConverter.GetBytes(value, true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToInt16Test()
        {
            byte[] value = new byte[] { 0xCF, 0xC7 };
            short expected = -12345;
            short actual;
            actual = BitConverter.ToInt16(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToUInt16Test()
        {
            byte[] value = new byte[] { 0xCF, 0xC7 };
            ushort expected = 53191;
            ushort actual;
            actual = BitConverter.ToUInt16(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToInt32Test()
        {
            byte[] value = new byte[] { 0xF8, 0xA4, 0x32, 0xEB };
            Int32 expected = -123456789;
            Int32 actual;
            actual = BitConverter.ToInt32(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToUInt32Test()
        {
            byte[] value = new byte[] { 0x7, 0x5B, 0xCD, 0x15 };
            UInt32 expected = 123456789;
            UInt32 actual;
            actual = BitConverter.ToUInt32(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToSingleTest()
        {
            byte[] value = new byte[] { 0x3B, 0x80, 0x00, 0x00 };
            float expected = 3.9062500E-003F;
            float actual;
            actual = BitConverter.ToSingle(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToInt64Test()
        {
            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFD, 0xB3, 0x4F, 0xE9, 0x16 };
            Int64 expected = -9876543210;
            Int64 actual;
            actual = BitConverter.ToInt64(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToUInt64Test()
        {
            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x2, 0x4C, 0xB0, 0x16, 0xEA };
            UInt64 expected = 9876543210;
            UInt64 actual;
            actual = BitConverter.ToUInt64(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToDoubleTest()
        {
            byte[] value = new byte[] { 0x01, 0xAA, 0x74, 0xFE, 0x1C, 0x1E, 0x88, 0xDF };
            double expected = 1.2345678901234500E-300;
            double actual;
            actual = BitConverter.ToDouble(value, 0, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBooleansTest()
        {
            bool[] expected = new bool[] { true, false, true, false, false, true, false, true };
            byte value = 0xA5;
            bool[] actual = BitConverter.GetBooleans(value);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}