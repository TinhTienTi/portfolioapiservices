using System.Linq.Expressions;

namespace PortfolioServices.Repositories.Interfaces;

public interface IGenericRepository<TEntity, TDto>
{
    TDto Add(TDto dto);

    TDto[] Add(TDto[] dtos);

    Task<TDto> AddAsync(TDto dto);

    TDto Edit(TDto dto);

    TDto[] Edit(TDto[] dtos);

    IEnumerable<TDto> Find(Expression<Func<TDto, bool>> expression);

    IEnumerable<TDto> GetAll();

    Task<IEnumerable<TDto>> GetAllAsync();

    TDto GetById(Guid id);

    IQueryable<TAny> GetQueryable<TAny>() where TAny : class;

    void Remove(TDto dto);

    void Remove(IEnumerable<TDto> dtos);
}
