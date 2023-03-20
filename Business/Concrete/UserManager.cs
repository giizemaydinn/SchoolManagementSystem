using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResponse<List<OperationClaim>>> GetClaims(User user)
        {
            var claims = await _userDal.GetClaims(user);
            return new SuccessDataResponse<List<OperationClaim>>(claims, Messages.GetAllStudent, 200);

        }

        public async Task<IResponse> AddUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            UserOperationClaimDal userOperationClaimDal = new UserOperationClaimDal();
            await userOperationClaimDal.Add(userOperationClaim);

            return new SuccessResponse(Messages.AddUserOperationClaim, 200);
        }

        public async Task<IResponse> Add(User user)
        {
            await _userDal.Add(user);
            
            return new SuccessResponse(Messages.AddUser, 200);
        }

        public async Task<IDataResponse<User>> GetByMail(string email)
        {
            var user = await _userDal.Get(u => u.Email == email);

            if (user != null)
            {
                return new SuccessDataResponse<User>(user, Messages.GetByMail, 200);

            }
            return new ErrorDataResponse<User>(Messages.GetByMailError, 404);

        }
    }
}
