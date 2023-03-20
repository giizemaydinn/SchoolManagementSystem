using Business.Constants;
using Core.Utilities.Responses;
using System.Security.Cryptography.X509Certificates;

namespace Business.Concrete
{
    public partial class LessonManager
    {
        private async Task<IResponse> CheckIfLessonNameExists(string lessonName)
        {
            var result = await _lessonDal.Get(x => x.Name == lessonName);

            if (result != null)
            {
                return new ErrorResponse(Messages.LessonNameExistsError, 500);
            }
            return new SuccessResponse(200);
        }

    }
}
