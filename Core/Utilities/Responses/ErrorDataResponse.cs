namespace Core.Utilities.Responses
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {
        public ErrorDataResponse(T data, string message, int resultCode) : base(data, false, message, resultCode)
        {

        }

        public ErrorDataResponse(T data, int resultCode) : base(data, false, resultCode)
        {

        }

        public ErrorDataResponse(string message, int resultCode) : base(default, false, message, resultCode)
        {

        }

        public ErrorDataResponse(int resultCode) : base(default, false, resultCode)
        {

        }
    }
}
