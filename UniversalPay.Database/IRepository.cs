//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalPay.Domain;

namespace UniversalPay.Database
{
    public interface IRepository<TEntity, TKey>
        where TEntity : EntityBase
        where TKey : struct
    {
        public DbContext Context { get; }
        public UniversalPayContext UniversalPayContext { get; }
        public DbSet<TEntity> Model { get; }
        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity FindById(TKey id);
        public ValueTask<TEntity> FindByIdAsync(TEntity entity);
        public ValueTask<IList<TEntity>> GetAllAsync();
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> Find(Func<TEntity, bool> query);
        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
        public void SaveChanges() => Context.SaveChanges();
    }
}
