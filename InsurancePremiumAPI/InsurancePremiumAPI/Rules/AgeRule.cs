using InsurancePremiumAPI.Interfaces;
using InsurancePremiumAPI.Models;

namespace InsurancePremiumAPI.Rules
{
    public class AgeRule : IRule
    {
        public decimal Apply(IInsurance insurance)
        {
            return insurance switch
            {
                TermInsurance termInsurance => termInsurance.Age * 1.5m,
                HealthInsurance healthInsurance => healthInsurance.Age * 2.0m,
                _ => 0
            };
        }
    }
}
