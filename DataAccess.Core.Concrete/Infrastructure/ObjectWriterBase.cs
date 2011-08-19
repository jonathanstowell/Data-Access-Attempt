using System;
using System.Collections.Generic;
using System.Data;
using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Infrastructure
{
    public abstract class ObjectWriterBase<T> : ObjectReaderBase<T>, IObjectWriterBase<T> where T : new()
    {
        protected ObjectWriterBase(IDatabaseFactory databaseFactory, IMapper<T> mapper)
            : base(databaseFactory, mapper)
        { }

        public abstract bool Add(T item);

        public virtual bool Add(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
            return true;
        }

        public abstract bool Update(T item);

        public virtual bool Update(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Update(item);
            }
            return true;
        }

        public abstract bool Delete(T item);

        public virtual bool Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Delete(item);
            }
            return true;
        }

        public bool ExecuteWrite(CommandType commandType, string commandText)
        {
            return ExecuteWrite(commandType, commandText, null);
        }

        public bool ExecuteWrite(CommandType commandType, string commandText, ICollection<IDataParameter> parameters)
        {
            IDbCommand command = Connection.CreateCommand();
            command.Connection = Connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (UnitOfWork.IsInTransaction)
                command.Transaction = UnitOfWork.Transaction;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            try
            {
                if (!UnitOfWork.IsInTransaction)
                    Connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (!UnitOfWork.IsInTransaction)
                    Connection.Close();
            }

            return true;
        }
    }
}
