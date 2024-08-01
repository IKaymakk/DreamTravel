namespace DreamTravel.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int? id { get; set; }
        public string? city { get; set; }
        public string? duration { get; set; }
        public double? price { get; set; }
        public int? personcapacity { get; set; }
    }
}
