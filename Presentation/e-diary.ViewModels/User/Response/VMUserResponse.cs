using System.Collections.Generic;
using System.Runtime.Serialization;

namespace e_diary.ViewModels.User.Response
{
    [DataContract]
	public class VMUserResponse : BaseResponse
	{
		[DataMember]
		public VMUserDetails User { get; set; }
	}
}
