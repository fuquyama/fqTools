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
    public class Vector3Tests
    {
        [TestMethod()]
        public void Vector3Test()
        {
            Vector3 actual = new Vector3();
            Vector3 expected = new Vector3(0, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Vector3Test1()
        {
            Vector3 actual = new Vector3(1, 0, 0);
            Vector3 expected = Vector3.AxisX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Vector3Test2()
        {
            Vector3 expected = new Vector3(1, 2, 3);
            Vector3 actual = new Vector3(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Vector3Test3()
        {
            double[] v = { 1, 2, 3 };
            Vector3 actual = new Vector3(v);
            Vector3 expected = new Vector3(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(!Vector3.AxisY.Equals(Vector3.AxisZ));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.AreNotEqual(Vector3.AxisX.GetHashCode(), Vector3.AxisY.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Vector3 v = new Vector3();
            Assert.AreEqual("Vector3", v.ToString());
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            double[] expected = { 1, 2, 3 };
            Vector3 vector = new Vector3(1, 2, 3);
            CollectionAssert.AreEqual(expected, vector.ToArray());
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            double[] expected = new double[] { 0.207390338946085, 0.518475847365213, 0.829561355784340 };
            Vector3 vec = new Vector3(2, 5, 8);
            vec.Normalize();
            Assert.AreEqual(expected[0], vec.X, 1e-15);
            Assert.AreEqual(expected[1], vec.Y, 1e-15);
            Assert.AreEqual(expected[2], vec.Z, 1e-15);
        }

        [TestMethod()]
        public void SumSqTest()
        {
            double expected = 2 * 2 + 5 * 5 + 8 * 8;
            Vector3 vec = new Vector3(2, 5, 8);
            double actual = vec.SumSq;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUnitTest()
        {
            double[] expected = new double[] { 0.207390338946085, 0.518475847365213, 0.829561355784340 };
            Vector3 vec = new Vector3(2, 5, 8);
            Vector3 actual = vec.GetUnit();
            Assert.AreEqual(2, vec.X);
            Assert.AreEqual(5, vec.Y);
            Assert.AreEqual(8, vec.Z);
            Assert.AreEqual(expected[0], actual.X, 1e-15);
            Assert.AreEqual(expected[1], actual.Y, 1e-15);
            Assert.AreEqual(expected[2], actual.Z, 1e-15);
        }

        [TestMethod()]
        public void DotTest()
        {
            Vector3 a = new Vector3(1, 2, 3);
            Vector3 b = new Vector3(4, 5, 6);
            double expected = 32;
            Assert.AreEqual(expected, a.Dot(b));
        }

        [TestMethod()]
        public void CrossTest()
        {
            Vector3 vec1 = new Vector3(1, 2, 3);
            Vector3 vec2 = new Vector3(4, 5, 6);
            Vector3 expected = new Vector3(-3, 6, -3);
            Assert.AreEqual(expected, vec1.Cross(vec2));
            Assert.AreEqual(expected, vec1 & vec2);
        }

        [TestMethod()]
        public void InnerAngleTest()
        {
            double expected = 0.225726128552734;
            Vector3 vec1 = new Vector3(1, 2, 3);
            Vector3 vec2 = new Vector3(4, 5, 6);
            Assert.AreEqual(expected, vec1.InnerAngle(vec2), 1e-15);
        }

        [TestMethod()]
        public void SignTest()
        {
            Vector3 expected = new Vector3(-1, 1, 0);
            Vector3 actual = new Vector3(-0.1, 555, -0);
            Assert.AreEqual(expected, actual.Sign());
        }

        [TestMethod()]
        public void AbsTest()
        {
            Vector3 actual = new Vector3(-5, 4, -3);
            Vector3 expected = new Vector3(5, 4, 3);
            Assert.AreEqual(expected, actual.Abs());
        }
    }
}