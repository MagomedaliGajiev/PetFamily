using CSharpFunctionalExtensions;

namespace PetFamily.Domain.ValueObjects
{
    public class SocialMediaLink : ValueObject
    {
        public string Name { get; }
        public string Url { get; }

        private SocialMediaLink(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public static Result<SocialMediaLink> Create(string name, string url)
        {
            //придумать логику валидации
            return Result.Success(new SocialMediaLink(name, url));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Name;
            yield return Url;
        }
    }
}
