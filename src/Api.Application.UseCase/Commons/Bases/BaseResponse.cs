namespace Api.Application.UseCase.Commons.Bases
{
    public class BaseResponse <T>
    {
        public bool  IsSuccess { get; set; }
        public T? data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
