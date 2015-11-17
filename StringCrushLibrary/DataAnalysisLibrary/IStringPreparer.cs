using System.Collections.Generic;

namespace DataAnalysisLibrary
{
    public interface IStringPreparer
    {
        void Increase(IList<string> strings, int expectedSize);
        void Mix(IList<string> strings, int iterations);
        IList<string> GetCopy(IList<string> strs);
    }
}
