using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class ExponentialDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the lambda variable for this distribution
        /// </summary>
        public double Lambda { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="lambda"></param>
        public ExponentialDistribution(double lambda)
        {
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
            return Lambda > 0;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Lambda);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Lambda"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Lambda)
        {

            double u;
            do
            {
                u = Random.NextDouble();
            }
            while (IsNearZero(u));

            return -Math.Log(u) / Lambda;
        }

        #endregion Methods
    }
}
