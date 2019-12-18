using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taihang.TodoWebApi.Secure.Models
{
    public class ApiResult
    {
        public enum ResultCode { OK, Error }

        public ResultCode Code { get; set; } // 状态码
        public string Message { get; set; } // 消息

        public static ApiResult OK
        {
            get
            {
                ApiResult ok = new ApiResult();

                ok.Code = ResultCode.OK;
                ok.Message = "OK";

                return ok;
            }
        }

        public static ApiResult Error
        {
            get
            {
                ApiResult error = new ApiResult();

                error.Code = ResultCode.Error;
                error.Message = "Error";

                return error;
            }
        }
    }
}