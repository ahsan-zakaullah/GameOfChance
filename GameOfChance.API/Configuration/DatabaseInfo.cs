namespace GameOfChance.API.Configuration
{
    public class DatabaseInfo
    {
        public DatabaseInfo(string host, string username, string password, string database)
        {
            Username = username;
            Password = password;
            Host = host;
            Database = database;
        }

        private string Username { get; }
        private string Password { get; }
        private string Host { get; }
        private string Database { get; }

        public string ConnectionString => $"User ID={Username};Password={Password};Server={Host};Database={Database};TrustServerCertificate=True;";
    }
}
