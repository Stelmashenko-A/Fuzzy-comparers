namespace JoinerLibrary
{
    public class HammingStringJoiner : StringJoiner
    {
        public HammingStringJoiner(IEstimater estimater, double joiningBorder) : base(estimater, joiningBorder)
        {
        }

        protected override double GetMetrics(string str1, string str2)
        {
            return FuzzyString.ComparisonMetrics.HammingDistance(str1, str2);
        }
    }
}