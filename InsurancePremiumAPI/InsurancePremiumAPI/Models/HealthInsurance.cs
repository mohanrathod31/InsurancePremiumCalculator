using InsurancePremiumAPI.Interfaces;

namespace InsurancePremiumAPI.Models
{
    public class HealthInsurance : IInsurance
    {
        public int Age { get; set; }
        public int PremiumTerm { get; set; }
        public string HealthRecord { get; set; }
        private readonly List<IRule> _rules;

        public HealthInsurance(int age, int premiumTerm, string healthRecord, List<IRule> rules)
        {
            Age = age;
            PremiumTerm = premiumTerm;
            HealthRecord = healthRecord;
            _rules = rules;
        }

        public decimal CalculatePremium()
        {
            decimal premium = 0;
            foreach (var rule in _rules)
            {
                premium += rule.Apply(this);
            }
            return premium;
        }
    }
}
