using System.Collections.Generic;

namespace JoinerLibrary
{
    public interface IJoiner<T>
    {
        IDictionary<T, IList<T>> Join(IList<T> originalData, IList<T> crushedData);
    }
}