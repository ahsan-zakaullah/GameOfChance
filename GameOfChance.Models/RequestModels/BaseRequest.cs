namespace GameOfChance.Models
{
    public class BaseRequest
    {
        // Going to define the date and time as string because
        // we can apply the datetime format on it which will help on the front-end side for TIME ZONE conversion
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
