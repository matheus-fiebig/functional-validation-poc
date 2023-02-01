namespace Application.Common.Validators;

public class HasDataValidator
{
    public static bool IsInvalid<T, F>(Dictionary<T, F> dictionary, T key) => !dictionary.ContainsKey(key);
}