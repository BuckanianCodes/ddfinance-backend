using backend.DTO;
using backend.models;

namespace backend.Interfaces
{
    public interface InsuranceInterface
    {
        Task<bool> AddInsuranceAsync(InsuranceDto insurance);
        Task<IReadOnlyList<Insurance>>  ListInsurancesAsync(string search);
        Task<bool> DeleteInsuranceAsync(int insuranceId);

        Task<bool> UpdateInsuranceAsync(int insuranceId,InsuranceDto insuranceDto);
    }
}