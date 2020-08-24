using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Domain.Services.Services
{
    public class ServicePerson : ServiceBase<Person>, IServicePerson
    {
        public readonly IRepositoryPerson _repositoryPerson;

        public ServicePerson(IRepositoryPerson RepositoryPerson)
            : base(RepositoryPerson)
        {
            _repositoryPerson = RepositoryPerson;
        }

    }
}
