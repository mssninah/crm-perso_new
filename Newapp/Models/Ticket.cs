namespace Newapp.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public Manager Manager { get; set; }
        public Employee Employee { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Manager
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public OAuthUser OAuthUser { get; set; }
        public List<string> Roles { get; set; }
    }

    public class OAuthUser
    {
        public int Id { get; set; }
        public List<string> GrantedScopes { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenIssuedAt { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenIssuedAt { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
