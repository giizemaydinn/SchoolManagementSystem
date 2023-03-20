namespace Core.Utilities.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string message, int resultCode) : base(true, message, resultCode)
        {

        }

        public SuccessResponse(int resultCode) : base(true, resultCode)
        {

        }
    }
}
