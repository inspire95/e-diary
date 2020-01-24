using System.Collections.Generic;
using System.Runtime.Serialization;

namespace e_diary.ViewModels.User.Response
{
    [DataContract]
    public class VMGetUserListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMUserListItem> Users { get; set; }
    }
}
