using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysisLibrary
{
    internal class StringPreparer : IStringPreparer
    {
        private readonly Random _random = new Random();

        public void Increase(IList<string> strings, int expectedSize)
        {
            while (strings.Count < expectedSize)
            {
                var index = _random.Next(strings.Count - 1);
                strings.Add(strings[index]);
            }
        }

        public void Mix(IList<string> strings, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                var index1 = _random.Next(strings.Count - 1);
                var index2 = _random.Next(strings.Count - 1);
                var tmp = strings[index1];
                strings[index1] = strings[index2];
                strings[index2] = tmp;
            }
        }

        public IList<string> GetCopy(IList<string> strs)
        {
            return strs.ToList();
        }
    }
}