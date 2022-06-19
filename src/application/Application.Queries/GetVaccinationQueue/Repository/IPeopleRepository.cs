using Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetVaccinationQueue.Repository
{
    public interface IPeopleRepository
    {
        Task<PersonCollection> GetPeopleAsync(
            CancellationToken cancellationToken = default);
        //Task<IEnumerable<Person>> GetPeopleAsync(
        //    CancellationToken cancellationToken = default);
    }
}
