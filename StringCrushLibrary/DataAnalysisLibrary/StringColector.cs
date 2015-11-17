using System.Collections.Generic;
using System.IO;

namespace DataAnalysisLibrary
{
    class StringColector : IStringColector
    {
        private readonly string _path;

        public StringColector(string path)
        {
            _path = path;
        }

        public IList<string> Collect()
        {
            if (!File.Exists(_path)) return null;
            var readText = File.ReadAllLines(_path);
            return readText;
        }
    }
}