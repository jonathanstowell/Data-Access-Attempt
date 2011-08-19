using System.Data;

namespace DataAccess.Core.Abstract
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }

        bool IsInTransaction { get; }

        void BeginTransaction();

        void RollBackTransaction();

        bool CommitTransaction();
    }
}
