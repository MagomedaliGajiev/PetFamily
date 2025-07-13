using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects
{
    public class SpeciesBreedInfo : ValueObject
    {
        private SpeciesBreedInfo(Guid speciesId, Guid breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }

        public Guid SpeciesId { get; }
        public Guid BreedId { get; }

        public static Result<SpeciesBreedInfo> Create(Guid speciesId, Guid breedId)
        {
            if (speciesId == Guid.Empty)
                return Result.Failure<SpeciesBreedInfo>("Invalid species ID");

            if (breedId == Guid.Empty)
                return Result.Failure<SpeciesBreedInfo>("Invalid breed ID");

            return Result.Success(new SpeciesBreedInfo(speciesId, breedId));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return SpeciesId;
            yield return BreedId;
        }
    }
}
