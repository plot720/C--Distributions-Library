using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class TriangularDistribution : Distribution
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

        /// <summary>
        /// Represents the gamma variable for this distribution
        /// </summary>
        public double Gamma { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        public TriangularDistribution(double alpha, double beta, double gamma)
        {
            Alpha = alpha;
            Beta = beta;
            Gamma = gamma;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha < Beta && Alpha <= Gamma && Beta >= Gamma;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            return Sample(Random, Alpha, Beta, Gamma);
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <param name="Beta"></param>
        /// <param name="Gamma"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha, double Beta, double Gamma)
        {
            double helper1 = Gamma - Alpha;
            double helper2 = Beta - Alpha;
            double helper3 = Math.Sqrt(helper1 * helper2);
            double helper4 = Math.Sqrt(Beta - Gamma);

            double genNum = Random.NextDouble();

            if(genNum <= helper1 / helper2)
            {
                return Alpha + Math.Sqrt(genNum) * helper3;
            }

            return Beta - Math.Sqrt(genNum * helper2 - helper1) * helper4;
        }

        #endregion Methods
    }
}
