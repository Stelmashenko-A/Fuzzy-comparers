using System.Collections.Generic;
using System.Linq;

namespace JoinerLibrary
{
    public abstract class StringJoiner : IStringJoiner
    {
        private readonly IEstimater _estimater;
        private readonly double _joiningBorder;

        protected StringJoiner(IEstimater estimater, double joiningBorder)
        {
            _estimater = estimater;
            _joiningBorder = joiningBorder;
        }

        protected abstract double GetMetrics(string str1, string str2);

        public IDictionary<string, IList<string>> Join(IList<string> originalData, IList<string> crushedData)
        {
            var result = originalData.ToDictionary<string, string, IList<string>>(variable => variable,
                variable => new List<string>());

            foreach (var originalString in originalData)
            {
                foreach (var crushedString in crushedData.Where(crushedString => _estimater.Estimate(
                    GetMetrics(originalString, crushedString),
                    originalString.Length, crushedString.Length) > _joiningBorder))
                {
                    result[originalString].Add(crushedString);
                }
            }

            return result;
        }
    }
}