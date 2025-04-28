using CarGallery_ef.DAL;
using CarGallery_ef.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarGallery_ef.Services;
internal class GenericService<TEntity> where TEntity : EntityBase
{
    public GenericService(AppDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }

    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _table;

    #region Create
    public void Add(TEntity entity)
    {
        _table.Add(entity);
        SaveChanges();
    }

    public void AddMany(params TEntity[] entities)
    {
        _table.AddRange(entities);
        SaveChanges();
    }
    #endregion

    #region Read
    public TEntity Find(int id)
    {
        return Get().Find(id)!;
    }

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return Get().FirstOrDefault(predicate)!;
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return Get().Where(predicate);
    }

    public DbSet<TEntity> Get()
    {
        return _table;
    }
    #endregion

    #region Update
    public void Update(TEntity entity)
    {
        if (!IsExist(entity.Id))
            return;
        _table.Update(entity);
        SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(TEntity entity)
    {
        if (!IsExist(entity.Id))
            return;
        _table.Remove(entity);
        SaveChanges();
    }

    public void DeleteMany(params TEntity[] entities)
    {
        for (int i = 0; i < entities.Length; i++)
            Delete(entities[i]);
        SaveChanges();
    }
    #endregion

    #region Methods
    public bool IsExist(int id) => _table.Find(id) is not null ? true : false;

    public int SaveChanges() => _context.SaveChanges();
    #endregion
}
