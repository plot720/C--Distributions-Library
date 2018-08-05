using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Generators
{
    /// <summary>
    /// A random number generator that utilizes the Random class
    /// </summary>
    internal class DefaultGenerator : Generator
    {
        #region Variables

        /// <summary>
        /// The Random class instance used to generate new values. Any one instance is used for all uses of Default Generator. This prevents duplicate values.
        /// </summary>
        private static Random generator;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the generator if it is not initialized already
        /// </summary>
        public DefaultGenerator()
        {
            if(generator == null)
            {
                generator = new Random(Guid.NewGuid().GetHashCode());
            }
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Returns a random bool
        /// </summary>
        /// <returns></returns>
        public override bool NextBool()
        {
            return NextDouble() > .5;
        }

        /// <summary>
        /// Returns a random double
        /// </summary>
        /// <returns></returns>
        public override double NextDouble()
        {
            return generator.NextDouble();
        }

        /// <summary>
        /// Returns a random double between the two values
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public override double NextDouble(double min, double max)
        {
            double dif = max - min;

            return NextDouble() * dif + min;
        }

        /// <summary>
        /// Returns a random integer
        /// </summary>
        /// <returns></returns>
        public override int NextInt()
        {
            return generator.Next();
        }

        /// <summary>
        /// Returns a random integer between the two values
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public override int NextInt(int min, int max)
        {
            return generator.Next(min, max);
        }

        #endregion Methods
    }
}
