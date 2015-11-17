using System;
using System.Collections.Generic;

namespace DataAnalysisLibrary
{
    public interface IDataCollector<T>
    {
        IList<T> Collect();
    }
}
