namespace Resume_Shortlisting_Azure.Models.DTOs
{
    public class EmployeeUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public int YearsOfExperience { get; set; }
        public string TechnologyDomain { get; set; }
        public byte[] Resume { get; set; }
    }
}
