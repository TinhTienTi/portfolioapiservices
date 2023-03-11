using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortfolioServices.Context;
using PortfolioServices.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PortfolioServices.Repositories;

public class GenericRepository<TEntity, TDto> : IGenericRepository<TEntity, TDto>
  where TEntity : class
  where TDto : class
{
    protected readonly PortfoliServicesContext context;
    private readonly IMapper mapper;

    public GenericRepository(PortfoliServicesContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public TDto Add(TDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var entity = mapper.Map<TDto, TEntity>(dto);

        var result = context.Set<TEntity>().Add(entity).Entity;
        context.SaveChanges();

        return mapper.Map<TEntity, TDto>(result);
    }

    public TDto[] Add(TDto[] dtos)
    {
        if (dtos is null)
        {
            throw new ArgumentNullException(nameof(dtos));
        }

        var entities = mapper.Map<TDto[], TEntity[]>(dtos);

        context.Set<TEntity>().AddRange(entities);
        context.SaveChanges();

        return dtos;

    }

    public async Task<TDto> AddAsync(TDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var entity = mapper.Map<TDto, TEntity>(dto);

        var result = await context.Set<TEntity>().AddAsync(entity);
        context.SaveChanges();

        return mapper.Map<TEntity, TDto>(result.Entity);
    }


    public TDto Edit(TDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var entity = mapper.Map<TDto, TEntity>(dto);

        var result = context.Set<TEntity>().Update(entity);

        context.SaveChanges();

        return mapper.Map<TEntity, TDto>(result.Entity);
    }

    public TDto[] Edit(TDto[] dtos)
    {
        if (dtos is null)
        {
            throw new ArgumentNullException(nameof(dtos));
        }

        var entities = mapper.Map<TDto[], TEntity[]>(dtos.ToArray());

        context.Set<TEntity>().UpdateRange(entities);
        context.SaveChanges();

        return dtos;
    }

    public IEnumerable<TDto> Find(Expression<Func<TDto, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TDto> GetAll()
    {
        var entities = context.Set<TEntity>().ToArray();

        return mapper.Map<TEntity[], TDto[]>(entities);
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await context.Set<TEntity>().ToArrayAsync();

        return mapper.Map<TEntity[], TDto[]>(entities);
    }


    public TDto GetById(Guid id)
    {
        var entity = context.Set<TEntity>().Find(id);

        if (entity is null)
        {
            return null;
        }

        return mapper.Map<TEntity, TDto>(entity);
    }

    public virtual IQueryable<TAny> GetQueryable<TAny>() where TAny : class
    {
        return context.Set<TAny>().AsQueryable();
    }

    public void Remove(TDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var entity = mapper.Map<TDto, TEntity>(dto);

        context.Set<TEntity>().Remove(entity);
        context.SaveChanges();
    }

    public void Remove(IEnumerable<TDto> dtos)
    {
        if (dtos is null)
        {
            throw new ArgumentNullException(nameof(dtos));
        }

        var entities = mapper.Map<TDto[], TEntity[]>(dtos.ToArray());

        context.Set<TEntity>().RemoveRange(entities);
        context.SaveChanges();
    }
}
