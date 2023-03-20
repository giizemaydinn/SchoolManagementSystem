using Core.Utilities.Responses;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static async Task<IResponse> Run(params Task<IResponse>[] logics)
        {
            while(logics.Length > 0)
            {
                Task<IResponse> completedTask = await Task.WhenAny(logics);

                if (!completedTask.Result.Success)
                {
                    return completedTask.Result;
                }

                logics = logics.Where(t => t != completedTask).ToArray();

            }

            return null;
        }


    }
}