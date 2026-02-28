using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.DTOs.Response
{
    public class BaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = "";
        public async static Task<BaseResponse<T>> SuccessAsync(T data, string message)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
            return response;
        }
        public async static Task<BaseResponse<T>> SuccessAsync(T data)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                IsSuccess = true,
                Data = data
            };
            return response;
        }
        public async static Task<BaseResponse<T>> SuccessAsync(string message)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                IsSuccess = true,
                Message = message
            };
            return response;
        }
        public async static Task<BaseResponse<T>> FailureAsync(T data, string message)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message,
                Data = data
            };
            return response;
        }
        public async static Task<BaseResponse<T>> FailureAsync(string message)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message
            };
            return response;
        }
        public async static Task<BaseResponse<T>> FailureAsync(string message, HttpStatusCode statusCode)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                StatusCode = statusCode,
                IsSuccess = false,
                Message = message
            };
            return response;
        }
    }
}
