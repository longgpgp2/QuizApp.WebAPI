using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Business.ViewModels.Common;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services.BaseServices;

public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity
{
    protected readonly IUnitOfWork _unitOfWork;

    protected readonly ILogger<BaseService<T>> _logger;

    protected readonly IMapper _mapper;

    public BaseService(IUnitOfWork unitOfWork, ILogger<BaseService<T>> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public virtual int Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Add(entity);
        _logger.LogInformation("{0} with Id-{1} is added", typeof(T), entity.Id);

        return _unitOfWork.SaveChanges();
    }

    public virtual async Task<int> AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Add(entity);
        _logger.LogInformation("{0} with Id-{1} is added", typeof(T), entity.Id);


        return await _unitOfWork.SaveChangesAsync();
    }

    public virtual int AddRange(IEnumerable<T> entities)
    {
        foreach (var item in entities)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _unitOfWork.GenericRepository<T>().Add(item);
            _logger.LogInformation("{0} with Id-{1} is added", typeof(T), item.Id);


        }
        return _unitOfWork.SaveChanges();
    }

    public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities)
    {
        foreach (var item in entities)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _unitOfWork.GenericRepository<T>().Add(item);
            _logger.LogInformation("{0} with Id-{1} is added", typeof(T), item.Id);

        }
        return await _unitOfWork.SaveChangesAsync();
    }

    public virtual bool Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Update(entity);
        _logger.LogInformation("{0} with Id-{1} is updated", typeof(T), entity.Id);

        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Update(entity);
        _logger.LogInformation("{0} with Id-{1} is updated", typeof(T), entity.Id);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual bool Delete(Guid id, bool isHardDelete = false)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        _unitOfWork.GenericRepository<T>().Delete(id, isHardDelete);
        _logger.LogInformation("{0} with Id-{1} is deleted", typeof(T), id);

        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual bool Delete(T entity, bool isHardDelete = false)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Delete(entity, isHardDelete);
        _logger.LogInformation("{0} with Id-{1} is deleted", typeof(T), entity.Id);

        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual async Task<bool> DeleteAsync(Guid id, bool isHardDelete = false)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        _unitOfWork.GenericRepository<T>().Delete(id, isHardDelete);
        _logger.LogInformation("{0} with Id-{1} is deleted", typeof(T), id);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(T entity, bool isHardDelete = false)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Delete(entity, isHardDelete);
        _logger.LogInformation("{0} with Id-{1} is deleted", typeof(T), entity.Id);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual IEnumerable<T> GetAll(bool isIncludeDeleted = false)
    {
        if (!isIncludeDeleted)
        {
            return _unitOfWork.GenericRepository<T>().GetQuery(x => x.IsDeleted == false).ToList();
        }
        _logger.LogInformation("A list of {0} is retrieved", typeof(T));

        return _unitOfWork.GenericRepository<T>().GetQuery().ToList();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(bool isIncludeDeleted = false)
    {
        if (!isIncludeDeleted)
        {
            return await _unitOfWork.GenericRepository<T>().GetQuery(x => x.IsDeleted == false).ToListAsync();
        }
        _logger.LogInformation("A list of {0} is retrieved", typeof(T));

        return await _unitOfWork.GenericRepository<T>().GetQuery().ToListAsync();
    }

    public virtual T? GetById(Guid id)
    {
        _logger.LogInformation("One {0} is retrieved", typeof(T));

        return _unitOfWork.GenericRepository<T>().GetById(id);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("One {0} is retrieved", typeof(T));

        return await _unitOfWork.GenericRepository<T>().GetByIdAsync(id);
    }

    public virtual async Task<PaginatedResult<T>> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "",
        int pageIndex = 1, int pageSize = 10)
    {
        var query = _unitOfWork.GenericRepository<T>().Get(filter, orderBy, includeProperties);
        _logger.LogInformation("Paginated results of {0} are retrieved", typeof(T));

        return await PaginatedResult<T>.CreateAsync(query, pageIndex, pageSize);
    }

    public BaseCommonViewModel<T> ToViewModel(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BaseCommonViewModel<T>> ToViewModels(IEnumerable<T> entities)
    {
        return entities.Select(e=>_mapper.Map<BaseCommonViewModel<T>>(e));
    }
}