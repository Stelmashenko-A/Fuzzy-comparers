using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnalysisLibrary;
using JoinerLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringJoiner stringJoiner=new HammingStringJoiner(new HammingEstimater(), 0.9998);
            IAnalyzer analyzer = new TextAnalyzer(stringJoiner,"G://test.txt");
            var r = analyzer.Analyze();
        }
    }
}
