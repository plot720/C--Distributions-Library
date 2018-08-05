using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class StudentsTDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represent the nu variable for this distribution
        /// </summary>
        public double Nu { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variable
        /// </summary>
        /// <param name="nu"></param>
        public StudentsTDistribution(double nu)
        {
            Nu = nu;
        }

        #endregion Constructor

        #region Methods


        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Nu > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Nu);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Nu"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Nu)
        {
            const double mu = 0;
            const double sigma = 0;

            double n = NormalDistribution.Sample(Random, mu, sigma);
            double c = ChiSquareDistribution.Sample(Random, Nu);

            return n / Math.Sqrt(c / Nu);
        }

        #endregion Methods
    }
}
