using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Discrete
{
    public class CategoricalDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the category distribution weights for each category
        /// </summary>
        public double[] CDF { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the categorical distribution weights
        /// </summary>
        /// <param name="cdf"></param>
        public CategoricalDistribution(double[] cdf)
        {
            CDF = cdf;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the weights are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            double sum = 0;
            foreach(double w in CDF)
            {
                if(w < 0 || double.IsNaN(w))
                {
                    return false;
                }
                sum += w;
            }

            return !IsNearZero(sum);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, CDF);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="cdf"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double[] cdf)
        {
            double u = Random.NextDouble();
            int minIndex = 0;
            int MaxIndex = cdf.Length - 1;

            int Index;
            double c;

            while(minIndex < MaxIndex)
            {
                Index = (MaxIndex - minIndex) / 2 + minIndex;
                c = cdf[Index];

                if(AreEqual(u, c))
                {
                    minIndex = Index;
                    break;
                }

                if( u < c)
                {
                    MaxIndex = Index;
                }
                else
                {
                    minIndex = Index + 1;
                }
            }

            return minIndex;
        }

        #endregion Methods
    }
}
