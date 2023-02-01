namespace Application.Common.Validators;

public class EmptyValidator
{
    public static bool IsInvalid(string? value) => string.IsNullOrWhiteSpace(value);

    public static bool IsInvalid(int? value) => !value.HasValue || value.Value == default;
}