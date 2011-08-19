using DataAccess.ColumnProvider.Abstract;

namespace DataAccess.ColumnProvider.Concrete
{
    public class PersonColumnProvider : IPersonColumnProvider
    {
        public string PersonID
        {
            get { return "PersonID"; }
        }

        public string FirstName
        {
            get { return "FirstName"; }
        }

        public string LastName
        {
            get { return "LastName"; }
        }

        public string Email
        {
            get { return "Email"; }
        }
    }
}
