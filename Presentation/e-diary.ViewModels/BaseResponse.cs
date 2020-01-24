using System;

namespace e_diary.ViewModels.User.Response
{
    public class BaseResponse<T>
    {
        public bool IsSuccess = false;
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public static BaseResponse<T> SetResponse(T data)
        {
            return new BaseResponse<T>
            {
                Data = data,
                IsSuccess = true,
                ErrorMessage = null
            };
        }

        public static BaseResponse<T> SetError(Exception exc)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                ErrorMessage = exc.Message
            };
        }

        public static BaseResponse<T> SetError(string message)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }
    }

    public class BaseResponse
    {
        public bool IsSuccess = false;
        public string ErrorMessage { get; set; }
    }
}