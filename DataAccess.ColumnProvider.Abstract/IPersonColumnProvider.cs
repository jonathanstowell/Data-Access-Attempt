namespace DataAccess.ColumnProvider.Abstract
{
    public interface IPersonColumnProvider
    {
        string PersonID { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
    }
}
