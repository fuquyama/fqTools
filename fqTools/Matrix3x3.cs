using System;

namespace fqTools
{
    /// <summary>
    /// 3 x 3 行列クラス
    /// <para>| m11 m12 m13 |</para>
    /// <para>| m21 m22 m23 |</para>
    /// <para>| m31 m32 m33 |</para>
    /// </summary>
    /// <remarks>Using Accord.Math</remarks>
    public class Matrix3x3
    {
        /// <summary>
        /// 行サイズ
        /// </summary>
        public const int RowLength = 3;

        /// <summary>
        /// 列サイズ
        /// </summary>
        public const int ColLength = 3;

        public double m11 { get; protected set; } = 0;
        public double m12 { get; protected set; } = 0;
        public double m13 { get; protected set; } = 0;
        public double m21 { get; protected set; } = 0;
        public double m22 { get; protected set; } = 0;
        public double m23 { get; protected set; } = 0;
        public double m31 { get; protected set; } = 0;
        public double m32 { get; protected set; } = 0;
        public double m33 { get; protected set; } = 0;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Matrix3x3()
        {
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="m"></param>
        public Matrix3x3(Matrix3x3 m)
        {
            m11 = m.m11;
            m12 = m.m12;
            m13 = m.m13;
            m21 = m.m21;
            m22 = m.m22;
            m23 = m.m23;
            m31 = m.m31;
            m32 = m.m32;
            m33 = m.m33;
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="m"></param>
        public Matrix3x3(double[,] m)
        {
            m11 = m[0, 0];
            m12 = m[0, 1];
            m13 = m[0, 2];
            m21 = m[1, 0];
            m22 = m[1, 1];
            m23 = m[1, 2];
            m31 = m[2, 0];
            m32 = m[2, 1];
            m33 = m[2, 2];
        }

        /// <summary>
        /// 単位行列を作成.
        /// </summary>
        /// <returns></returns>
        public static Matrix3x3 Identity()
        {
            Matrix3x3 m = new Matrix3x3();
            m.m11 = 1;
            m.m22 = 1;
            m.m33 = 1;
            return m;
        }

        /// <summary>
        /// 対角行列を作成.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix3x3 Diag(double[] v)
        {
            Matrix3x3 m = new Matrix3x3();
            m.m11 = v[0];
            m.m22 = v[1];
            m.m33 = v[2];
            return m;
        }

        /// <summary>
        /// 対角行列を作成.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix3x3 Diag(Vector3 v)
        {
            Matrix3x3 m = new Matrix3x3();
            m.m11 = v.X;
            m.m22 = v.Y;
            m.m33 = v.Z;
            return m;
        }

        /// <summary>
        /// 対角行列を作成.
        /// </summary>
        /// <param name="m11"></param>
        /// <param name="m22"></param>
        /// <param name="m33"></param>
        /// <returns></returns>
        public static Matrix3x3 Diag(double m11, double m22, double m33)
        {
            Matrix3x3 m = new Matrix3x3();
            m.m11 = m11;
            m.m22 = m22;
            m.m33 = m33;
            return m;
        }

        public double[,] ToArray()
        {
            return new double[,] { { m11, m12, m13 }, { m21, m22, m23 }, { m31, m32, m33 } };
        }

        public double[][] ToOldArray()
        {
            return new double[][] {
                new double[] { m11, m12, m13 },
                new double[] { m21, m22, m23 },
                new double[] { m31, m32, m33 }
            };
        }


        /// <summary>
        /// インデクサ
        /// <para>0 オリジン</para>
        /// </summary>
        /// <param name="row">行 : 0 or 1 or 2</param>
        /// <param name="col">列 : 0 or 1 or 2</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double this[int row, int col]
        {
            get
            {
                switch (row * 3 + col)
                {
                    case 0: return m11;
                    case 1: return m12;
                    case 2: return m13;
                    case 3: return m21;
                    case 4: return m22;
                    case 5: return m23;
                    case 6: return m31;
                    case 7: return m32;
                    case 8: return m33;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (row * 3 + col)
                {
                    case 0: m11 = value; break;
                    case 1: m12 = value; break;
                    case 2: m13 = value; break;
                    case 3: m21 = value; break;
                    case 4: m22 = value; break;
                    case 5: m23 = value; break;
                    case 6: m31 = value; break;
                    case 7: m32 = value; break;
                    case 8: m33 = value; break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 行 インデクサ
        /// <para>0 オリジン</para>
        /// </summary>
        /// <param name="row">行 : 0 or 1 or 2</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double[] this[int row]
        {
            get
            {
                switch (row)
                {
                    case 0: return new double[] { m11, m12, m13 };
                    case 1: return new double[] { m21, m22, m23 };
                    case 2: return new double[] { m31, m32, m33 };
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (row)
                {
                    case 0: m11 = value[0]; m12 = value[1]; m13 = value[2]; break;
                    case 1: m21 = value[0]; m22 = value[1]; m23 = value[2]; break;
                    case 2: m31 = value[0]; m32 = value[1]; m33 = value[2]; break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        #region *** 演算子 ***
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns>a .+ b</returns>
        public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b)
        {
            Matrix3x3 apb = new Matrix3x3();
            apb.m11 = a.m11 + b.m11;
            apb.m12 = a.m12 + b.m12;
            apb.m13 = a.m13 + b.m13;
            apb.m21 = a.m21 + b.m21;
            apb.m22 = a.m22 + b.m22;
            apb.m23 = a.m23 + b.m23;
            apb.m31 = a.m31 + b.m31;
            apb.m32 = a.m32 + b.m32;
            apb.m33 = a.m33 + b.m33;
            return apb;
        }

        /// <summary>
        /// Sub
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns>a .- b</returns>
        public static Matrix3x3 operator -(Matrix3x3 a, Matrix3x3 b)
        {
            Matrix3x3 amb = new Matrix3x3();
            amb.m11 = a.m11 - b.m11;
            amb.m12 = a.m12 - b.m12;
            amb.m13 = a.m13 - b.m13;
            amb.m21 = a.m21 - b.m21;
            amb.m22 = a.m22 - b.m22;
            amb.m23 = a.m23 - b.m23;
            amb.m31 = a.m31 - b.m31;
            amb.m32 = a.m32 - b.m32;
            amb.m33 = a.m33 - b.m33;
            return amb;
        }

        /// <summary>
        /// 3x3行列の掛け算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Dot</remarks>
        public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
        {
            return new Matrix3x3(Accord.Math.Matrix.Dot(a.ToArray(), b.ToArray()));
        }

        public static Matrix3x3 operator *(double s, Matrix3x3 m)
        {
            Matrix3x3 sm = new Matrix3x3(m);
            sm.m11 *= s;
            sm.m12 *= s;
            sm.m13 *= s;
            sm.m21 *= s;
            sm.m22 *= s;
            sm.m23 *= s;
            sm.m31 *= s;
            sm.m32 *= s;
            sm.m33 *= s;
            return sm;
        }

        public static Vector3 operator *(Matrix3x3 m, Vector3 v)
        {
            double vx, vy, vz;
            vx = m.m11 * v.X + m.m12 * v.Y + m.m13 * v.Z;
            vy = m.m21 * v.X + m.m22 * v.Y + m.m23 * v.Z;
            vz = m.m31 * v.X + m.m32 * v.Y + m.m33 * v.Z;
            return new Vector3(vx, vy, vz);
        }

        public static Matrix3x3 operator *(Matrix3x3 m, double s)
        {
            return s * m;
        }

        /// <summary>
        /// 3x3行列の割り算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Inverse and Dot</remarks>
        public static Matrix3x3 operator /(Matrix3x3 a, Matrix3x3 b)
        {
            double[,] invM = Accord.Math.Matrix.Inverse(b.ToArray());
            return new Matrix3x3(Accord.Math.Matrix.Dot(a.ToArray(), invM));
        }

        /// <summary>
        /// 3x3逆行列のスカラー倍
        /// </summary>
        /// <param name="s"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Inverse</remarks>
        public static Matrix3x3 operator /(double s, Matrix3x3 m)
        {
            Matrix3x3 invM = new Matrix3x3(Accord.Math.Matrix.Inverse(m.ToArray()));
            return s * invM;
        }

        public static Matrix3x3 operator /(Matrix3x3 m, double s)
        {
            Matrix3x3 md = new Matrix3x3(m);
            md.m11 /= s;
            md.m12 /= s;
            md.m13 /= s;
            md.m21 /= s;
            md.m22 /= s;
            md.m23 /= s;
            md.m31 /= s;
            md.m32 /= s;
            md.m33 /= s;
            return md;
        }

        public static bool operator ==(Matrix3x3 a, Matrix3x3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Matrix3x3 a, Matrix3x3 b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix3x3 other
                && this.m11 == other.m11 && this.m12 == other.m12 && this.m13 == other.m13
                && this.m21 == other.m21 && this.m22 == other.m22 && this.m23 == other.m23
                && this.m31 == other.m31 && this.m32 == other.m32 && this.m33 == other.m33;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(m11, m22, m33).GetHashCode();
        }

        public override string ToString()
        {
            return "Matrix3x3";
        }
        #endregion

        /// <summary>
        /// 対角要素を抜き出す.
        /// </summary>
        /// <returns>[m11, m22, m33]</returns>
        public double[] Diag()
        {
            return new double[] { m11, m22, m33 };
        }

        /// <summary>
        /// 1行目を取り出す.
        /// </summary>
        /// <returns></returns>
        public double[] GetRow1()
        {
            return new double[] { m11, m12, m13 };
        }

        /// <summary>
        /// 2行目を取り出す.
        /// </summary>
        /// <returns></returns>
        public double[] GetRow2()
        {
            return new double[] { m21, m22, m23 };
        }

        /// <summary>
        /// 3行目を取り出す.
        /// </summary>
        /// <returns></returns>
        public double[] GetRow3()
        {
            return new double[] { m31, m32, m33 };
        }

        /// <summary>
        /// 1行目にセット.
        /// </summary>
        /// <param name="m11"></param>
        /// <param name="m12"></param>
        /// <param name="m13"></param>
        public void SetRow1(double m11, double m12, double m13)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
        }
        /// <summary>
        /// 1行目にセット.
        /// </summary>
        /// <param name="v"></param>
        public void SetRow1(Vector3 v)
        {
            this.m11 = v.X;
            this.m12 = v.Y;
            this.m13 = v.Z;
        }

        /// <summary>
        /// 2行目にセット.
        /// </summary>
        /// <param name="m21"></param>
        /// <param name="m22"></param>
        /// <param name="m23"></param>
        public void SetRow2(double m21, double m22, double m23)
        {
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
        }
        /// <summary>
        /// 2行目にセット.
        /// </summary>
        /// <param name="v"></param>
        public void SetRow2(Vector3 v)
        {
            this.m21 = v.X;
            this.m22 = v.Y;
            this.m23 = v.Z;
        }

        /// <summary>
        /// 3行目にセット.
        /// </summary>
        /// <param name="m31"></param>
        /// <param name="m32"></param>
        /// <param name="m33"></param>
        public void SetRow3(double m31, double m32, double m33)
        {
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
        }
        /// <summary>
        /// 3行目にセット.
        /// </summary>
        /// <param name="v"></param>
        public void SetRow3(Vector3 v)
        {
            this.m31 = v.X;
            this.m32 = v.Y;
            this.m33 = v.Z;
        }

        /// <summary>
        /// 逆行列
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Inverse</remarks>
        public static Matrix3x3 Inverse(Matrix3x3 m)
        {
            return new Matrix3x3(Accord.Math.Matrix.Inverse(m.ToArray()));
        }

        /// <inheritdoc cref="Inverse"/>
        public Matrix3x3 Inverse()
        {
            return Inverse(this);
        }

        /// <summary>
        /// 疑似逆行列
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.PseudoInverse</remarks>
        public static Matrix3x3 PseudoInverse(Matrix3x3 m)
        {
            return new Matrix3x3(Accord.Math.Matrix.PseudoInverse(m.ToArray()));
        }

        /// <inheritdoc cref="PseudoInverse"/>
        public Matrix3x3 PseudoInverse()
        {
            return PseudoInverse(this);
        }

        /// <summary>
        /// 転置行列
        /// </summary>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Transpose</remarks>
        public static Matrix3x3 Transpose(Matrix3x3 m)
        {
            return new Matrix3x3(Accord.Math.Matrix.Transpose(m.ToArray()));
        }

        /// <inheritdoc cref="Transpose"/>
        public Matrix3x3 Transpose()
        {
            return Transpose(this);
        }

        /// <summary>
        /// 行列式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <remarks>Using Accord.Math.Matrix.Determinant</remarks>
        public static double Det(Matrix3x3 m)
        {
            return Accord.Math.Matrix.Determinant(m.ToArray());
        }

        /// <inheritdoc cref="Det"/>
        public double Det()
        {
            return Det(this);
        }

    }
}
