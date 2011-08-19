namespace DataAccess.Core.Abstract
{
    public interface IObjectKeyReaderBase<T> : IObjectWriterBase<T> where T : new()
    {
        T GetById(int id);
    }
}