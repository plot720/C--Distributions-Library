using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class ErlangDistribution : Distribution
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
        public ErlangDistribution(double alpha, double lambda)
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
            return Alpha > 0 && Lambda > 0.0;
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
            if(double.IsPositiveInfinity(Lambda))
            {
                return Alpha;
            }

            const double Mu = 0;
            const double Sigma = 1;

            double a = Alpha;
            double alphaFix = 1;

            if(Alpha < 1.0)
            {
                a = Alpha + 1;
                alphaFix = Math.Pow(Random.NextDouble(), 1.0 / Alpha);
            }

            double d = a - (1.0 / 3.0);
            double c = 1.0 / Math.Sqrt(9 * d);

            double x, v, u;
            while(true)
            {
                x = NormalDistribution.Sample(Random, Mu, Sigma);
                v = 1 + (c * x);
                while (v <= 0)
                {
                    x = NormalDistribution.Sample(Random, Mu, Sigma);
                    v = 1 + (c * x);
                }

                v = v * v * v;

                u = Random.NextDouble();

                x = x * x;
                if(u < 1.0 - (.0331 * x * x))
                {
                    return alphaFix * d * v / Lambda;
                }

                if(Math.Log(u) < (.5 * x) + (d * (1.0 - v + Math.Log(v))))
                {
                    return alphaFix * d * v / Lambda;
                }
            }
        }

        #endregion Methods
    }
}
