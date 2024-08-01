﻿namespace DreamTravel.CQRS.Results.DestinationResults
{
    public class GetDestinationByIDQueryResult
    {
        public int? destinationid { get; set; }
        public string? city { get; set; }
        public string? duration { get; set; }
        public double? price { get; set; }
    }
}
