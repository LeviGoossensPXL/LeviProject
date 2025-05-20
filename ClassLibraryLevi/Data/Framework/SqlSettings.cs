using System.Text;

namespace ClassLibraryLevi.Data.Framework
{
    public static class SqlSettings
    {
        public static string ConnectionString { get; set; } = GetConnectionStringLocal("LaboDb1");

        public static string GetConnectionStringLocal(string databaseName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=.\\SQLEXPRESS;");
            sb.Append($"Database={databaseName};");
            sb.Append("Integrated Security=True;");
            sb.Append("TrustServerCertificate=True;");
            return sb.ToString();
        }

        public static string GetConnectionString(string user, string password, string serverAdress, string databaseName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"user id={user};");
            sb.Append($"Password={password};");
            sb.Append($"Server={serverAdress};");
            sb.Append($"Database={databaseName}");
            return sb.ToString();
        }
    }
}
