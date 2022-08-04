namespace Core.Entities.CountryEntity
{
    public class CountryTranslate
    {
        public int CountryTranslateId { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? LangId { get; set; }
    }
}
