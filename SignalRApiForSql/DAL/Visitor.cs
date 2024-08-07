namespace SignalRApiForSql.DAL
{
    public enum ECity
    {
        Adana = 1,
        İstanbul = 2,
        Londra = 3,
        Mardin = 4,
        Bursa = 5,
    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
