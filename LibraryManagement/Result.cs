using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class Result
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public static Result Failed(string msg)
        {
            Result result = new Result();
            result.Success = false;
            result.Message = msg;

            return result;
        }

        public static Result Ok()
        {
            Result result = new Result();
            result.Success = true;
            return result;
        }
    }
}
