using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Parent;

namespace Business.Concrete
{
    public class ParentManager : IParentService
    {
        IParentDal _parentDal;
        private IMapper _mapper;

        public ParentManager(IParentDal parentDal, IMapper mapper)
        {
            _parentDal = parentDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IResponse> Add(ParentAddDto parentAddDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(parentAddDto.Password, out passwordHash, out passwordSalt);

            var parent = _mapper.Map<Parent>(parentAddDto);
            parent.PasswordSalt = passwordSalt;
            parent.PasswordHash = passwordHash;

            await _parentDal.Add(parent);
            return new SuccessResponse(Messages.AddParent, 200);

        }

        public async Task<IResponse> Delete(int id)
        {
            await _parentDal.Delete(id);
            return new SuccessResponse("Ok", 200);
        }

        public async Task<IDataResponse<IEnumerable<ParentDetailDto>>> GetAll()
        {
            var parent = await _parentDal.Include(null, x=> x.Students);
            var parentDto = _mapper.Map<IEnumerable<ParentDetailDto>>(parent);
            return new SuccessDataResponse<IEnumerable<ParentDetailDto>>(parentDto, Messages.GetAllParent, 200);
        }

        public async Task<IDataResponse<ParentDetailDto>> GetById(int parentId)
        {
            var parent = await _parentDal.Include(x => x.Id == parentId, x=> x.Students);

            if(parent.Count() > 0)
            {
                var parentDto = _mapper.Map<IEnumerable<ParentDetailDto>>(parent).FirstOrDefault();
                return new SuccessDataResponse<ParentDetailDto>(parentDto, Messages.GetParent, 200);
            }
            return new ErrorDataResponse<ParentDetailDto>(Messages.GetParentError, 404);
        }

        public async Task<IResponse> Update(UpdateParentDto updateParentDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updateParentDto.Password, out passwordHash, out passwordSalt);

            var parent = _mapper.Map<Parent>(updateParentDto);
            parent.PasswordSalt = passwordSalt;
            parent.PasswordHash = passwordHash;

            await _parentDal.Update(parent);

            return new SuccessResponse("Ok", 200);

        }


    }
}
