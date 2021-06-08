using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalPay.Domain;

namespace UniversalPay.Database
{
    public class Repository<TEntity, TKey> : IDisposable, IRepository<TEntity, TKey>
        where TEntity : EntityBase, new()
        where TKey : struct
    {
        private readonly UniversalPayContext _ctx;

        public Repository(UniversalPayContext ctx)
        {
            _ctx = ctx;
        }

        public DbContext Context
        {
            get { return this._ctx; }
        }

        public UniversalPayContext UniversalPayContext
        {
            get { return this._ctx; }
        }

        public DbSet<TEntity> Model
        {
            get { return _ctx.Set<TEntity>(); }
        }

        public void Insert(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await _ctx.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
            return result.Entity;
        }

        public void Update(TEntity entity)
        {
            _ctx.Update(entity);
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _ctx.Remove(entity);
            SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>();
        }

        public async ValueTask<IList<TEntity>> GetAllAsync()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> queryLambda)
        {
            return GetAll()
            .Where(queryLambda)
                .AsQueryable();
        }

        public TEntity GetById(TKey id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async ValueTask<TEntity> FindByIdAsync(TEntity entity)
        {
            return await _ctx.Set<TEntity>().FindAsync(entity.Id);
        }

        public async Task SaveChangesAsync()
        {

            await _ctx.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        
    }
}

