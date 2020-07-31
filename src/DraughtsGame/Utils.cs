using System;

namespace DraughtsGame
{
    public static class Utils
    {
        public static bool ContainsParam(string[] command)
        {
            return command.Length > 1;
        }
    }
}