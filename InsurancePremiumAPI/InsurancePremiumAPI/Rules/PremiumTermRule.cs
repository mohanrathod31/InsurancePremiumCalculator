using InsurancePremiumAPI.Interfaces;
using InsurancePremiumAPI.Models;

namespace InsurancePremiumAPI.Rules
{
    public class PremiumTermRule : IRule
    {
        public decimal Apply(IInsurance insurance)
        {
            return insurance switch
            {
                TermInsurance termInsurance => termInsurance.PremiumTerm * 10m,
                HealthInsurance healthInsurance => healthInsurance.PremiumTerm * 12m,
                _ => 0
            };
        }
    }

}
