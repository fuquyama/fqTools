using System;

namespace fqTools
{
    /// <summary>
    /// 方向余弦行列クラス
    /// <para>Direction-Cosine-Matrix</para>
    /// </summary>
    public class Dcm : Matrix3x3
    {
        public enum Euler
        {
            R121, R123, R131, R132, R212, R213, R231, R232, R312, R313, R321, R323
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// <para>単位行列を作成</para>
        /// </summary>
        public Dcm() : base()
        {
            m11 = 1;
            m22 = 1;
            m33 = 1;
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="m"></param>
        public Dcm(Matrix3x3 m) : base(m)
        {
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="m"></param>
        public Dcm(double[,] m) : base(m)
        {
        }


        public override string ToString()
        {
            return "DCM";
        }

        public static Dcm operator *(Dcm a, Dcm b)
        {
            return new Dcm((Matrix3x3)a * (Matrix3x3)b);
        }


        /// <summary>
        /// X軸回転 DCM の生成.
        /// <para>|   1    0    0  |</para>
        /// <para>|   0   cos  sin |</para>
        /// <para>|   0  -sin  cos |</para>
        /// </summary>
        /// <param name="angle">radians</param>
        /// <param name="CoordRot">座標系回転 (false : ベクトルの回転)</param>
        /// <returns></returns>
        public static Dcm RotationX(double angle, bool CoordRot = true)
        {
            Dcm dcm = new Dcm();
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);
            dcm.m22 = c;
            dcm.m23 = s;
            dcm.m32 = -s;
            dcm.m33 = c;
            return CoordRot ? dcm : dcm.Transpose();
        }

        /// <summary>
        /// Y軸回転 DCM の生成.
        /// <para>|  cos   0  -sin |</para>
        /// <para>|   0    1    0  |</para>
        /// <para>|  sin   0   cos |</para>
        /// </summary>
        /// <param name="angle">radians</param>
        /// <param name="CoordRot">座標系回転 (false : ベクトルの回転)</param>
        /// <returns></returns>
        public static Dcm RotationY(double angle, bool CoordRot = true)
        {
            Dcm dcm = new Dcm();
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);
            dcm.m11 = c;
            dcm.m13 = -s;
            dcm.m31 = s;
            dcm.m33 = c;
            return CoordRot ? dcm : dcm.Transpose();
        }

        /// <summary>
        /// Z軸回転 DCM の生成.
        /// <para>|  cos  sin  0  |</para>
        /// <para>| -sin  cos  0  |</para>
        /// <para>|   0    0   1  |</para>
        /// </summary>
        /// <param name="angle">radians</param>
        /// <param name="CoordRot">座標系回転 (false : ベクトルの回転)</param>
        /// <returns></returns>
        public static Dcm RotationZ(double angle, bool CoordRot = true)
        {
            Dcm dcm = new Dcm();
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);
            dcm.m11 = c;
            dcm.m12 = s;
            dcm.m21 = -s;
            dcm.m22 = c;
            return CoordRot ? dcm : dcm.Transpose();
        }

        /// <summary>
        /// 転置行列
        /// </summary>
        /// <param name="dcm"></param>
        /// <returns></returns>
        public static Dcm Transpose(Dcm dcm)
        {
            return new Dcm(Matrix3x3.Transpose(dcm));
        }

        /// <inheritdoc cref="Transpose"/>
        public new Dcm Transpose()
        {
            return Transpose(this);
        }

        /// <summary>
        /// X軸まわりの回転
        /// </summary>
        /// <param name="angle">radians</param>
        public void RotateX(double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            double a21, a22, a23, a31, a32, a33;

            a21 = c * m21 + s * m31;
            a22 = c * m22 + s * m32;
            a23 = c * m23 + s * m33;
            a31 = -s * m21 + c * m31;
            a32 = -s * m22 + c * m32;
            a33 = -s * m23 + c * m33;

            m21 = a21;
            m22 = a22;
            m23 = a23;
            m31 = a31;
            m32 = a32;
            m33 = a33;
        }

        /// <summary>
        /// Y軸まわりの回転
        /// </summary>
        /// <param name="angle">radians</param>
        public void RotateY(double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            double a11, a12, a13, a31, a32, a33;

            a11 = c * m11 - s * m31;
            a12 = c * m12 - s * m32;
            a13 = c * m13 - s * m33;
            a31 = s * m11 + c * m31;
            a32 = s * m12 + c * m32;
            a33 = s * m13 + c * m33;

            m11 = a11;
            m12 = a12;
            m13 = a13;
            m31 = a31;
            m32 = a32;
            m33 = a33;
        }

        /// <summary>
        /// Z軸まわりの回転
        /// </summary>
        /// <param name="angle">radians</param>
        public void RotateZ(double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            double a11, a12, a13, a21, a22, a23;

            a11 = c * m11 + s * m21;
            a12 = c * m12 + s * m22;
            a13 = c * m13 + s * m23;
            a21 = -s * m11 + c * m21;
            a22 = -s * m12 + c * m22;
            a23 = -s * m13 + c * m23;

            m11 = a11;
            m12 = a12;
            m13 = a13;
            m21 = a21;
            m22 = a22;
            m23 = a23;
        }

