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
    public class DcmTests
    {
        [TestMethod()]
        public void DcmTest()
        {
            Dcm dcm = new Dcm();
            Matrix3x3 mat = Matrix3x3.Identity();
            CollectionAssert.AreEqual(mat.ToArray(), dcm.ToArray());
        }

        [TestMethod()]
        public void DcmTest1()
        {
            Matrix3x3 mat = new Matrix3x3(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            Dcm dcm = new Dcm(mat);
            CollectionAssert.AreEqual(mat.ToArray(), dcm.ToArray());
        }

        [TestMethod()]
        public void DcmTest2()
        {
            double[,] mat = new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Dcm dcm = new Dcm(mat);
            CollectionAssert.AreEqual(mat, dcm.ToArray());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Dcm dcm = new Dcm();
            Assert.AreEqual("DCM", dcm.ToString());
        }

        [TestMethod()]
        public void RotationXTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { 1, 0, 0 }, { 0, d, d }, { 0, -d, d } };
            Dcm dcm = Dcm.RotationX(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void RotationYTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { d, 0, -d }, { 0, 1, 0 }, { d, 0, d } };
            Dcm dcm = Dcm.RotationY(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void RotationZTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { d, d, 0 }, { -d, d, 0 }, { 0, 0, 1 } };
            Dcm dcm = Dcm.RotationZ(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void TransposeTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { d, -d, 0 }, { d, d, 0 }, { 0, 0, 1 } };
            Dcm dcm = Dcm.RotationZ(45.0 * Math.PI / 180.0);
            dcm = dcm.Transpose();
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void RotateXTest()
        {
            double d = 1 / Math.Sqrt(2);
            Dcm dcm = new Dcm();
            double[,] mat = new double[,] { { 1, 0, 0 }, { 0, d, d }, { 0, -d, d } };
            dcm.RotateX(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void RotateYTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { d, 0, -d }, { 0, 1, 0 }, { d, 0, d } };
            Dcm dcm = new Dcm();
            dcm.RotateY(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void RotateZTest()
        {
            double d = 1 / Math.Sqrt(2);
            double[,] mat = new double[,] { { d, d, 0 }, { -d, d, 0 }, { 0, 0, 1 } };
            Dcm dcm = new Dcm();
            dcm.RotateZ(45 * Math.PI / 180.0);
            for (int i = 0; i < Dcm.RowLength; i++)
            {
                for (int j = 0; j < Dcm.ColLength; j++)
                {
                    Assert.AreEqual(mat[i, j], dcm[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void ToQuaternionTest()
        {
            Dcm dcm = new Dcm();
            dcm.RotateZ(30 * Math.PI / 180.0);
            dcm.RotateY(20 * Math.PI / 180.0);
            dcm.RotateX(10 * Math.PI / 180.0);
            Quaternion q = dcm.ToQuaternion();
            Assert.AreEqual(0.038134576474850, q.q1, 1e-15);
            Assert.AreEqual(0.189307857412000, q.q2, 1e-15);
            Assert.AreEqual(0.239298337744730, q.q3, 1e-15);
            Assert.AreEqual(0.951548524643789, q.q4, 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest123()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateX(expected[0]);
            dcm.RotateY(expected[1]);
            dcm.RotateZ(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R123);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest231()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateY(expected[0]);
            dcm.RotateZ(expected[1]);
            dcm.RotateX(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R231);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest312()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateZ(expected[0]);
            dcm.RotateX(expected[1]);
            dcm.RotateY(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R312);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest132()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateX(expected[0]);
            dcm.RotateZ(expected[1]);
            dcm.RotateY(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R132);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest213()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateY(expected[0]);
            dcm.RotateX(expected[1]);
            dcm.RotateZ(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R213);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest321()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateZ(expected[0]);
            dcm.RotateY(expected[1]);
            dcm.RotateX(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R321);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest121()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateX(expected[0]);
            dcm.RotateY(expected[1]);
            dcm.RotateX(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R121);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest232()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateY(expected[0]);
            dcm.RotateZ(expected[1]);
            dcm.RotateY(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R232);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest313()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateZ(expected[0]);
            dcm.RotateX(expected[1]);
            dcm.RotateZ(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R313);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest131()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateX(expected[0]);
            dcm.RotateZ(expected[1]);
            dcm.RotateX(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R131);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest212()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateY(expected[0]);
            dcm.RotateX(expected[1]);
            dcm.RotateY(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R212);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

        [TestMethod()]
        public void ToEulerTest323()
        {
            double[] expected = { 30 * Math.PI / 180.0, 20 * Math.PI / 180.0, 10 * Math.PI / 180.0 };
            Dcm dcm = new Dcm();
            dcm.RotateZ(expected[0]);
            dcm.RotateY(expected[1]);
            dcm.RotateZ(expected[2]);
            double[] actual = dcm.ToEuler(Dcm.Euler.R323);
            Assert.AreEqual(expected[0], actual[0], 1e-15);
            Assert.AreEqual(expected[1], actual[1], 1e-15);
            Assert.AreEqual(expected[2], actual[2], 1e-15);
        }

    }
}