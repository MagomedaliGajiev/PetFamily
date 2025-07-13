using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects
{
    public class HelpRequisite : ValueObject
    {
        private HelpRequisite(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }
        public string Description { get; }

        public static Result<HelpRequisite> Create(string  title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<HelpRequisite>("Title is required");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<HelpRequisite>("Description is required");

            return Result.Success(new HelpRequisite(title, description));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return Description;
        }
    }
}
