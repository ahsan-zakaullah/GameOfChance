using GameOfChance.Common;

namespace GameOfChance.Models
{
    public static class PlayerMapper
    {
        public static PlayerAccount Map(this BetRequest source, int accountBalance = 0, bool isSuccess = false)
        {
            Guid.TryParse(source.CreatedBy, out Guid result);
            return new PlayerAccount
            {
                Account = accountBalance,
                Points = source.Points,
                Status = isSuccess ? ((short)StatusEnum.Won) : ((short)StatusEnum.Lost),
                CreatedDate = source.CreatedDate,
                CreatedBy = result
            };

        }
        public static BetResponse Map(this PlayerAccount source)
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
