

using System.ComponentModel.DataAnnotations;

namespace backend.models
{
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public required string InsuranceName { get; set; }
        public required string InsuranceDescription { get; set; }
        
    }
}