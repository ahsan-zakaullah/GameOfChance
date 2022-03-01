namespace GameOfChance.Common
{
    // Creating the custom exception just for reference.
    // We can use that to show some fancy messages based on the scanarioes
    public class GameOfChanceException : Exception
    {
        public GameOfChanceException(string message)
            : base(message)
        {

        }

    }
}
