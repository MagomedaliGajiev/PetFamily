using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects
{
    public class SpeciesBreedInfo : ValueObject
    {
        public int SpeciesId { get; }
        public int BreedId { get; }

        private SpeciesBreedInfo(int speciesId, int breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }

        public static Result<SpeciesBreedInfo> Create(int speciesId, int breedId)
        {
            if (speciesId <= 0)
                return Result.Failure<SpeciesBreedInfo>("Invalid species ID");

            if (breedId <= 0)
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
