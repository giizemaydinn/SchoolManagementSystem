using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos.User;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;

        }

        public async Task<IDataResponse<User>> Register(UserForRegisterDto userForRegisterDto)  
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(userForRegisterDto);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _userService.Add(user);
            return new SuccessDataResponse<User>(user, "User eklendi.", 200);
        }

        public async Task<IDataResponse<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResponse<User>("Kullanıcı bulunamadı", 500);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResponse<User>("Parola hatası", 500);
            }

            return new SuccessDataResponse<User>(userToCheck.Data, "Başarılı giriş", 200);
            //return new SuccessDataResponse<User>(null, "Başarılı giriş", 200);
        }

        public async Task<IResponse> UserExists(string email)
        {
            var user = await _userService.GetByMail(email);
            if ( user.Data != null)
            {
                return new ErrorResponse("Kullanıcı mevcut", 500);
            }
            return new SuccessResponse(200);
        }

        public async Task<IDataResponse<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken =  _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResponse<AccessToken>(accessToken, "Token oluşturuldu", 200);

        }
    }
}
