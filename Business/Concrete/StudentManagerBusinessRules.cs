using Business.Constants;
using Core.Utilities.Responses;
using System.Security.Cryptography.X509Certificates;

namespace Business.Concrete
{
    public partial class StudentManager
    {
        private async Task<IResponse> CheckIfExamGradeExists(int id)
        {
            var result = await _studentDal.Include(x => x.Id == id, x => x.ExamGrades);

            if (result.Count() > 0 ? result.FirstOrDefault().ExamGrades.Any() : false)
            {
                return new ErrorResponse(Messages.DataOfUserExistsError, 500);
            }
            return new SuccessResponse(200);
        }

        private async Task<IResponse> CheckIfEmailAddressExists(string email)
        {
            var result = await _studentDal.Include(x => x.Email == email);

            if (result.Count() > 0)
            {
                return new ErrorResponse(Messages.EmailExistsError, 500);
            }
            return new SuccessResponse(200);
        }

        private async Task<IResponse> CheckIfParentExists(int parentId)
        {
            var result = await _parentService.GetById(parentId);

            if (!result.Success)
            {
                return new ErrorResponse(Messages.ParentExistsError, 500);
            }
            return new SuccessResponse(200);
        }
    }
}
