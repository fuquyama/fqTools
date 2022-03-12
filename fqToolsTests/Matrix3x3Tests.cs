using Microsoft.VisualStudio.TestTools.UnitTesting;
using fqTools;
using System;

namespace fqTools.Tests
{
    [TestClass()]
    public class Matrix3x3Tests
    {
        [TestMethod()]
        public void Matrix3x3Test()
        {
            Matrix3x3 actual = new Matrix3x3();
            double[,] expected = new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void Matrix3x3Test1()
        {
            double[,] expected = new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Matrix3x3 actual = new Matrix3x3(expected);
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void Matrix3x3Test2()
        {
            double[,] expected = new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };
            Matrix3x3 mat = new Matrix3x3(expected);
            Matrix3x3 actual = new Matrix3x3(mat);
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void IdentityTest()
        {
            double[,] expected = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Matrix3x3 actual = Matrix3x3.Identity();
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void DiagTest()
        {
            double[,] expected = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Matrix3x3 actual = Matrix3x3.Diag(new double[] { 1, 1, 1 });
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void DiagTest1()
        {
            double[,] expected = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Vector3 diag = new Vector3(1, 1, 1);
            Matrix3x3 actual = Matrix3x3.Diag(diag);
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void DiagTest2()
        {
            double[,] expected = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Matrix3x3 actual = Matrix3x3.Diag(1, 1, 1);
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod()]
        public void ToOldArrayTest()
        {
            double[][] expected = new double[][] { new double[] { 9, 8, 7 }, new double[] { 6, 5, 4 }, new double[] { 3, 2, 1 } };
            Matrix3x3 mat = new Matrix3x3(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            double[][] actual = mat.ToOldArray();
            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
            CollectionAssert.AreEqual(expected[2], actual[2]);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            Matrix3x3 mat2 = new Matrix3x3(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            Assert.IsTrue(mat1.Equals(mat2));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 mat2 = new Matrix3x3(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            Assert.AreNotEqual(mat1.GetHashCode(), mat2.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Assert.AreEqual("Matrix3x3", mat1.ToString());
        }

        [TestMethod()]
        public void DiagTest3()
        {
            Matrix3x3 mat = Matrix3x3.Identity();
            double[] expected = new double[] { 1, 1, 1 };
            CollectionAssert.AreEqual(expected, mat.Diag());
        }

        [TestMethod()]
        public void GetRow1Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            double[] expected = { 1, 2, 3 };
            double[] actual = mat1.GetRow1();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetRow2Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            double[] expected = { 4, 5, 6 };
            double[] actual = mat1.GetRow2();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetRow3Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            double[] expected = { 7, 8, 9 };
            double[] actual = mat1.GetRow3();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetRow1Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { -1, -2, -3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            mat1.SetRow1(new Vector3(-1, -2, -3));
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void SetRow1Test1()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { -1, -2, -3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            mat1.SetRow1(-1, -2, -3);
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void SetRow2Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 1, 2, 3 }, { -4, -5, -6 }, { 7, 8, 9 } });
            mat1.SetRow2(new Vector3(-4, -5, -6));
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void SetRow2Test1()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 1, 2, 3 }, { -4, -5, -6 }, { 7, 8, 9 } });
            mat1.SetRow2(-4, -5, -6);
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void SetRow3Test()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { -7, -8, -9 } });
            mat1.SetRow3(new Vector3(-7, -8, -9));
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void SetRow3Test1()
        {
            Matrix3x3 mat1 = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { -7, -8, -9 } });
            mat1.SetRow3(-7, -8, -9);
            Assert.AreEqual(expected, mat1);
        }

        [TestMethod()]
        public void InverseTest()
        {
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 0.625, -0.5, 0.125 }, { -0.5, 1.0, -0.5 }, { 0.125, -0.5, 0.625 } });
            Matrix3x3 a = new Matrix3x3(new double[,] { { 3, 2, 1 }, { 2, 3, 2 }, { 1, 2, 3 } });
            Matrix3x3 actual = a.Inverse();
            for (int i = 0; i < Matrix3x3.RowLength; i++)
            {
                for (int j = 0; j < Matrix3x3.ColLength; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void PseudoInverseTest()
        {
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 0.625, -0.5, 0.125 }, { -0.5, 1.0, -0.5 }, { 0.125, -0.5, 0.625 } });
            Matrix3x3 a = new Matrix3x3(new double[,] { { 3, 2, 1 }, { 2, 3, 2 }, { 1, 2, 3 } });
            Matrix3x3 actual = a.PseudoInverse();
            for (int i = 0; i < Matrix3x3.RowLength; i++)
            {
                for (int j = 0; j < Matrix3x3.ColLength; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j], 1e-15);
                }
            }
        }

        [TestMethod()]
        public void TransposeTest()
        {
            Matrix3x3 mat = new Matrix3x3(new double[,] { { 0, -1, -2 }, { -3, 4, 5 }, { -6, -7, 8 } });
            Matrix3x3 actual = Matrix3x3.Transpose(mat);
            Matrix3x3 expected = new Matrix3x3(new double[,] { { 0, -3, -6 }, { -1, 4, -7 }, { -2, 5, 8 } });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DetTest()
        {
            Matrix3x3 a = new Matrix3x3(new double[,] { { 3, 2, 1 }, { 2, 3, 2 }, { 1, 2, 3 } });
            double detA = a.m11 * a.m22 * a.m33 + a.m21 * a.m32 * a.m13
                + a.m31 * a.m12 * a.m23 - a.m11 * a.m32 * a.m23
                - a.m21 * a.m12 * a.m33 - a.m31 * a.m22 * a.m13;
            Assert.AreEqual(detA, a.Det(), 1e-15);
        }
    }
}