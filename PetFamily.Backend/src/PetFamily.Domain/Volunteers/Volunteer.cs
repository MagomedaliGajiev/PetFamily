using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteers
{
    public class Volunteer : Entity<Guid>
    {
        private readonly List<SocialMediaLink> _socialMediaLinks = [];
        private readonly List<HelpRequisite> _helpRequisites = [];
        private readonly List<Pet> _pets = [];

        private Volunteer(
        string fullName,
        string email,
        string description,
        int? experienceYears,
        string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            Description = description;
            ExperienceYears = experienceYears;
            PhoneNumber = phoneNumber;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string  Description { get; private set; }
        public int? ExperienceYears { get; private set; }
        public string PhoneNumber { get; private set; }
        public IReadOnlyCollection<SocialMediaLink> SocialMediaLinks => _socialMediaLinks.AsReadOnly();
        public IReadOnlyCollection<HelpRequisite> HelpRequisites => _helpRequisites.AsReadOnly();
        public IReadOnlyCollection<Pet> Pets => _pets.AsReadOnly();

        public static Result<Volunteer>Create(
            string fullName,
            string email,
            string description,
            int? experienceYears,
            string phoneNumber,
            List<SocialMediaLink> socialMedia,
            List<HelpRequisite> requisites)
        {
            var volunteer = new Volunteer(
            fullName,
            email,
            description,
            experienceYears,
            phoneNumber
            );

            volunteer._socialMediaLinks.AddRange(socialMedia);
            volunteer._helpRequisites.AddRange(requisites);

            return Result.Success(volunteer);
        }

        public int FoundHomeCount() =>
            _pets.Count(p => p.Status == HelpStatus.FoundHome);

        public int CurrentlyLookingCount() =>
            _pets.Count(p => p.Status == HelpStatus.LookingForHome);

        public int UnderTreatmentCount() =>
            _pets.Count(p => p.Status == HelpStatus.NeedsHelp);
    }
}
