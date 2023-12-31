using System.Linq.Expressions;
using Domain.Models;

namespace Application.Contracts.Specification;

public interface ISpecification<T> where T: BaseModel
{
    
    Expression<Func<T, bool>> Criteria { get; }
    List<string> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }

}