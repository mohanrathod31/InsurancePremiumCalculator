using InsurancePremiumAPI.Interfaces;

namespace InsurancePremiumAPI.Models
{
    public class TermInsurance : IInsurance
    {
        public int Age { get; set; }
        public int PremiumTerm { get; set; }
        private readonly List<IRule> _rules;

        public TermInsurance(int age, int premiumTerm, List<IRule> rules)
        {
            Age = age;
            PremiumTerm = premiumTerm;
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
