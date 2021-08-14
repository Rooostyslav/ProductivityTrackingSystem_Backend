using Microsoft.EntityFrameworkCore;
using PTS.DAL.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTS.DAL.Repositories.Common
{
	public class Repository<TEntity> where TEntity : class
	{
		private readonly TrackingSystemContext _context;

		public Repository(TrackingSystemContext trackingSystemContext)
		{
			_context = trackingSystemContext;
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await _context.FindAsync<TEntity>(id);
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			var entityEntry = await _context.AddAsync(entity);
			return entityEntry.Entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity updatedEntity)
		{
			var resultEntity = _context.Update(updatedEntity).Entity;
			await Task.CompletedTask;
			return resultEntity;
		}

		public virtual async Task<TEntity> DeleteAsync(TEntity entity)
		{
			await Task.CompletedTask;
			return _context.Remove(entity).Entity;
		}
	}
}
