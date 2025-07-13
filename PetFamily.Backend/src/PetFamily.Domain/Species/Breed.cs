using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Breed : Entity<Guid>
    {
        private Breed(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public static Result<Breed> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Breed>("Name is required");

            return Result.Success(new Breed(Guid.NewGuid(), name));
        }
    }
}