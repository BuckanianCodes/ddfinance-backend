

using AutoMapper;
using backend.DTO;
using backend.Interfaces;
using backend.models;

namespace backend.Data
{
    public class InsuranceRepository : InsuranceInterface
    {
        private readonly DDFinanceContext _context;
        private readonly IMapper _mapper;
        public InsuranceRepository(DDFinanceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddInsuranceAsync(InsuranceDto insurance)
        {
            try
            {
                 var insuranceToAdd = _mapper.Map<Insurance>(insurance);
            await _context.Insurances.AddAsync(insuranceToAdd);
            await _context.SaveChangesAsync();
            return true;
            }
            catch (System.Exception)
            {
                return false;
            }
           
        }
    }
}