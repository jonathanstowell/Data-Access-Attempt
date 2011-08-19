namespace DataAccess.ColumnProvider.Abstract
{
    public interface IPostColumnProvider
    {
        string PostId { get; }
        string CreatorId { get; }
        string Content { get; }
        string CreatedDateTime { get; }
    }
}
