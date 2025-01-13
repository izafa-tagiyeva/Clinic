namespace Clinic.Models
{
    public class Doctors : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string CoverImage { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        
    }
}