        /// <summary>
        /// DCMからクォータニオンを生成
        /// </summary>
        /// <param name="dcm"></param>
        /// <returns></returns>
        public static Quaternion ToQuaternion(Dcm dcm)
        {
            double[] qq = new double[4];
            qq[0] = (1 + dcm.m11 - dcm.m22 - dcm.m33) / 4.0;
            qq[1] = (1 - dcm.m11 + dcm.m22 - dcm.m33) / 4.0;
            qq[2] = (1 - dcm.m11 - dcm.m22 + dcm.m33) / 4.0;
            qq[3] = (1 + dcm.m11 + dcm.m22 + dcm.m33) / 4.0;

            double max = Accord.Math.Matrix.Max(qq);
            double fr = 1 / (4 * Math.Sqrt(max));
            if (max == qq[0])
            {
                return new Quaternion(4 * qq[0] * fr, (dcm.m12 + dcm.m21) * fr, (dcm.m31 + dcm.m13) * fr, (dcm.m23 - dcm.m32) * fr).Normalize();
            }
            else if (max == qq[1])
            {
                return new Quaternion((dcm.m12 + dcm.m21) * fr, 4 * qq[1] * fr, (dcm.m23 + dcm.m32) * fr, (dcm.m31 - dcm.m13) * fr).Normalize();
            }
            else if (max == qq[2])
            {
                return new Quaternion((dcm.m31 + dcm.m13) * fr, (dcm.m23 + dcm.m32) * fr, 4 * qq[2] * fr, (dcm.m12 - dcm.m21) * fr).Normalize();
            }
            else
            {
                return new Quaternion((dcm.m23 - dcm.m32) * fr, (dcm.m31 - dcm.m13) * fr, (dcm.m12 - dcm.m21) * fr, 4 * qq[3] * fr).Normalize();
            }
        }

        /// <inheritdoc cref="ToQuaternion"/>
        public Quaternion ToQuaternion()
        {
            return ToQuaternion(this);
        }



        private static double[] Euler_ijk(Euler euler, Dcm dcm)
        {
            double[] angles = new double[3];
            int i, j, k;
            int signum;
            switch (euler)
            {
                case Euler.R123:
                    i = 0;
                    j = 1;
                    k = 2;
                    signum = -1;
                    break;
                case Euler.R231:
                    i = 1;
                    j = 2;
                    k = 0;
                    signum = -1;
                    break;
                case Euler.R312:
                    i = 2;
                    j = 0;
                    k = 1;
                    signum = -1;
                    break;
                case Euler.R132:
                    i = 0;
                    j = 2;
                    k = 1;
                    signum = 1;
                    break;
                case Euler.R213:
                    i = 1;
                    j = 0;
                    k = 2;
                    signum = 1;
                    break;
                case Euler.R321:
                    i = 2;
                    j = 1;
                    k = 0;
                    signum = 1;
                    break;
                default:
                    return angles;
            }

            //特異点評価
            if (Math.Abs(dcm[k, i]) < float.Epsilon)
            {
                return angles;
            }

            // Euler角計算
            angles[1] = Math.Asin(-signum * dcm[k, i]);
            double c2 = Math.Cos(angles[1]);
            angles[0] = Math.Atan2(signum * dcm[k, j] / c2, dcm[k, k] / c2);
            angles[2] = Math.Atan2(signum * dcm[j, i] / c2, dcm[i, i] / c2);

            return angles;
        }


        private static double[] Euler_iji(Euler euler, Dcm dcm)
        {
            double[] angles = new double[3];
            int i, j, k;
            int signum;
            switch (euler)
            {
                case Euler.R121:
                    i = 0;
                    j = 1;
                    k = 2;
                    signum = -1;
                    break;
                case Euler.R232:
                    i = 1;
                    j = 2;
                    k = 0;
                    signum = -1;
                    break;
                case Euler.R313:
                    i = 2;
                    j = 0;
                    k = 1;
                    signum = -1;
                    break;
                case Euler.R131:
                    i = 0;
                    j = 2;
                    k = 1;
                    signum = 1;
                    break;
                case Euler.R212:
                    i = 1;
                    j = 0;
                    k = 2;
                    signum = 1;
                    break;
                case Euler.R323:
                    i = 2;
                    j = 1;
                    k = 0;
                    signum = 1;
                    break;
                default:
                    return angles;
            }

            //特異点評価
            if (Math.Abs(dcm[i, i]) < float.Epsilon)
            {
                return angles;
            }

            // Euler角計算
            angles[1] = Math.Acos(dcm[i, i]);
            double s2 = Math.Sin(angles[1]);
            angles[0] = Math.Atan2(dcm[i, j] / s2, signum * dcm[i, k] / s2);
            angles[2] = Math.Atan2(dcm[j, i] / s2, -signum * dcm[k, i] / s2);

            return angles;
        }


        /// <summary>
        /// DCMからオイラー角への変換
        /// </summary>
        /// <param name="euler">Euler変換順番</param>
        /// <param name="dcm">DCM</param>
        /// <returns>指定順番でのオイラー角 (radians)
        /// <para>ex)</para>
        /// <para>R321 returns { Yaw Pitch Roll }</para>
        /// <para>R123 returns { Roll Pitch Yaw }</para>
        /// </returns>
        public static double[] ToEuler(Euler euler, Dcm dcm)
        {
            switch (euler)
            {
                case Euler.R123:
                case Euler.R231:
                case Euler.R312:
                case Euler.R132:
                case Euler.R213:
                case Euler.R321:
                    return Euler_ijk(euler, dcm);
                case Euler.R121:
                case Euler.R232:
                case Euler.R313:
                case Euler.R131:
                case Euler.R212:
                case Euler.R323:
                    return Euler_iji(euler, dcm);
                default:
                    throw new ArgumentException("Invalid Euler parameter");
            }
        }

        /// <inheritdoc cref="ToEuler"/>
        public double[] ToEuler(Euler euler)
        {
            return ToEuler(euler, this);
        }


    }
}
