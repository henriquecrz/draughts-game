using System.Collections.Generic;

namespace DraughtsGame
{
    public static class Extension
    {
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list.Count == 0;
        }
    }
}