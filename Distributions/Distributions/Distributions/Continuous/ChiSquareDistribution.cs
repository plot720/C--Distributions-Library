using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class ChiSquareDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha value for the distribution
        /// </summary>
        public double Alpha { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Sets up the parameters for the distribution
        /// </summary>
        /// <param name="alpha"></param>
        public ChiSquareDistribution(double alpha)
        {
            Alpha = alpha;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the parameters are valid
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha)
        {
            double m = 0.0;
            double s = 1.0;

            double sum = 0.0;

            for(int i = 0; i < Alpha; i++)
            {
                sum += Square(NormalDistribution.Sample(Random, m, s));
            }

            return sum;
        }

        #endregion Methods
    }
}
