namespace Resume_Shortlisting_Azure.Models.Domain
{
    public class EmployeeUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public int YearsOfExperience { get; set; }
        public string TechnologyDomain { get; set; }
        //public byte[] Resume { get; set; }
        public byte[] Resume { get; set; }
        public string? ResumeFileName { get; internal set; }
    }
}
