using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class RayleighDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the sigma variable for this distribution
        /// </summary>
        public double Sigma { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="sigma"></param>
        public RayleighDistribution(double sigma)
        {
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
            return Sigma > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Sigma);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Sigma"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Sigma)
        {
            const double mu = 0;
            double n1 = Square(NormalDistribution.Sample(Random, mu, Sigma));
            double n2 = Square(NormalDistribution.Sample(Random, mu, Sigma));

            return Math.Sqrt(n1 + n2);
        }

        #endregion Methods
    }
}
