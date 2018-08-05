using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class PowerDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// Represents the beta variable for this distribution
        /// </summary>
        public double Beta { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public PowerDistribution(double alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0 && Beta > 0;
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
            double helper1 = 1 / Alpha;
            return Math.Pow(Random.NextDouble(), helper1) / Beta;
        }

        #endregion Methods
    }
}
