using CSharpFunctionalExtensions;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Pets
{
    public class Pet : Entity<Guid>
    {
        private readonly List<HelpRequisite> _helpRequisites = [];

        private Pet(
        string nickname,
        SpeciesBreedInfo breedInfo,
        string description,
        string color,
        string healthInfo,
        string address,
        decimal? weight,
        decimal? height,
        string phoneNumber,
        bool isSterilized,
        DateTime? birthDate,
        bool isVaccinated,
        HelpStatus status,
        DateTime createdAt)
        {
            Nickname = nickname;
            BreedInfo = breedInfo;
            Description = description;
            Color = color;
            HealthInfo = healthInfo;
            Address = address;
            Weight = weight;
            Height = height;
            PhoneNumber = phoneNumber;
            IsSterilized = isSterilized;
            BirthDate = birthDate;
            IsVaccinated = isVaccinated;
            Status = status;
            CreatedAt = createdAt;
        }

        public string Nickname { get; private set; }
        public SpeciesBreedInfo BreedInfo { get; private set; }
        public string Description { get; private set; }
        public string Color { get; private set; }
        public string HealthInfo { get; private set; }
        public string Address { get; private set; }
        public decimal? Weight { get; private set; }
        public decimal? Height { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsSterilized { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus Status { get; private set; }
        public IReadOnlyCollection<HelpRequisite> HelpRequisites => _helpRequisites.AsReadOnly();
        public DateTime CreatedAt { get; private set; }

        public static Result<Pet> Create (
            string nickname,
            SpeciesBreedInfo breedInfo,
            string description,
            string color,
            string healthInfo,
            string address,
            decimal? weight,
            decimal? height,
            string phoneNumber,
            bool isSterilized,
            DateTime? birthDate,
            bool isVaccinated,
            HelpStatus status,
            List<HelpRequisite> requisites)
        {
            var pet = new Pet(
                nickname,
                breedInfo,
                description,
                color,
                healthInfo,
                address,
                weight,
                height,
                phoneNumber,
                isSterilized,
                birthDate,
                isVaccinated,
                status,
                DateTime.UtcNow
            );
            
            pet._helpRequisites.AddRange(requisites);

            return Result.Success(pet);
        }

        public void UpdateStatus(HelpStatus newStatus) => Status = newStatus;
    }
}
