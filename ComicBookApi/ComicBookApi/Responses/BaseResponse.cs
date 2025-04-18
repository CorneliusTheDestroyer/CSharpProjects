namespace ComicBookApi.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public BaseResponse() { }

        public BaseResponse(T data, string? message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public BaseResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Data = default;
        }
    }
}
