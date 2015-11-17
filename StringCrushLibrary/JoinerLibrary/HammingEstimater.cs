using System;

namespace JoinerLibrary
{
    public class HammingEstimater : IEstimater
    {
        public double Estimate(double metricValue, int length1, int length2)
        {
            var result = metricValue/10000;
            return 1 - result;
        }
    }
}