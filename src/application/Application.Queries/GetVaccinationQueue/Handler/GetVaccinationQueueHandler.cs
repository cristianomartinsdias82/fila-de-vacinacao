using Application.Queries.GetVaccinationQueue.Repository;
using Ardalis.GuardClauses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetVaccinationQueue
{
    public class GetVaccinationQueueHandler : IRequestHandler<GetVaccinationQueueQuery, GetVaccinationQueueQueryResult>
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPriorityByOccupationRulesRepository _priorityByOccupationRulesRepository;
        private static readonly int PeopleGroupCount = 4;
        private readonly IMapper _mapper;

        public GetVaccinationQueueHandler(
            IPeopleRepository peopleRepository,
            IPriorityByOccupationRulesRepository priorityByOccupationRulesRepository,
            IMapper mapper)
        {
            _peopleRepository = Guard.Against.Null(peopleRepository, nameof(peopleRepository));
            _priorityByOccupationRulesRepository = Guard.Against.Null(priorityByOccupationRulesRepository, nameof(priorityByOccupationRulesRepository));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        public async Task<GetVaccinationQueueQueryResult> Handle(GetVaccinationQueueQuery request, CancellationToken cancellationToken)
        {
            var getPeopleResult = await _peopleRepository.GetPeopleAsync(cancellationToken);
            var occupationsWithPriority = await _priorityByOccupationRulesRepository.GetPriorityByOccupationRulesAsync(cancellationToken);

            var peopleGroups = new List<IEnumerable<Person>>();

            foreach (var occupation in occupationsWithPriority)
                peopleGroups.Add(
                    getPeopleResult.People
                            .Where(it => string.Equals(it.OccupationArea, occupation, StringComparison.InvariantCultureIgnoreCase))
                            .OrderByDescending(it => it.Age));

            peopleGroups.Add(
                getPeopleResult.People
                            .Where(it => !occupationsWithPriority.Contains(it.OccupationArea, StringComparer.InvariantCultureIgnoreCase))
                            .OrderByDescending(it => it.Age));

            var flattenedPeopleGroup = peopleGroups.SelectMany(it => it);
            var peopleCount = flattenedPeopleGroup.Count();
            var peoplePerGroupMaxCount = peopleCount / PeopleGroupCount;
            
            var vaccinationQueue = new Dictionary<int, IEnumerable<PersonDto>>();
            for (int i = 0; i < PeopleGroupCount; i++)
            {
                vaccinationQueue[i + 1] = flattenedPeopleGroup
                                            .Skip(peoplePerGroupMaxCount * i)
                                            .Take(peoplePerGroupMaxCount)
                                            .Select(it => _mapper.Map<PersonDto>(it));
            }

            var remainder = peopleCount % PeopleGroupCount;
            if (remainder > 0)
            {
                var lastVaccinationQueue = vaccinationQueue[PeopleGroupCount].ToList();
                lastVaccinationQueue.AddRange(flattenedPeopleGroup.TakeLast(remainder).Select(it => _mapper.Map<PersonDto>(it)));

                vaccinationQueue[PeopleGroupCount] = lastVaccinationQueue;
            }

            return new() { VaccinationQueue = new ReadOnlyDictionary<int, IEnumerable<PersonDto>>(vaccinationQueue) };
        }
    }
}