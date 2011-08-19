using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Infrastructure
{
    public abstract class ObjectKeyReaderBase<T> : ObjectWriterBase<T>, IObjectKeyReaderBase<T> where T : new()
    {
        protected ObjectKeyReaderBase(IDatabaseFactory databaseFactory, IMapper<T> mapper)
            : base(databaseFactory, mapper)
        { }

        public abstract T GetById(int id);
    }
}
