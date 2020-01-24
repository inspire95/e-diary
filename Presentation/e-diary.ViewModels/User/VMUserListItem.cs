using e_diary.ViewModels.User.Response;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace e_diary.ViewModels.User
{
    [DataContract]
	public class VMUserListItem
	{
		[DataMember]
		public Guid UserId { get; set; }

		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public string Email { get; set; }

        public static VMGetUserListResponse ToResponse(List<VMUserListItem> vmbsic)
        {
            var vmResponse = new VMGetUserListResponse
            {
                Users = vmbsic
            };
            return vmResponse;
        }

        public static VMUserResponse ToResponse(VMUserDetails vmbsic)
        {
            var vmResponse = new VMUserResponse
            {
                User = vmbsic
            };
            return vmResponse;
        }
    }
}
