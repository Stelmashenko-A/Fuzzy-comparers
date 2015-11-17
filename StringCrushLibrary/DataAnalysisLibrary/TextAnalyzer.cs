using System.Collections.Generic;
using System.Linq;
using JoinerLibrary;
using StringCrushLibrary;

namespace DataAnalysisLibrary
{
    internal class TextAnalyzer : IAnalyzer
    {
        private readonly IStringJoiner _joiner;
        private readonly string _path;

        public TextAnalyzer(IStringJoiner joiner, string path)
        {
            _joiner = joiner;
            _path = path;
        }

        public int Analyze()
        {
            IStringColector stringColector = new StringColector(_path);
            var strs = stringColector.Collect();

            IStringPreparer stringPreparer = new StringPreparer();
            var strsForAnalyzing = stringPreparer.GetCopy(strs);
            stringPreparer.Mix(strsForAnalyzing, 100);
            var expectedResult = strs.ToDictionary<string, string, IList<string>>(str => str, str => new List<string>());
            var crusher = new StringCrusher(3, 3, 3);
            var crushedStrings = new List<string>();
            foreach (var str in strsForAnalyzing)
            {
                var crushedString = crusher.CrushString(str);
                expectedResult[str].Add(crushedString);
                crushedStrings.Add(crushedString);
            }
            var result = _joiner.Join(strs, crushedStrings);
            var mistakes = 0;
            foreach (var expected in expectedResult)
            {
                mistakes += result[expected.Key].Count(actualResult => !expected.Value.Contains(actualResult));
                mistakes += expected.Value.Count(exp => !result[expected.Key].Contains(exp));
            }
            return mistakes;
        }
    }
}