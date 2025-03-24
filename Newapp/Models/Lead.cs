namespace Newapp.Models
{
    public class Lead
    {
        public int LeadId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string MeetingId { get; set; }
        public bool GoogleDrive { get; set; }
        public string GoogleDriveFolderId { get; set; }
        public List<File> Files { get; set; }
        public List<LeadAction> LeadActions { get; set; }
    }

    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileData { get; set; } // Base64 encoded string
        public string FileType { get; set; }
    }

    public class LeadAction
    {
        public int ActionId { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
