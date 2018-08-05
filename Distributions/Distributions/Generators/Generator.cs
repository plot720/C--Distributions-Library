using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Generators
{
    /// <summary>
    /// Represents a random number generator
    /// </summary>
    public abstract class Generator
    {
        public abstract double NextDouble();
        public abstract double NextDouble(double min, double max);
        public abstract bool NextBool();
        public abstract int NextInt();
        public abstract int NextInt(int min, int max);
    }
}
