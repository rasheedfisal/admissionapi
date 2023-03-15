namespace admissionapi.api.Dtos.Responses;

public class ErrorsDto
{
    public bool Success { get; set; } = true;
    public List<string> Errors { get; set; }
}
