using System.Text.Json;

namespace WebApi.Dto
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
