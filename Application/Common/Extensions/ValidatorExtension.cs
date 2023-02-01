using Application.Common.Models;

namespace Application.Common.Extensions;

public static class ValidatorExtension
{
    public static IEnumerable<ValidatorObject<T>> AsValidator<T>(this IEnumerable<T> source)
    {
        foreach (var validator in source)
            yield return validator;
    }
    
    public static ValidatorObject<T> AsValidator<T>(this T source)
    {
        return source;
    }
    
    public static IEnumerable<ValidatorObject<T>> Validate<T>
        (this IEnumerable<ValidatorObject<T>> source,Func<T, bool> condition, Func<T, string> error)
    {
        foreach (var validator in source)
            yield return Validate(validator, condition, error(validator.Item));
    }

    public static ValidatorObject<T> Validate<T>(this ValidatorObject<T> source, Func<T, bool> condition, string error)
    {
        var errors = new List<string>(source.Errors);
        
        if (condition(source.Item)) 
            errors.Add(error);            

        return new(source.Item, errors);
    }
}