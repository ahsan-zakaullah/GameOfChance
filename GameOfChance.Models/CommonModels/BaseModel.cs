namespace GameOfChance.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
