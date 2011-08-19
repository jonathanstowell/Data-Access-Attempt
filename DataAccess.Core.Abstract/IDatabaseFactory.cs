using System.Data;

namespace DataAccess.Core.Abstract
{
    public interface IDatabaseFactory
    {
        IDbConnection DbConnection { get; }
    }
}
