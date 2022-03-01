namespace GameOfChance.Common
{
    public static class Constants
    {
        public const int MinAccountBalance = 10000;
        public const int BonusPointTimesBy = 9;
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss \"GMT\"zzz";
        // Defining the roles for user. we can define as many as we want
        // either may seed the pre defined roles in the DBContext class or give the interface to create the multiple roles.
        public const string Admin = "Admin";
    }
}