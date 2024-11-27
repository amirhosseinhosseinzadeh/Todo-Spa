using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Entities;

namespace Todo.Api.Services;

public class ToDoService : IToDoService
{
    private readonly IMapper _mapper;
    private readonly DbSet<Application> _applicationDbSet;
    private readonly ToDoDbContext _dbContext;

    public ToDoService(IMapper mapper,
                       ToDoDbContext dbContext
        )
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _applicationDbSet = dbContext.Set<Application>();
    }

    public async Task<ApplicationDto> Create(ApplicationDto applicationDto, CancellationToken cancellationToken = default)
    {
        var application = await _applicationDbSet.AddAsync(
            _mapper.Map<ApplicationDto, Application>(applicationDto),
            cancellationToken
        );
        await SaveChangesAsync(cancellationToken);
        return _mapper.Map<Application, ApplicationDto>(application.Entity);
    }

    public async Task<ApplicationDto> GetById(int applicationId, CancellationToken cancellationToken = default)
    {
        var application = await _applicationDbSet.FindAsync(applicationId, cancellationToken);
        EntityNotFoundException.ThrowIfNull(application);
        return _mapper.Map<Application, ApplicationDto>(application);
    }

    public async Task<List<ApplicationDto>> GetList(BaseCustomQuery input, CancellationToken cancellationToken = default)
    {
        var query = _applicationDbSet.AsQueryable();
        var queryResult = await query.Skip(input.Skip)
        .Take(input.Size)
        .ToListAsync(cancellationToken);
        return _mapper.Map<List<Application>, List<ApplicationDto>>(queryResult);
    }

    public async Task ToggleApplicationStatus(int applicationId, CancellationToken cancellationToken = default)
    {
        var application = await _applicationDbSet.FindAsync(applicationId);
        EntityNotFoundException.ThrowIfNull(application);
        application.IsActive = !application.IsActive;
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteById(int applicationId, CancellationToken cancellationToken = default)
    {
        var todoApplication = await _applicationDbSet.FindAsync(applicationId);
        EntityNotFoundException.ThrowIfNull(todoApplication);
        _dbContext.Remove(todoApplication);
        await SaveChangesAsync(cancellationToken);
    }


    async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task<ApplicationDto> Update(ApplicationDto applicationDto, CancellationToken cancellationToken)
    {
        var todoApplication = await _applicationDbSet.FindAsync(applicationDto.Id);
        EntityNotFoundException.ThrowIfNull(todoApplication);
        var entity = _mapper.Map<ApplicationDto, Application>(applicationDto, todoApplication);
        entity = _applicationDbSet.Update(entity).Entity;
        await SaveChangesAsync(cancellationToken);
        return _mapper.Map<Application, ApplicationDto>(entity);
    }
}
