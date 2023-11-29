namespace Core.DTOs
{
    public class ServiceResponse
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
