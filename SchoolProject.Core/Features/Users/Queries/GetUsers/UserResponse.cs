namespace SchoolProject.Core.Features.Users.Queries.GetUsers
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
