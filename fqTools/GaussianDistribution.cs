using System;

namespace fqTools
{
    public class GaussianDistribution
    {
        private Random random;
        private bool GetCos = true;

        /// <summary>
        /// 平均値μ
        /// </summary>
        public double mu { get; private set; } = 0;

        /// <summary>
        /// 標準偏差σ
        /// </summary>
        public double sigma { get; private set; } = 1;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mu">平均値μ</param>
        /// <param name="sigma">標準偏差σ</param>
        public GaussianDistribution(double mu = 0, double sigma = 1)
        {
            random = new Random((int)DateTime.Now.Ticks);
            this.mu = mu;
            this.sigma = sigma;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="seed">シード値</param>
        /// <param name="mu">平均値μ</param>
        /// <param name="sigma">標準偏差σ</param>
        public GaussianDistribution(int seed, double mu = 0, double sigma = 1)
        {
            random = new Random(seed);
            this.mu = mu;
            this.sigma = sigma;
        }

        /// <summary>
        /// 正規分布乱数を得る
        /// <para>ボックスミューラー法</para>
        /// </summary>
        /// <returns>正規分布乱数</returns>
        public double Next()
        {
            double rand;
            double normrand;

            while ((rand = random.NextDouble()) == 0) ;

            double rand2 = random.NextDouble();

            if (GetCos)
            {
                normrand = Math.Sqrt(-2 * Math.Log(rand)) * Math.Cos(2 * Math.PI * rand2);
                GetCos = false;
            }
            else
            {
                normrand = Math.Sqrt(-2 * Math.Log(rand)) * Math.Sin(2 * Math.PI * rand2);
                GetCos = true;
            }

            normrand = normrand * sigma + mu;
            return normrand;
        }

        /// <summary>
        /// 正規分布乱数ペア(cos, sin)を得る
        /// </summary>
        /// <returns>正規分布乱数ペア [cos sin]</returns>
        public double[] NextPair()
        {
            double[] normrand = new double[2];
            double rand;

            while ((rand = random.NextDouble()) == 0) ;

            double rand2 = random.NextDouble();

            normrand[0] = Math.Sqrt(-2.0 * Math.Log(rand)) * Math.Cos(2.0 * Math.PI * rand2);
            normrand[0] = normrand[0] * sigma + mu;

            normrand[1] = Math.Sqrt(-2.0 * Math.Log(rand)) * Math.Sin(2.0 * Math.PI * rand2);
            normrand[1] = normrand[1] * sigma + mu;

            return normrand;
        }
    }
}
