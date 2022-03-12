using System;

namespace fqTools
{
    /// <summary>
    /// 3次元ベクトルクラス
    /// </summary>
    /// <remarks>Using Accord.Math</remarks>
    public class Vector3
    {
        public const int Length = 3;

        public double X { get; protected set; } = 0;
        public double Y { get; protected set; } = 0;
        public double Z { get; protected set; } = 0;

        /// <summary>
        /// Returns √(X^2 + Y^2 + Z^2)
        /// </summary>
        public double Magnitude { get { return Math.Sqrt(X * X + Y * Y + Z * Z); } }

        /// <summary>
        /// Returns X^2 + Y^2 + Z^2
        /// </summary>
        public double SumSq { get { return X * X + Y * Y + Z * Z; } }

        /// <summary>
        /// Gets vector [1, 0, 0]
        /// </summary>
        public static Vector3 AxisX { get { return new Vector3(1, 0, 0); } }

        /// <summary>
        /// Gets vector [0, 1, 0]
        /// </summary>
        public static Vector3 AxisY { get { return new Vector3(0, 1, 0); } }

        /// <summary>
        /// Gets vector [0, 0, 1]
        /// </summary>
        public static Vector3 AxisZ { get { return new Vector3(0, 0, 1); } }



        public Vector3()
        {
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public Vector3(double[] array)
        {
            X = array[0];
            Y = array[1];
            Z = array[2];
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }


        #region *** 演算子 ***
        /// <summary>
        /// Add
        /// </summary>
        /// <returns>a + b</returns>
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Sub
        /// </summary>
        /// <returns>a - b</returns>
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// to negative
        /// </summary>
        /// <returns>-v</returns>
        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Mult
        /// </summary>
        /// <returns>a .* b</returns>
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        /// <summary>
        /// Mult
        /// </summary>
        /// <returns>s .* v</returns>
        public static Vector3 operator *(double s, Vector3 v)
        {
            return new Vector3(s * v.X, s * v.Y, s * v.Z);
        }
        /// <summary>
        /// Mult
        /// </summary>
        /// <returns>v .* s</returns>
        public static Vector3 operator *(Vector3 v, double s)
        {
            return s * v;
        }

        /// <summary>
        /// Dev
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a ./ b</returns>
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }
        /// <summary>
        /// Dev
        /// </summary>
        /// <returns>s ./ v</returns>
        public static Vector3 operator /(double s, Vector3 v)
        {
            return new Vector3(s / v.X, s / v.Y, s / v.Z);
        }
        /// <summary>
        /// Dev
        /// </summary>
        /// <returns>v ./ s</returns>
        public static Vector3 operator /(Vector3 v, double s)
        {
            return new Vector3(v.X / s, v.Y / s, v.Z / s);
        }

        /// <summary>
        /// The cross product.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a x b</returns>
        public static Vector3 operator &(Vector3 a, Vector3 b)
        {
            return Cross(a, b);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj) => obj is Vector3 other && X == other.X && Y == other.Y && Z == other.Z;

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y, Z).GetHashCode();
        }

        public override string ToString()
        {
            return "Vector3";
        }
        #endregion


        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }

        /// <summary>
        /// 正規化ベクトルを得る.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Normalize(Vector3 v)
        {
            double n = v.Magnitude;
            return new Vector3(v.X / n, v.Y / n, v.Z / n);
        }

        /// <summary>
        /// 自身を正規化する.
        /// </summary>
        public Vector3 Normalize()
        {
            double n = this.Magnitude;
            X /= n;
            Y /= n;
            Z /= n;
            return this;
        }

        /// <summary>
        /// 正規化ベクトルを得る. 自身に変更を加えない.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetUnit()
        {
            return Normalize(this);
        }

        /// <summary>
        /// Gets the inner product.
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>a' * b</returns>
        /// <remarks>Using Accord.Math.Matrix.Dot</remarks>
        public static double Dot(Vector3 a, Vector3 b)
        {
            return Accord.Math.Matrix.Dot(a.ToArray(), b.ToArray());
        }

        /// <inheritdoc cref="Dot"/>
        public double Dot(Vector3 v)
        {
            return Dot(this, v);
        }

        /// <summary>
        /// The cross product.
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>a x b</returns>
        /// <remarks>Using Accord.Math.Matrix.Cross</remarks>
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(Accord.Math.Matrix.Cross(a.ToArray(), b.ToArray()));
        }

        /// <inheritdoc cref="Cross"/>
        public Vector3 Cross(Vector3 v)
        {
            return Cross(this, v);
        }

        /// <summary>
        /// ベクトルのなす角
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>acos( Dot(a, b) )</returns>
        public static double InnerAngle(Vector3 a, Vector3 b)
        {
            return Math.Acos(Dot(a / a.Magnitude, b / b.Magnitude));
        }

        /// <inheritdoc cref="InnerAngle"/>
        public double InnerAngle(Vector3 v)
        {
            return InnerAngle(this, v);
        }

        /// <summary>
        /// 正の要素にしたベクトルを得る
        /// </summary>
        /// <param name="v"></param>
        /// <returns>[ |x|, |y|, |z| ]</returns>
        public static Vector3 Abs(Vector3 v)
        {
            return new Vector3(Math.Abs(v.X), Math.Abs(v.Y), Math.Abs(v.Z));
        }

        /// <inheritdoc cref="Abs"/>
        public Vector3 Abs()
        {
            return Abs(this);
        }

        /// <summary>
        /// 符号のみのベクトルを得る
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Sign(Vector3 v)
        {
            return new Vector3(
                v.X > 0 ? 1 : (v.X < 0 ? -1 : 0),
                v.Y > 0 ? 1 : (v.Y < 0 ? -1 : 0),
                v.Z > 0 ? 1 : (v.Z < 0 ? -1 : 0));
        }

        /// <inheritdoc cref="Sign"/>
        public Vector3 Sign()
        {
            return Sign(this);
        }
    }
}
