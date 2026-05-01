using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.ApiResponse
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data , string message )
        {

            return new ApiResponse<T>
            {
                Success = true,
                Message= message ,
                Data=data,
                Error= null
            };
        }
        public static ApiResponse<T> ErrorResponse( string message)
        {

            return new ApiResponse<T>
            {
                Success= false,
                Message = "Failed",
                Data= default,
                Error=message
          };

        }

        public static IActionResult SuccessResponse(CreatedAtActionResult data, string v)
        {
            throw new NotImplementedException();
        }
    }
}
