namespace CarGallery_ef.Models;
internal class Rental : EntityBase
{
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public virtual Car Car { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}
