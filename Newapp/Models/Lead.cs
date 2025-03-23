namespace Newapp.Models
{
    public class Lead
    {
        public int LeadId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
