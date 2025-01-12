

using AutoMapper;
using backend.DTO;
using backend.Interfaces;
using backend.models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteInsuranceAsync(int insuranceId)
        {
            try
            {
                var insuranceToDelete = await _context.Insurances.FirstOrDefaultAsync(i => i.InsuranceId == insuranceId);
                if(insuranceToDelete != null){
                    _context.Insurances.Remove(insuranceToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<IReadOnlyList<Insurance>> ListInsurancesAsync(string search)
        {
           var query = _context.Insurances.AsQueryable();

            if (!string.IsNullOrEmpty(search))
             {
                 query = query.Where(i => i.InsuranceName.ToLower().Contains(search.ToLower()));
             }

             return await query.ToListAsync();
        }

        public async Task<bool> UpdateInsuranceAsync(int insuranceId, InsuranceDto insuranceDto)
        {
            var insuranceToUpdate = await _context.Insurances.FirstOrDefaultAsync(i => i.InsuranceId == insuranceId);
        
            if(insuranceToUpdate != null){
                _mapper.Map(insuranceDto,insuranceToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}