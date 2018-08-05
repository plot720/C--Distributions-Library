using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class ContinuousUniformDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha value for the distribution
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// represents the beta value for the distribution
        /// </summary>
        public double Beta { get; set; }

        #endregion Variables

        #region Constructors

        /// <summary>
        /// Sets the parameters for the distribution
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public ContinuousUniformDistribution(double alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha <= Beta;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Beta);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Beta"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Beta)
        {
            return Random.NextDouble(Alpha, Beta);
        }

        #endregion Methods
    }
}
