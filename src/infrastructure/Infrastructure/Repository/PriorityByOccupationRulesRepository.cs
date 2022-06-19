using Application.Queries.GetVaccinationQueue.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PriorityByOccupationRulesRepository : IPriorityByOccupationRulesRepository
    {
        public async Task<IEnumerable<string>> GetPriorityByOccupationRulesAsync(CancellationToken cancellationToken = default)
            => await new ValueTask<IEnumerable<string>>(new Dictionary<int, string>
            {
                [1] = "Saúde",
                [2] = "Educação",
                [3] = "Alimentícios",
                [4] = "Segurança"
            }
            .OrderBy(kvp => kvp.Key)
            .Select(kvp => kvp.Value));
    }
}
