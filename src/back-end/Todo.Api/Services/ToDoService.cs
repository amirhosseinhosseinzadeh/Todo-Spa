using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Dtos;
using Todo.Api.Dtos.Customqueires;
using Todo.Api.EfContext;
using Todo.Api.Entities;

namespace Todo.Api.Services;

public class ToDoService : IToDoService
{
    private readonly IMapper _mapper;
    private readonly DbSet<Application> _applicationDbSet;
    private readonly ToDoDbContext _dbContext;

    public ToDoService(IMapper mapper,
                       IServiceProvider srv,
                       ToDoDbContext dbContext
        )
    {
        //using var dbContext = srv.GetService<ToDoDbContext>();
        _mapper = mapper;
        _dbContext = dbContext;
        _applicationDbSet = dbContext.Set<Application>();
    }

    public async Task<ApplicationDto> Create(ApplicationDto applicationDto)
    {
        System.Console.WriteLine("sss");
        var application = await _applicationDbSet.AddAsync(
            _mapper.Map<ApplicationDto, Application>(applicationDto)
        );
        await SaveChanges();
        return _mapper.Map<Application, ApplicationDto>(application.Entity);
    }

    public async Task<ApplicationDto> GetById(int applicationId)
    {
        var application = await _applicationDbSet.FindAsync(applicationId)
            ?? throw new Exception("Item not found");
        return _mapper.Map<Application, ApplicationDto>(application);
    }

    public async Task<List<ApplicationDto>> GetList(BaseCustomQuery input)
    {
        var query = _applicationDbSet.AsQueryable();
        var queryResult = await query.Skip(input.Skip)
        .Take(input.Size)
        .ToListAsync();
        return _mapper.Map<List<Application>, List<ApplicationDto>>(queryResult);
    }

    public async Task ToggleApplicationStatus(int applicationId)
    {
        var application = await _applicationDbSet.FindAsync(applicationId)
            ?? throw new Exception("Item not found");
        application.IsActive = !application.IsActive;
        await SaveChanges();
    }

    async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}