using Core.Entities.Concrete;
using Core.Utilities.Responses;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResponse<List<OperationClaim>>> GetClaims(User user);
        Task<IResponse> Add(User user);
        Task<IResponse> AddUserOperationClaim(UserOperationClaim userOperationClaim);
        Task<IDataResponse<User>> GetByMail(string email);
    }
}
