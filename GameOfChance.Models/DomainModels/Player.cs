using GameOfChance.Models.CommonModels;

namespace GameOfChance.Models.DomainModels
{
    public class Player : BaseModel
    {
        public int Account { get; set; }
        public short Status { get; set; }
        public int Points { get; set; }

    }
}
