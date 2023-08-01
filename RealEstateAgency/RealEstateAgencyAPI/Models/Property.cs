namespace RealEstateAgencyAPI.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public double SquareMeters { get; set; }
    }
}
