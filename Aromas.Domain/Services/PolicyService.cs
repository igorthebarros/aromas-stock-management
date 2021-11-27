using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.Domain.Services
{
    public class PolicyService : ServiceBase<Policy>, IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
            : base(policyRepository)
        {
            _policyRepository = policyRepository;
        }
    }
}