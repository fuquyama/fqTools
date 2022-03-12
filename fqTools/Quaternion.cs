using System;

namespace fqTools
{
    /// <summary>
    /// Rotation quaternion class.
    /// q1, q2,q3 is vector part, q4 is scalar part.
    /// </summary>
    public class Quaternion
    {
        public const int Length = 4;

        /// <summary>
        /// nx * sin(θ/2)
        /// </summary>
        public double q1 { get; protected set; } = 0;
        /// <summary>
        /// ny * sin(θ/2)
        /// </summary>
        public double q2 { get; protected set; } = 0;
        /// <summary>
        /// nz * sin(θ/2)
        /// </summary>
        public double q3 { get; protected set; } = 0;
        /// <summary>
        /// cos(θ/2)
        /// </summary>
        public double q4 { get; protected set; } = 1;

        /// <summary>
        /// クォータニオンの生成.
        /// <para>[ 0 0 0 1 ]</para>
        /// </summary>
        public Quaternion()
        {
        }

        /// <summary>
        /// クォータニオンの生成.
        /// </summary>
        /// <param name="q1">q1</param>
        /// <param name="q2">q2</param>
        /// <param name="q3">q3</param>
        /// <param name="q4">q4</param>
        /// <param name="normalize">正規化</param>
        /// <param name="q4positive">q4成分を + にする</param>
        public Quaternion(double q1, double q2, double q3, double q4, bool normalize = true, bool q4positive = true)
        {
            this.q1 = q1; this.q2 = q2; this.q3 = q3; this.q4 = q4;
            if (normalize)
            {
                Normalize(q4positive);
            }
        }

