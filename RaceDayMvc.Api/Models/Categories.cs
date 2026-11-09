namespace RaceDayMvc.Api.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public int EventId { get; set; }
        public string CategoryName { get; set; } = ""; 
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
    }
}
