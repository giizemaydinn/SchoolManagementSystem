namespace Core.Utilities.Responses
{
    public class Response : IResponse
    {

        public Response(bool success, string message, int resultCode) : this(success, resultCode)
        {
            Message = message;
        }

        public Response(bool success, int resultCode)
        {
            Success = success;
            ResultCode = resultCode;
        }

        public bool Success { get; }

        public string Message { get; }

        public int ResultCode { get; set; }
    }
}
