using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileManager.Core.DTOs
{
    public class FolderResponseDto<T>
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }
        public T Foldername { get; set; }

        public static FolderResponseDto<T> Success(int statuscode, string msg, T data)
        {
            return new FolderResponseDto<T> { Statuscode = statuscode, Foldername = data, Message = msg };
        }

        public static FolderResponseDto<T> Fail(int statuscode, string msg)
        {
            return new FolderResponseDto<T> { Statuscode = statuscode, Message = msg };
        }
    }
}
