using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Discrete
{
    public class PoissonDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the lambda variable for this distribution
        /// </summary>
        public double Lambda { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variable
        /// </summary>
        /// <param name="lambda"></param>
        public PoissonDistribution(double lambda)
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
            const int step = 500;
            double k = 0;
            double p = 1;

            double r;

            do
            {
                k++;
                while(IsNearZero(r = Random.NextDouble()))
                {

                }
                p = p * r;
                if(p < Math.E && Lambda > 0)
                {
                    p = p * Math.Exp(Lambda > step ? step : Lambda);
                    Lambda -= step;
                }
            }
            while (p > 1);

            return k - 1;
        }

        #endregion Methods
    }
}
