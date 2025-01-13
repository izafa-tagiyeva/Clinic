namespace Clinic.ViewModels.Card
{
    public class CardCreateVM
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public IFormFile CoverFile { get; set; }

        public int DepartmentId { get; set; }



    }
}
