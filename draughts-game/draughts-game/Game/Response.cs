using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Game
{
    class Response
    {
        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
