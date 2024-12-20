namespace ServiceMan.BaseLibrary.Models
{
    public class BaseResultDto<T>
    {
        public T? Result { get; set; }

        public BaseErrorDto? Error { get; set; }

        public bool Success => Error is null;

        public BaseResultDto() {}
        
        public BaseResultDto(BaseErrorDto error)
        {
            Error = error;
        }

        public BaseResultDto(T result)
        {
            Result = result;
        }
    }
}