namespace draughts_game.Draughts
{
    class Response
    {
        public Response(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; }

        public string Message { get; }
    }
}
