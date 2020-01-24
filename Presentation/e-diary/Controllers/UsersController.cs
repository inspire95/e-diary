using e_diary.Service.Interfaces;
using e_diary.ViewModels;
using e_diary.ViewModels.User;
using e_diary.ViewModels.User.Request;
using e_diary.ViewModels.User.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace e_diary.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetUsers")]
        [HttpGet]
        public BaseResponse<VMGetUserListResponse> GetUsers(VMGetUserListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userService.GetAll(vmRequest);
                var responseObject = VMUserListItem.ToResponse(result);
                var response = BaseResponse<VMGetUserListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserListResponse>.SetError(exc);
            }
        }

        [Route("GetUserDetails")]
        [HttpGet]
        public BaseResponse<VMUserResponse> Get(VMGetUserDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userService.Get(vmRequest);
                var responseObject = VMUserListItem.ToResponse(result);
                var response = BaseResponse<VMUserResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserResponse>.SetError(exc);
            }
        }

        [Route("CreateUsers")]
        [HttpPost]
        public BaseResponse<VMUserResponse> Create([FromBody]VMCreateUserRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserResponse>.SetError("Request body is empty");
            }

            //try
            //{
            var result = _userService.Create(vmRequest);
            var responseObject = VMUserListItem.ToResponse(result);
            var response = BaseResponse<VMUserResponse>.SetResponse(responseObject);
            return response;
            //}
            //catch (Exception exc)
            //{
            //    return BaseResponse<VMUserResponse>.SetError(exc);
            //}
        }

        [Route("UpdateUser")]
        [HttpPut]
        public BaseResponse<VMUserResponse> Update([FromBody]VMUpdateUserRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userService.Update(vmRequest);
                var responseObject = VMUserListItem.ToResponse(result);
                var response = BaseResponse<VMUserResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserResponse>.SetError(exc);
            }
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveUserRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }

            try
            {
                bool result = _userService.Remove(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }
    }
}