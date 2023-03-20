namespace Core.Utilities.Responses
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
    }
}
