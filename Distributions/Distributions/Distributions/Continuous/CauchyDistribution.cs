using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class CauchyDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// Represents the gamma variable for this distribution
        /// </summary>
        public double Gamma { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the parameters
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="gamma"></param>
        public CauchyDistribution(double alpha, double gamma)
        {
            Alpha = alpha;
            Gamma = gamma;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Returns if the parameters are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return (!double.IsNaN(Alpha)) && Gamma > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Gamma);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Gamma"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Gamma)
        {
            return Alpha + Gamma * Math.Tan(Math.PI * (Random.NextDouble() - .5));
        }

        #endregion Methods
    }
}
