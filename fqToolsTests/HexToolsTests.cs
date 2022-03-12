using Microsoft.VisualStudio.TestTools.UnitTesting;
using fqTools;
using System;
using System.Text;

namespace fqTools.Tests
{
    [TestClass()]
    public class HexToolsTests
    {
        [TestMethod()]
        public void HexString2ByteArrayTest()
        {
            string hexString = "123456,AB,0xCD\tEFh";
            byte[] expected = { 0x12, 0x34, 0x56, 0xAB, 0xCD, 0xEF };
            byte[] actual = HexTools.HexString2ByteArray(hexString, ",", "0x", "h");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ByteArray2HexStringTest()
        {
            byte[] hexArray = { 0x12, 0x34, 0x56, 0xAB, 0xCD, 0xEF };
            string expected = "0x12,0x34,0x56,0xAB,0xCD,0xEF";
            string actual = HexTools.ByteArray2HexString(hexArray, ",", "0x");
            Assert.AreEqual(expected, actual);
        }
    }
}