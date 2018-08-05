﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Distributions.Continuous
{
    public class LogisticDistribution : Distribution
    {
        #region Variables

        /// <summary>
        /// Represents the mu variable for the distribution
        /// </summary>
        public double Mu { get; set; }

        /// <summary>
        /// Represents the sigma variable for this distribution
        /// </summary>
        public double Sigma { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="mu"></param>
        /// <param name="sigma"></param>
        public LogisticDistribution(double mu, double sigma)
        {
            Mu = mu;
            Sigma = sigma;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if the variables are valid for this distribution
        /// </summary>
        /// <returns></returns>
        public override bool AreParametersValid()
        {
            return (!double.IsNaN(Mu)) && Sigma > 0;
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
        /// <param name="Mu"></param>
        /// <param name="Sigma"></param>
        /// <returns></returns>
        public static double Sample(Generators.Generator Random, double Mu, double Sigma)
        {
            double u;
            do
            {
                u = Random.NextDouble();
            }
            while (IsNearZero(u * (1 - u)));

            return Mu + Sigma * Math.Log(u / (1 - u));
        }

        #endregion Methods
    }
}
