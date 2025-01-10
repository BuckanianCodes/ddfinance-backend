using backend.DTO;

namespace backend.Interfaces
{
    public interface InsuranceInterface
    {
        Task<bool> AddInsuranceAsync(InsuranceDto insurance);
    }
}