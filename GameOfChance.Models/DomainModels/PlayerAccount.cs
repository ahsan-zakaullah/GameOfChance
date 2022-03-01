namespace GameOfChance.Models
{
    public class PlayerAccount : BaseModel
    {
        public int Account { get; set; }
        public short Status { get; set; }
        public int Points { get; set; }

    }
}
