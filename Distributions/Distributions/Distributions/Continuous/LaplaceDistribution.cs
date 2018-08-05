using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class LaplaceDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// Represents the Mu variable for this distribution
        /// </summary>
        public double Mu { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="mu"></param>
        public LaplaceDistribution(double alpha, double mu)
        {
            Alpha = alpha;
            Mu = mu;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0 && (!double.IsNaN(Mu));
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Mu);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Mu"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Mu)
        {
            double rand = .5 - Random.NextDouble();
            double tmp = IsNearZero(rand) ? double.NegativeInfinity : Math.Log(2.0 * Math.Abs(rand));
            return Mu - Alpha * Math.Sign(rand) * tmp;
        }

        #endregion Methods
    }
}
