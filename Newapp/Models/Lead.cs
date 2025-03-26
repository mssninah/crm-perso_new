using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Newapp.Models
{
    public class Lead
    {
        [JsonPropertyName("leadId")]
        public int LeadId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("meetingId")]
        public string MeetingId { get; set; }

        [JsonPropertyName("googleDrive")]
        public bool GoogleDrive { get; set; }

        [JsonPropertyName("googleDriveFolderId")]
        public string GoogleDriveFolderId { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; } = new List<File>();

        [JsonPropertyName("leadActions")]
        public List<LeadAction> LeadActions { get; set; } = new List<LeadAction>();
    }

    public class File
    {
        [JsonPropertyName("fileId")]
        public int FileId { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("fileData")]
        public string FileData { get; set; } // Base64 encoded string

        [JsonPropertyName("fileType")]
        public string FileType { get; set; }
    }

    public class LeadAction
    {
        [JsonPropertyName("actionId")]
        public int ActionId { get; set; }

        [JsonPropertyName("actionType")]
        public string ActionType { get; set; }

        [JsonPropertyName("actionDate")]
        public DateTime ActionDate { get; set; }
    }
}
