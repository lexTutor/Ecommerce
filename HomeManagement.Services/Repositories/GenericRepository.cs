using HomeManagement.Core.RepositoryAbstractions;
using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _ctx;
        private readonly DbSet<TEntity> _entity;
        public GenericRepository(DataContext ctx)
        {
            _ctx = ctx;
            _entity = ctx.Set<TEntity>();
        }
        public async Task<bool> Add(TEntity model)
        {
            _entity.Add(model);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(object Id)
        {
            var entity = await GetById(Id);
            _entity.Remove(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<TEntity> GetById(object Id)
        {
            return await _entity.FindAsync(Id);
        }

        public async Task<bool> Modify(TEntity entity)
        {
            _entity.Update(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
