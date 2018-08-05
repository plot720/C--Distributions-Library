using Distributions.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class NormalDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the mu variable for this distribution
        /// </summary>
        public double Mu { get; set; }

        /// <summary>
        /// Represents the sigma variable for this distribution
        /// </summary>
        public double Sigma { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables for this distribution
        /// </summary>
        /// <param name="mu"></param>
        /// <param name="sigma"></param>
        public NormalDistribution(double mu, double sigma)
        {
            Mu = mu;
            Sigma = sigma;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return (!double.IsNaN(Mu)) && (Sigma > 0.0);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Mu, Sigma);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Mu"></param>
        /// <param name="Sigma"></param>
        /// <returns></returns>
        public static double Sample(Generator Random, double Mu, double Sigma)
        {

            double w, y, v1, v2;

            do
            {
                v1 = 2.0 * Random.NextDouble() - 1.0;
                v2 = 2.0 * Random.NextDouble() - 1.0;
                w = v1 * v1 + v2 * v2;
            }
            while (w >= 1 || IsNearZero(w));

            y = Math.Sqrt(-2 * Math.Log(w) / w) * Sigma;
            return Random.NextBool() ? v1 * y + Mu : v2 * y + Mu;
        }

        #endregion Methods
    }
}
