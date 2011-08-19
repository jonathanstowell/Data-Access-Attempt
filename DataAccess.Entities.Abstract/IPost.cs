using System;

namespace DataAccess.Entities.Abstract
{
    public interface IPost
    {
        int PostId { get; set; }
        IPerson Creator { get; set; }
        string Content { get; set; }
        DateTime CreatedDateTime { get; set; }
    }
}