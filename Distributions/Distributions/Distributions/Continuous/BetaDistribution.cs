using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class BetaDistribution : Distribution
    {
        #region Variables

        /// <summary>
        ///  Used as the default beta value for obtaining samples
        /// </summary>
        public double DefaultBeta { get; set; }

        /// <summary>
        /// Represents the distributions alpha value
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// represents the distributions beta value
        /// </summary>
        public double Beta { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Sets the alpha, beta, and default beta values for the distribution
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="defaultBeta"></param>
        public BetaDistribution(double alpha, double beta, double defaultBeta = 1)
        {
            Alpha = alpha;
            Beta = beta;
            
            DefaultBeta = defaultBeta;

        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Beta, DefaultBeta);
        }

        /// <summary>
        /// Checks if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0.0 && Beta > 0.0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Beta"></param>
        /// <param name="DefaultBeta"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Beta, double DefaultBeta = 1)
        {

            double x = GammaDistribution.Sample(Random, Alpha, DefaultBeta);
            double t;
            do
            {
                t = (x + GammaDistribution.Sample(Random, Beta, DefaultBeta));
            }
            while (IsNearZero(t));

            return x / t;
        }

        #endregion Methods
    }
}
