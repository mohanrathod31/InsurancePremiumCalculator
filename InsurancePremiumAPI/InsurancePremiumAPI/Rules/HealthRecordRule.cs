using InsurancePremiumAPI.Interfaces;
using InsurancePremiumAPI.Models;

namespace InsurancePremiumAPI.Rules
{
    public class HealthRecordRule : IRule
    {
        public decimal Apply(IInsurance insurance)
        {
            if (insurance is HealthInsurance healthInsurance)
            {
                return healthInsurance.HealthRecord.Contains("Good") ? 50 : 100;
            }
            return 0;
        }
    }

}
