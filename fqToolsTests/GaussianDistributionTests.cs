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
    public class GaussianDistributionTests
    {
        [TestMethod()]
        public void NextTest()
        {
            var gauss = new GaussianDistribution(mu: 10, sigma: 10);

            var plt = new ScottPlot.Plot(600, 400);

            int sample = 1_000_000;

            // generate samples
            double[] values = new double[sample];
            for (int i = 0; i < sample; i++)
            {
                values[i] = gauss.Next();
            }

            // create a histogram
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(values, min: -40, max: 60, binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            var bar = plt.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = 1;
            plt.AxisAuto();
            plt.Title("Histogram");
            plt.YAxis.Label($"Count (#). Total count : {sample}");
            plt.XAxis.Label($"mu : {gauss.mu} ,  sigma : {gauss.sigma}");
            plt.SaveFig("GaussianDistributionTests.png");
        }
    }
}