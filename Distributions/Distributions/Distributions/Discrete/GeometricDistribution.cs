﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Discrete
{
    public class GeometricDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the alpha variable for this distribution
        /// </summary>
        public double Alpha { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variable
        /// </summary>
        /// <param name="alpha"></param>
        public GeometricDistribution(double alpha)
        {
            Alpha = alpha;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return Alpha > 0 && Alpha <= 1;
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <returns></returns>
        public override double Sample()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a sample from the distribution
        /// </summary>
        /// <param name="Random"></param>
        /// <param name="Alpha"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Alpha)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}
