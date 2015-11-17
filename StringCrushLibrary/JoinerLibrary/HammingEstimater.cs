using System;

namespace JoinerLibrary
{
    internal class HammingEstimater : IEstimater
    {
        public double Estimate(double metricValue, int length1, int length2)
        {
            var result = metricValue/Math.Max(length1, length2);
            return 1 - result;
        }
    }
}