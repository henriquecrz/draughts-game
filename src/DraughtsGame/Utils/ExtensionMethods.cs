using System.Collections.Generic;

namespace DraughtsGame.Utils
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty<T>(this IList<T> list) => list.Count == 0;
    }
}
