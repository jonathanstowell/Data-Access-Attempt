using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.ColumnProvider.Abstract;

namespace DataAccess.ColumnProvider.Concrete
{
    public class PostColumnProvider : IPostColumnProvider
    {
        public string PostId
        {
            get { return "PostId"; }
        }

        public string CreatorId
        {
            get { return "CreatorId"; }
        }

        public string Content
        {
            get { return "Content"; }
        }

        public string CreatedDateTime
        {
            get { return "CreatedDateTime"; }
        }
    }
}
