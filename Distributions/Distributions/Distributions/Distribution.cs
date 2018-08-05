using Distributions.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    public abstract class Distribution
    {
        #region Variables

        /// <summary>
        /// The generator used to obtain the initial random numbers
        /// </summary>
        public Generator Random = new DefaultGenerator();

        /// <summary>
        /// The tolerance allowed for numbers counting as 0
        /// </summary>
        public static double Tolerance = 1E-6;

        #endregion Variables

        #region Abstract Methods

        /// <summary>
        /// Obtains a sample number from the distribution using a random number generated via the Random variable.
        /// </summary>
        /// <returns></returns>
        public abstract double Sample();

        /// <summary>
        /// Checks if the parameters for the distribution were set correctly
        /// </summary>
        /// <returns></returns>
        public abstract bool AreParametersValid();

        #endregion Abstract Methods

        #region Static Methods

        /// <summary>
        /// Returns true if the number is between 0 and the tolerance variable
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsNearZero(double x)
        {
            return x > -Tolerance && x < Tolerance;
        }

        /// <summary>
        /// Squares the number quickly
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Square(double x)
        {
            return IsNearZero(x) ? 0.0 : x * x;
        }

        /// <summary>
        /// Checks if the two numbers are equal (within the tolerance value of eachother)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool AreEqual(double x, double y)
        {
            return IsNearZero(x - y);
        }

        #endregion Static Methods
    }
}
