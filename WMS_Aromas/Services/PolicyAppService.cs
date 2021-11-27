using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.App.Services
{
    public class PolicyAppService : AppServiceBase<Policy>, IPolicyAppService
    {
        private readonly IPolicyService _policyService;

        public PolicyAppService(IPolicyService policyService)
            : base(policyService)
        {
            _policyService = policyService;
        }
    }
}
