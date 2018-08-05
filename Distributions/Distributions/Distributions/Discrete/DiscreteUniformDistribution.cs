using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Discrete
{
    public class DiscreteUniformDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public int Alpha { get; set; }

        /// <summary>
        /// Represents the beta variable for this distribution
        /// </summary>
        public int Beta { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public DiscreteUniformDistribution(int alpha, int beta)
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
            return Alpha <= Beta && Beta < int.MaxValue;
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
        public static int Sample(Generators.Generator Random, int Alpha, int Beta)
        {
            return Random.NextInt(Alpha, Beta + 1);
        }

        #endregion Methods
    }
}
