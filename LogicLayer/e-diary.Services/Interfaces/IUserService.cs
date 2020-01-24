using e_diary.ViewModels.User;
using e_diary.ViewModels.User.Request;
using System.Collections.Generic;

namespace e_diary.Service.Interfaces
{
    public interface IUserService
    {
        List<VMUserListItem> GetAll(VMGetUserListRequest vmrequest);
        VMUserDetails Get(VMGetUserDetailsRequest vmrequest);
        VMUserDetails Create(VMCreateUserRequest vmrequest);
        bool Remove(VMRemoveUserRequest vmrequest);
        VMUserDetails Update(VMUpdateUserRequest vmrequest);
    }
}