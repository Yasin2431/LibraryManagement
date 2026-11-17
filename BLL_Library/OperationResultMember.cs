using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Library
{
   
    public class OperationResultMember
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static OperationResultMember Ok(string message = "عملیات با موفقیت انجام شد.")
        {
            return new OperationResultMember { Success = true, Message = message };
        }

        public static OperationResultMember Fail(string message)
        {
            return new OperationResultMember { Success = false, Message = message };
        }
    }

    public class OperationResultMember<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static OperationResultMember<T> Ok(T data, string message = "عملیات با موفقیت انجام شد.")
        {
            return new OperationResultMember<T> { Success = true, Data = data, Message = message };
        }

        public static OperationResultMember<T> Fail(string message)
        {
            return new OperationResultMember<T> { Success = false, Message = message, Data = default };
        }
    }
}

