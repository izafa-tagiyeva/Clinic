namespace Clinic.Models
{
    public class Department : BaseEntity
    {
        public string DepartmentName= null!;
        public IEnumerable<Doctors> Doctor { get; set; }
    }
}
