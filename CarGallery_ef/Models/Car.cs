namespace CarGallery_ef.Models;
internal class Car : EntityBase
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
    public bool IsAvailable { get; set; }
}
