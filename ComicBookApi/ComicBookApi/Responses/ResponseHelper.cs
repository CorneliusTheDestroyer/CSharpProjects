namespace ComicBookApi.Responses
{
    public static class ResponseHelper
    {
        public static BaseResponse<T> Ok<T>(T data, string? message = null) =>
            new(data, message);

        public static BaseResponse<T> Fail<T>(string errorMessage) =>
            new(errorMessage);
    }
}
