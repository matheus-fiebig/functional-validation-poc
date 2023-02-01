namespace Application.Common.Models;

public class ValidatorObject<T>
{
    public T Item { get; set; }
    
    public List<string> Errors { get; set; }
    
    public bool Success => !Errors.Any();

    public ValidatorObject(T item, List<string> errors)
    {
        Item = item;
        Errors = errors;
    }
    
    public ValidatorObject(T data)
    {
        Errors = new List<string>();
        Item = data;
    }

    public static implicit operator ValidatorObject<T>(T data) => new(data);
}