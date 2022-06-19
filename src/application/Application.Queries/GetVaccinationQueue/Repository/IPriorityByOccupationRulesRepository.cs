using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetVaccinationQueue.Repository
{
    public interface IPriorityByOccupationRulesRepository
    {
        Task<IEnumerable<string>> GetPriorityByOccupationRulesAsync(CancellationToken cancellationToken = default);
    }
}
