namespace Core.Utilities.Responses
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
        int ResultCode { get; }
    }
}
