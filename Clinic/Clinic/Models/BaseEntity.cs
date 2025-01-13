namespace Clinic.Models
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreatedTime = DateTime.Now;
        public bool IsDeleted;


    }
}