        /// <summary>
        /// 回転軸と回転角からクォータニオンを生成.
        /// </summary>
        /// <param name="v">回転軸ベクトル</param>
        /// <param name="angle">回転角 (radians)</param>
        public Quaternion(Vector3 v, double angle)
        {
            Vector3 nv = v.GetUnit();
            double thDiv2 = angle / 2;
            double s = Math.Sin(thDiv2);

            q1 = nv.X * s;
            q2 = nv.Y * s;
            q3 = nv.Z * s;
            q4 = Math.Cos(thDiv2);
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="q"></param>
        public Quaternion(Quaternion q)
        {
            q1 = q.q1; q2 = q.q2; q3 = q.q3; q4 = q.q4;
        }


        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="i">0 ～ 3</param>
        /// <returns></returns>
        public double this[int i]
        {
            //set
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            q1 = value;
            //            break;
            //        case 1:
            //            q2 = value;
            //            break;
            //        case 2:
            //            q3 = value;
            //            break;
            //        case 3:
            //            q4 = value;
            //            break;
            //        default:
            //            throw new IndexOutOfRangeException();
            //    }
            //}
            get
            {
                switch (i)
                {
                    case 0:
                        return q1;
                    case 1:
                        return q2;
                    case 2:
                        return q3;
                    case 3:
                        return q4;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }


        /// <summary>
        /// 配列化
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            return new double[] { q1, q2, q3, q4 };
        }


        #region *** 演算子 ***

        /// <summary>
        /// q ⊗ p
        /// </summary>
        /// <param name="q"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion q, Quaternion p)
        {
            return new Quaternion(
                 q.q4 * p.q1 - q.q3 * p.q2 + q.q2 * p.q3 + q.q1 * p.q4,
                 q.q3 * p.q1 + q.q4 * p.q2 - q.q1 * p.q3 + q.q2 * p.q4,
                -q.q2 * p.q1 + q.q1 * p.q2 + q.q4 * p.q3 + q.q3 * p.q4,
                -q.q1 * p.q1 - q.q2 * p.q2 - q.q3 * p.q3 + q.q4 * p.q4);
        }

        /// <summary>
        /// q - p = p^-1 ⊗ q = Δq
        /// <para>q = p ⊗ Δq</para>
        /// </summary>
        /// <param name="q"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Quaternion operator -(Quaternion q, Quaternion p)
        {
            return p.Conj() * q;
        }


        public override bool Equals(object obj) => obj is Quaternion other
            && q1 == other.q1 && q2 == other.q2 && q3 == other.q3 && q4 == other.q4;

        public static bool operator ==(Quaternion a, Quaternion b) => a.Equals(b);

        public static bool operator !=(Quaternion a, Quaternion b) => !a.Equals(b);

        #endregion

        public override int GetHashCode()
        {
            return Tuple.Create(q1, q2, q3, q4).GetHashCode();
        }


        public override string ToString()
        {
            return "Quaternion";
        }

        /// <summary>
        /// 共益クォータニオン
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion Conj(Quaternion q)
        {
            return new Quaternion(-q.q1, -q.q2, -q.q3, q.q4);
        }

        /// <inheritdoc cref="Conj"/>
        public Quaternion Conj()
        {
            return Conj(this);
        }

        /// <summary>
        /// q4成分を + にする.
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion Q4Positive(Quaternion q)
        {
            if (q.q4 > 0)
            {
                return new Quaternion(q);
            }
            else
            {
                return new Quaternion(-q.q1, -q.q2, -q.q3, -q.q4);
            }
        }

        /// <inheritdoc cref="Q4Positive"/>
        public Quaternion Q4Positive()
        {
            if (q4 > 0)
            {
                return this;
            }
            else
            {
                q1 = -q1;
                q2 = -q2;
                q3 = -q3;
                q4 = -q4;
                return this;
            }
        }

        /// <summary>
        /// 正規化クォータニオンを得る.
        /// </summary>
        /// <param name="q"></param>
        /// <param name="q4Positive">q4成分を + にする.</param>
        /// <returns></returns>
        public static Quaternion Normalize(Quaternion q, bool q4Positive = true)
        {
            double n = Math.Sqrt(q.q1 * q.q1 + q.q2 * q.q2 + q.q3 * q.q3 + q.q4 * q.q4);
            if (q4Positive)
            {
                return new Quaternion(q.q1 / n, q.q2 / n, q.q3 / n, q.q4 / n).Q4Positive();
            }
            else
            {
                return new Quaternion(q.q1 / n, q.q2 / n, q.q3 / n, q.q4 / n);
            }
        }

        /// <summary>
        /// 自身を正規化する.
        /// </summary>
        /// <param name="q4Positive">q4成分を + にする.</param>
        /// <returns></returns>
        public Quaternion Normalize(bool q4Positive = true)
        {
            double n = Math.Sqrt(q1 * q1 + q2 * q2 + q3 * q3 + q4 * q4);
            q1 /= n;
            q2 /= n;
            q3 /= n;
            q4 /= n;
            if (q4Positive)
            {
                return Q4Positive();
            }
            else
            {
                return this;
            }
        }

        /// <summary>
        /// DCM化（座標系回転DCM）
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Dcm ToDcm(Quaternion q)
        {
            double q12 = q.q1 * q.q1;
            double q22 = q.q2 * q.q2;
            double q32 = q.q3 * q.q3;
            double q42 = q.q4 * q.q4;
            double q1q2 = q.q1 * q.q2;
            double q2q3 = q.q2 * q.q3;
            double q1q3 = q.q1 * q.q3;
            double q1q4 = q.q1 * q.q4;
            double q2q4 = q.q2 * q.q4;
            double q3q4 = q.q3 * q.q4;

            double[,] a = new double[3, 3];
            a[0, 0] = q12 - q22 - q32 + q42;
            a[0, 1] = 2 * (q1q2 + q3q4);
            a[0, 2] = 2 * (q1q3 - q2q4);
            a[1, 0] = 2 * (q1q2 - q3q4);
            a[1, 1] = -q12 + q22 - q32 + q42;
            a[1, 2] = 2 * (q2q3 + q1q4);
            a[2, 0] = 2 * (q1q3 + q2q4);
            a[2, 1] = 2 * (q2q3 - q1q4);
            a[2, 2] = -q12 - q22 + q32 + q42;

            return new Dcm(a);
        }

        /// <inheritdoc cref="ToDcm"/>
        public Dcm ToDcm()
        {
            return ToDcm(this);
        }

        /// <summary>
        /// クォータニオンの時間微分
        /// </summary>
        /// <param name="q">回転クォータニオン</param>
        /// <param name="w">角速度ベクトル (radians</param>
        /// <returns></returns>
        public static Quaternion Qdot(Quaternion q, Vector3 w)
        {
            double q1 = w.Z * q.q2 - w.Y * q.q3 + w.X * q.q4;
            double q2 = -w.Z * q.q1 + w.X * q.q3 + w.Y * q.q4;
            double q3 = w.Y * q.q1 - w.X * q.q2 + w.Z * q.q4;
            double q4 = -w.X * q.q1 - w.Y * q.q2 - w.Z * q.q3;
            return new Quaternion(q1 * 0.5, q2 * 0.5, q3 * 0.5, q4 * 0.5, normalize: false);
        }

        /// <inheritdoc cref="Qdot"/>
        public Quaternion Qdot(Vector3 w)
        {
            return Qdot(this, w);
        }

        /// <summary>
        /// クォータニオンによるベクトルの回転
        /// </summary>
        /// <param name="q">回転クォータニオン</param>
        /// <param name="v">ベクトル</param>
        /// <param name="CoordOperation">座標系回転 (false : ベクトルの回転)</param>
        /// <returns></returns>
        public static Vector3 RotVector(Quaternion q, Vector3 v, bool CoordOperation = true)
        {
            Dcm dcm;
            if (!CoordOperation)
            {
                dcm = q.Conj().ToDcm();
            }
            else
            {
                dcm = q.ToDcm();
            }
            return dcm * v;
        }

        /// <inheritdoc cref="RotVector"/>
        public Vector3 RotVector(Vector3 v, bool CoordOperatoin = true)
        {
            return RotVector(this, v, CoordOperatoin);
        }

        /// <summary>
        /// Gets vector part
        /// </summary>
        /// <param name="q"></param>
        /// <returns>[q1 q2 q3]</returns>
        public static Vector3 GetVectorPart(Quaternion q)
        {
            return new Vector3(q.q1, q.q2, q.q3);
        }

        /// <inheritdoc cref="GetVectorPart"/>
        public Vector3 GetVectorPart()
        {
            return GetVectorPart(this);
        }


        /// <summary>
        /// Gets angle
        /// </summary>
        /// <param name="q"></param>
        /// <returns>radians</returns>
        public static double GetAngle(Quaternion q)
        {
            if ((q.q4 < -0.1) || (q.q4 > 0.1))
            {
                return 2 * Math.Asin(Math.Sqrt(q.q1 * q.q1 + q.q2 * q.q2 + q.q3 * q.q3));
            }
            else if (q.q4 < 0)
            {
                return 2 * Math.Acos(-q.q4);
            }
            return 2 * Math.Acos(q.q4);
        }


        /// <inheritdoc cref="GetAngle"/>
        public double GetAngle()
        {
            return GetAngle(this);
        }


    }
}
