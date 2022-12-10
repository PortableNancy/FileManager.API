using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Generic;

namespace FileManager.Core.DTOs
{
    public class FileResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Status { get; set; }


        public static FileResponseDto<T> Success(int statuscode, string msg, T data)
        {
            return new FileResponseDto<T> { StatusCode = statuscode, Data = data, Message = msg };
        }

        public static FileResponseDto<T> Fail(int statuscode, string msg)
        {
            return new FileResponseDto<T> { StatusCode = statuscode, Message = msg };
        }
    }
}
