using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.JWT;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResponse<User>> Register(UserForRegisterDto userForRegisterDto);
        Task<IDataResponse<User>> Login(UserForLoginDto userForLoginDto);
        Task<IResponse> UserExists(string email);
        Task<IDataResponse<AccessToken>> CreateAccessToken(User user);
    }
}
