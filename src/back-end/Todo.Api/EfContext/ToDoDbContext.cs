using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Todo.Api.Entities;
using Todo.Api.Entities.Base;

namespace Todo.Api.EfContext;

public class ToDoDbContext : DbContext
{
    public DbSet<Application> Applications { get; set; }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options) { }

    Expression<Func<ISoftDelete, bool>> filterExpression = fl => !fl.IsDeleted;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var softDeletableEntities = modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.IsAssignableTo(typeof(ISoftDelete)));
        foreach (var softDeleteEntity in softDeletableEntities)
        {
            var parameter = Expression.Parameter(softDeleteEntity.ClrType);
            var body = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.First(), parameter, filterExpression.Body);
            var lambdaExpression = Expression.Lambda(body, parameter);
            softDeleteEntity.SetQueryFilter(lambdaExpression);
        }
    }
}
