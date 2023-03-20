namespace Core.Utilities.Responses
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        public SuccessDataResponse(T data, string message, int resultCode) : base(data, true, message, resultCode)
        {

        }

        public SuccessDataResponse(T data, int resultCode) : base(data, true, resultCode)
        {

        }

        public SuccessDataResponse(string message, int resultCode) : base(default, true, message, resultCode)
        {

        }

        public SuccessDataResponse(int resultCode) : base(default, true, resultCode)
        {

        }
    }
}
