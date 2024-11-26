using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    {

        if (!EntityIsSoftDelete(entity, out ISoftDelete softDeleteEntity))
            return base.Remove(entity);

        softDeleteEntity.IsDeleted = true;
        return Update((TEntity)softDeleteEntity);
    }

    public override EntityEntry Remove(object entity)
    {

        if (!EntityIsSoftDelete(entity, out var softDelete))
            return base.Remove(entity);

        softDelete.IsDeleted = true;
        return Update(softDelete);
    }

    public override void RemoveRange(IEnumerable<object> entities)
    {
        foreach (var item in entities)
        {
            Remove(item);
        }
    }

    public override void RemoveRange(params object[] entities)
    {
        foreach (var item in entities)
        {
            Remove(item);
        }
    }

    private bool EntityIsSoftDelete<TEntity>(TEntity entity, out ISoftDelete softDeleteEntity)
    {
        if (entity is ISoftDelete softDelete)
        {
            softDeleteEntity = softDelete;
            return true;
        }
        softDeleteEntity = null;
        return false;
    }
}
