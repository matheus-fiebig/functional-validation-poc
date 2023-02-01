namespace Application.Common.Models;

public class ResponseObject
{
    public object? Data { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    
    public bool Success => Errors == null || !Errors.Any();

    public static ResponseObject Create (IEnumerable<string> errors) => new() { Errors = errors };

    public static ResponseObject Create (object data) => new() { Data = data };
}