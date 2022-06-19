using Application.Queries.GetVaccinationQueue.Repository;
using ApplicationCommon.Repository;
using Domain;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PeopleRepository : Repository<PersonCollection>, IPeopleRepository
    {
        private readonly JsonFormatPeopleData _peopleData;

        public PeopleRepository(JsonFormatPeopleData peopleData)
        {
            _peopleData = peopleData;
        }

        public async Task<PersonCollection> GetPeopleAsync(CancellationToken cancellationToken = default)
            => await new ValueTask<PersonCollection>(JsonSerializer.Deserialize<PersonCollection>(_peopleData.JsonData));
    }
}