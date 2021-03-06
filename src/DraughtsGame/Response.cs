﻿namespace DraughtsGame
{
    public class Response
    {
        public Response() : this(false, string.Empty)
        {

        }

        public Response(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; }

        public string Message { get; }
    }
}
