using System.Collections.Generic;
using System.Runtime.Serialization;

namespace e_diary.ViewModels.User.Request
{
    [DataContract]
    public class VMCreateUserRequest
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
