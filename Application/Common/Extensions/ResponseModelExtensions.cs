using Application.Common.Models;

namespace Application.Common.Extensions;

public static class ResponseModelExtensions
{
  public static ResponseObject Match<T, F>(this IEnumerable<ValidatorObject<T>> source, Func<IEnumerable<T>, F> onSuccess, Func<IEnumerable<string>, ResponseObject> onError)
  {
      var validators = source.ToList();
      
      var hasErrors = validators.Any(x => !x.Success);
      if (hasErrors)
      {
          var errors = validators.SelectMany(x => x.Errors);
          return onError(errors);
      }

      var items = validators.Select(x => x.Item);
      return ResponseObject.Create(onSuccess(items)!);
  } 
  
  public static ResponseObject Match<T, F>(this ValidatorObject<T> source, Func<T, F> onSuccess, Func<IEnumerable<string>, ResponseObject> onError)
  {
      if (!source.Success)
      {
          return onError(source.Errors);
      }

      return ResponseObject.Create(onSuccess(source.Item)!);
  } 
}