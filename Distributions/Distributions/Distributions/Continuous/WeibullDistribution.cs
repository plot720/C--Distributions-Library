using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class WeibullDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// Represents the lambda variable for this distribution
        /// </summary>
        public double Lambda { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="lambda"></param>
        public WeibullDistribution(double alpha, double lambda)
        {
            Alpha = alpha;
            Lambda = lambda;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0 && Lambda > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Lambda);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Lambda"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Lambda)
        {
            double helper1 = 1 / Alpha;
            return Lambda * Math.Pow(-Math.Log(1.0 - Random.NextDouble()), helper1);
        }

        #endregion Methods
    }
}
