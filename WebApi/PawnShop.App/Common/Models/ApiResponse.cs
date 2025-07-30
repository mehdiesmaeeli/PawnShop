namespace PawnShop.App.Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string TraceId { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success") =>
            new() { Success = true, Data = data, Message = message, Errors = null, TraceId = null };

        public static ApiResponse<T> Error(string message, List<string> errors = null, string traceId = null) =>
            new() { Success = false, Data = default, Message = message, Errors = errors ?? new List<string>(), TraceId = traceId };
    }
}
