using GameOfChance.Common;
using GameOfChance.Common.Enumeration;
using GameOfChance.Models.DomainModels;
using GameOfChance.Models.RequestModels;
using GameOfChance.Models.ResponseModels;

namespace GameOfChance.Models.Mappers
{
    public static class PlayerMapper
    {
        public static Player Map(this BetRequest source, int accountBalance = 0, bool isSuccess = false)
        {
            return new Player
            {
                Account = accountBalance,
                Points = source.Points,
                Status = isSuccess ? ((short)StatusEnum.Won) : ((short)StatusEnum.Lost),
                CreatedDate = DateTime.UtcNow
            };

        }
        public static BetResponse Map(this Player source)
        {
            return new BetResponse
            {
                Account = source.Account,
                Points = source.Status == (short)StatusEnum.Won ? "+" + source.Points : "-" + source.Points,
                Status = Enum.GetName(typeof(StatusEnum), source.Status) // Get the value from enum
            };

        }
    }
}
