using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Application.Queries.GetVaccinationQueue
{
    public class GetVaccinationQueueQueryResult
    {
        public ReadOnlyDictionary<int, IEnumerable<PersonDto>> VaccinationQueue { get; init; }
    }
}