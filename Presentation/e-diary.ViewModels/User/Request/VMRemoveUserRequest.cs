using System;
using System.Runtime.Serialization;

namespace e_diary.ViewModels.User.Request
{
    [DataContract]
    public class VMRemoveUserRequest
    {
        [DataMember]
        public Guid UserId { get; set; }
    }
}
