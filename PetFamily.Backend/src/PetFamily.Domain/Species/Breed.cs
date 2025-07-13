using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species
{
    public class Breed : Entity<int>
    {
        private string Name { get; private set; }

        public Breed(string name)
        {
            Name = name;
        }

        public static Result<Breed> Create(string name)
        {
            //Валидация
            return Result.Success(new Breed(name));
        }
    }
}