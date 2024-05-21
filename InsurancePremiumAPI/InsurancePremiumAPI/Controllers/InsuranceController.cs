using InsurancePremiumAPI.Dtos;
using InsurancePremiumAPI.Factories;
using InsurancePremiumAPI.Interfaces;
using InsurancePremiumAPI.Rules;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePremiumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        [HttpPost("term/calculate-premium")]
        public ActionResult<decimal> CalculateTermPremium([FromBody] TermInsuranceRequest request)
        {
            var rules = new List<IRule> { new AgeRule(), new PremiumTermRule() };
            var insurance = InsuranceFactory.CreateInsurance("Term", request.Age, request.PremiumTerm, rules: rules);
            var premium = insurance.CalculatePremium();
            return Ok(premium);
        }

        [HttpPost("health/calculate-premium")]
        public ActionResult<decimal> CalculateHealthPremium([FromBody] HealthInsuranceRequest request)
        {
            var rules = new List<IRule> { new AgeRule(), new PremiumTermRule(), new HealthRecordRule() };
            var insurance = InsuranceFactory.CreateInsurance("Health", request.Age, request.PremiumTerm, request.HealthRecord, rules: rules);
            var premium = insurance.CalculatePremium();
            return Ok(premium);
        }
    }
}
