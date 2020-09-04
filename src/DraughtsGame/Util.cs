using System;
using DraughtsGame.Constants;

namespace DraughtsGame
{
    public static class Util
    {
        public static void Exit()
        {
            Console.WriteLine(Message.GOODBYE);
            Environment.Exit(0);
        }
    }
}
