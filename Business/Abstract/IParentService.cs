using Core.Utilities.Responses;
using Entities.Dtos.Parent;

namespace Business.Abstract
{
    public interface IParentService
    {
        Task<IDataResponse<IEnumerable<ParentDetailDto>>> GetAll();
        Task<IDataResponse<ParentDetailDto>> GetById(int parentId);
        Task<IResponse> Add(ParentAddDto parentAddDto);
        Task<IResponse> Delete(int id);
        Task<IResponse> Update(UpdateParentDto updateParentDto);
    }
}
