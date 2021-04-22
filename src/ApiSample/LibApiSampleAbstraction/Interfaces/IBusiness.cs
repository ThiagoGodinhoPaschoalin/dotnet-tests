using System;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Interfaces
{
    public interface IBusiness<TCreateNewRequest, TUpdateRequest, TDeleteRequest, TGetRequest, TGetResponse>
    {
        Task<Guid> CreateNewAsync(TCreateNewRequest request);
        Task<Guid> UpdateAsync(TUpdateRequest request);
        Task<Guid> DeleteAsync(TDeleteRequest request);
        Task<TGetResponse> GetAsync(TGetRequest request);
    }
}