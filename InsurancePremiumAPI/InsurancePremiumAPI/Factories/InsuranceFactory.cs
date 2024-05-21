using InsurancePremiumAPI.Interfaces;
using InsurancePremiumAPI.Models;
using InsurancePremiumAPI.Rules;

namespace InsurancePremiumAPI.Factories
{
    public static class InsuranceFactory
    {
        public static IInsurance CreateInsurance(string type, int age, int premiumTerm, string healthRecord = null, List<IRule> rules = null)
        {
            return type switch
            {
                "Term" => new TermInsurance(age, premiumTerm, rules ?? GetDefaultTermInsuranceRules()),
                "Health" => new HealthInsurance(age, premiumTerm, healthRecord, rules ?? GetDefaultHealthInsuranceRules()),
                _ => throw new ArgumentException("Invalid insurance type")
            };
        }

        private static List<IRule> GetDefaultTermInsuranceRules()
        {
            return new List<IRule> { new AgeRule(), new PremiumTermRule() };
        }

        private static List<IRule> GetDefaultHealthInsuranceRules()
        {
            return new List<IRule> { new AgeRule(), new PremiumTermRule(), new HealthRecordRule() };
        }
    }
}
