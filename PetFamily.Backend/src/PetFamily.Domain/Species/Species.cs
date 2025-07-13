using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Species : Entity<int>
    {
        public string Name { get; private set; }
        public IReadOnlyCollection<Breed> Breeds => _breeds.AsReadOnly();


        private readonly List<Breed> _breeds = [];

        private Species(string name)
        {
            Name = name;
        }

        public Result<Species> Create(string name)
        {
            // Валидация
            return Result.Success(new Species(name));
        }
    }
}
