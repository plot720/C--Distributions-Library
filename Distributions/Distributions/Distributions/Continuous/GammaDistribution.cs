using Distributions.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class GammaDistribution : Distribution
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
        public GammaDistribution(double alpha, double beta)
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
            return (Alpha > 0.0) && (Beta > 0.0);
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
        public static double Sample(Generator Random, double Alpha, double Beta)
        {
            double oAlpha = Alpha;
            if (Alpha < 1.0)
            {
                Alpha += 1;
            }

            double a1 = Alpha - 1 / 3;
            double a2 = 1 / Math.Sqrt(9 * a1);

            double u, v, x;

            do
            {
                do
                {
                    x = NormalDistribution.Sample(Random, 0, 1);
                    v = 1.0 + a2 * x;
                }
                while (v <= 0);

                v = v * v * v;
                u = Random.NextDouble();
            }
            while (u > (1.0 - .331 * Square(Square(x))) && Math.Log(u) > (.5 * Square(x) + a1 * (1.0 - v + Math.Log(v))));

            if (AreEqual(Alpha, oAlpha))
            {
                return a1 * v / Beta;
            }

            do
            {
                u = Random.NextDouble();
            }
            while (IsNearZero(u));

            return Math.Pow(u, 1.0 / oAlpha) * a1 * v / Beta;
        }

        #endregion Methods
    }
}
