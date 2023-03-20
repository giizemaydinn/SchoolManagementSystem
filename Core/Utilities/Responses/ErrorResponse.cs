namespace Core.Utilities.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(string message, int resultCode) : base(false, message, resultCode)
        {

        }

        public ErrorResponse(int resultCode) : base(false, resultCode)
        {

        }
    }
}
