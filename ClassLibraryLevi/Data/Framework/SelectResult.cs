using System.Data;

namespace ClassLibraryLevi.Data.Framework
{
    public class SelectResult : BaseResult
    {
        public DataTable DataTable { get; set; } = new DataTable();
    }
}
