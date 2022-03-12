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
    public class QuaternionTests
    {
        [TestMethod()]
        public void QuaternionTest()
        {
            Quaternion q = new Quaternion();
            double[] expected = { 0, 0, 0, 1 };
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], q[i]);
            }
        }

        [TestMethod()]
        public void QuaternionTest1()
        {
            Quaternion q = new Quaternion(0, 0, 0, -1, normalize: true, q4positive: true);
            double[] expected = { 0, 0, 0, 1 };
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], q[i]);
            }
        }

        [TestMethod()]
        public void QuaternionTest2()
        {
            Vector3 v = new Vector3(1, 2, 3);
            double w = 4;
            Vector3 actual_v = v.GetUnit() * Math.Sin(w / 2);
            double actual_w = Math.Cos(w / 2);
            Quaternion a = new Quaternion(v, w);
            Assert.AreEqual(actual_v[0], a.q1);
            Assert.AreEqual(actual_v[1], a.q2);
            Assert.AreEqual(actual_v[2], a.q3);
            Assert.AreEqual(actual_w, a.q4);
        }

        [TestMethod()]
        public void QuaternionTest3()
        {
            Quaternion expected = new Quaternion(1, 2, 3, 4);
            Quaternion actual = new Quaternion(expected);
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            double[] expected = { 1, 2, 3, 4 };
            Quaternion q = new Quaternion(1, 2, 3, 4, normalize: false);
            double[] actual = q.ToArray();
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Quaternion expected = new Quaternion(1, 2, 3, 4);
            Quaternion actual = new Quaternion(expected);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Quaternion expected = new Quaternion(1, 2, 3, 4);
            Quaternion actual = new Quaternion(expected).Normalize();
            Assert.AreNotEqual(expected.GetHashCode(), actual.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Quaternion q = new Quaternion();
            Assert.AreEqual("Quaternion", q.ToString());
        }

        [TestMethod()]
        public void ConjTest()
        {
            Quaternion expected = new Quaternion(1, 2, 3, 4);
            Quaternion actual = new Quaternion(-1, -2, -3, 4, normalize: false).Conj();
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void ProductTest()
        {
            Quaternion a = new Quaternion(1, 2, 3, 4, normalize: false);
            Quaternion b = new Quaternion(0.681389628021683, 0.684583761701115, 0.177045398740411, 0.188966067918216);
            Quaternion actual = a * b;
            Quaternion expected = new Quaternion(-1.214864092382425, -4.983390667965530, -0.596884304374041, 1.825829075972282);
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 1e-15);
            }
        }

        [TestMethod()]
        public void SubTest()
        {
            Quaternion a = new Quaternion(0.30337177447126, 0.40219849353411, 0.08080468869084, 0.860042173697679);
            Quaternion b = new Quaternion(0.127679440695781, 0.144878125417369, 0.268535822751569, 0.943714364147489);
            Quaternion actual = a - b;
            Quaternion expected = new Quaternion(0.272784469081098, 0.183810106081821, -0.162096132020126, 0.930337208927197);
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 1e-15);
            }
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Quaternion a = new Quaternion(1, 2, 3, 4);
            Quaternion expected = new Quaternion(0.182574185835055, 0.365148371670111, 0.547722557505166, 0.730296743340221);
            Quaternion actual = a.Normalize();
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 1e-15);
            }
        }

        [TestMethod()]
        public void ToDcmTest()
        {
            Dcm expected = Dcm.RotationX(10 * Math.PI / 180.0) * Dcm.RotationY(20 * Math.PI / 180.0) * Dcm.RotationZ(30 * Math.PI / 180.0);
            Quaternion q = new Quaternion(0.038134576474850, 0.189307857412000, 0.239298337744730, 0.951548524643789);
            Dcm actual = q.ToDcm();
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void QdotTest()
        {
            Quaternion q = new Quaternion(-0.681389628021683, -0.684583761701115, -0.177045398740411, 0.188966067918216);
            Vector3 w = new Vector3(0.1, -0.1, 0.2);
            Quaternion expected = new Quaternion(-0.067862342711221, 0.049838389469237, 0.087195276277962, 0.017544833190069, normalize: false);
            Quaternion actual = q.Qdot(w);
            for (int i = 0; i < Quaternion.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 1e-15);
            }
        }

        [TestMethod()]
        public void RotVectorTest()
        {
            Dcm rMat = Dcm.RotationX(15 * Math.PI / 180.0) * Dcm.RotationY(-20 * Math.PI / 180.0) * Dcm.RotationZ(30 * Math.PI / 180.0);
            Quaternion rQ = rMat.ToQuaternion();
            Vector3 testV = Vector3.AxisX;
            Vector3 expected = rMat * testV;
            Vector3 actual = rQ.RotVector(testV);
            for (int i = 0; i < Vector3.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 1e-15);
            }
        }

        [TestMethod()]
        public void GetVectorPartTest()
        {
            Quaternion q = new Quaternion(1, 2, 3, 4, normalize: false);
            double[] expected = { 1, 2, 3 };
            Vector3 actual = q.GetVectorPart();
            for (int i = 0; i < Vector3.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void GetAngleTest()
        {
            double expected = 45;
            Dcm dcm = Dcm.RotationX(expected * Math.PI / 180.0);
            Quaternion q = dcm.ToQuaternion();
            double angle = q.GetAngle();
            double actual = angle / (Math.PI / 180.0);
            Assert.AreEqual(expected, actual, 1e-13);
        }
    }
}