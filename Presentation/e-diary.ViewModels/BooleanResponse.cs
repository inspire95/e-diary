using e_diary.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace e_diary.ViewModels
{
    [DataContract]
    public class BooleanResponse : BaseResponse
    {
        [DataMember]
        public bool Value { get; private set; }

        public BooleanResponse()
        {
            Value = false;
        }

        public BooleanResponse(bool value)
        {
            Value = value;
        }
    }
}
