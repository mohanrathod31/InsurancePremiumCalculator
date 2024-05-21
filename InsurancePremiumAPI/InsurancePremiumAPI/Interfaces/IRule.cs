namespace InsurancePremiumAPI.Interfaces
{
    public interface IRule
    {
        decimal Apply(IInsurance insurance);
    }
}
