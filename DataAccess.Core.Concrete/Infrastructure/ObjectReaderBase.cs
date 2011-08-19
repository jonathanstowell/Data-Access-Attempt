using System;
using System.Collections.Generic;
using System.Data;
using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Infrastructure
{
    public abstract class ObjectReaderBase<T> : IDisposable, IObjectReaderBase<T> where T : new()
    {
        private IUnitOfWork _unitOfWork;

        private IDbConnection _connection;

        public IDatabaseFactory DatabaseFactory { get; private set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = DatabaseFactory.DbConnection;

                return _connection;
            }
        }

        public IMapper<T> Mapper { get; private set; }

        protected ObjectReaderBase(IDatabaseFactory databaseFactory, IMapper<T> mapper)
        {
            DatabaseFactory = databaseFactory;
            Mapper = mapper;
        }

        public abstract ICollection<T> GetAll();

        public T ExecuteSingle(CommandType commandType, string commandText)
        {
            return ExecuteSingle(commandType, commandText, null);
        }

        public T ExecuteSingle(CommandType commandType, string commandText, ICollection<IDataParameter> parameters)
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

                using (IDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        return Mapper.MapSingle(reader);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (!UnitOfWork.IsInTransaction) 
                    Connection.Close();
            }
        }

        public ICollection<T> ExecuteCollection(CommandType commandType, string commandText)
        {
            return ExecuteCollection(commandType, commandText, null);
        }

        public ICollection<T> ExecuteCollection(CommandType commandType, string commandText, ICollection<IDataParameter> parameters)
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

                using (IDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        return Mapper.MapCollection(reader);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (!UnitOfWork.IsInTransaction)
                    Connection.Close();
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(Connection);
                }
                return _unitOfWork;
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
