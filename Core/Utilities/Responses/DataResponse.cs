namespace Core.Utilities.Responses
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public DataResponse(T data, bool success, string message, int resultCode) : base(success, message, resultCode)
        {
            Data = data;
        }

        public DataResponse(T data, bool success, int resultCode) : base(success, resultCode)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
