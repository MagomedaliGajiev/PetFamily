using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Species : Entity<Guid>
    {
        private readonly List<Breed> _breeds = [];

        private Species(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<Breed> Breeds => _breeds.AsReadOnly();

        public Result<Species> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Species>("Name is required");

            return Result.Success(new Species(Guid.NewGuid(), name));
        }
    }
}
