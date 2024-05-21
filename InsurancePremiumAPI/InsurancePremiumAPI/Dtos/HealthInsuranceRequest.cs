namespace InsurancePremiumAPI.Dtos
{
    public class HealthInsuranceRequest
    {
        public int Age { get; set; }
        public int PremiumTerm { get; set; }
        public string? HealthRecord { get; set; } = "";
    }
}
