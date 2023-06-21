
namespace IMAP_Survey.Shared
{
    public class InputData
    {
        public Guid? id { get; set; }
        public DateTime SubmitDate { get; set; }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = 0;

        public int CapacitySelection { get; set; }
        public int TastePreference { get; set; }

        public string FavouriteCuisine { get; set; }

        public int TasteContribution { get; set; } = 50;
        public int PricingContribution { get; set; } = 50;
        public int AmountContribution { get; set; } = 50;
        public int AtmosphereContribution { get; set; } = 50;
        public int NuturitionContribution { get; set; } = 50;

        public string RecommendedRestaurant { get; set; }
        public string RecommendedCuisine { get; set; }

        public bool HasUserAnsweredAll { get; set; }
    }
}
