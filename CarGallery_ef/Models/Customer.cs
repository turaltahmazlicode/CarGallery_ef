namespace CarGallery_ef.Models;
internal class Customer : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
}
