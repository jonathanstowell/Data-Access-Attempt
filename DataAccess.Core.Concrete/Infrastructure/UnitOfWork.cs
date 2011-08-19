using System;
using System.Data;
using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public bool IsInTransaction
        {
            get { return _transaction != null; }
        }

        public void BeginTransaction()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Rolls the back transaction.
        /// </summary>
        public void RollBackTransaction()
        {
            _transaction.Rollback();
            _connection.Close();
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        /// <exception cref="ApplicationException">Cannot roll back a transaction while there is no transaction running.</exception>
        public bool CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            try
            {
                _transaction.Commit();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                return false;
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }

        /// <summary>
        /// Releases the current transaction
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (_transaction == null) return;
            _transaction.Dispose();
            _transaction = null;
        }

        protected override void DisposeCore()
        {
            ReleaseCurrentTransaction();
            base.DisposeCore();
        }
    }
}
