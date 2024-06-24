using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Domain.Repositories;
using EGStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EGStore.Infrastructure.Repositories
{
    public class Repo<T> : IRepo<T> where T : class, new()
    {
        private readonly EGStoreContext _context;
        DbSet<T> _dbSet;

        //khởi tạo phương thức cho Repo
        public Repo(EGStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList(); //tập thực thể chuyển sang ToList
        }

        public T Get(Guid id)
        {
            return _dbSet.Find(id);
        }
        public bool Add(T entity)
        {
            bool flag = false;
            if (!_dbSet.Any(e => e == entity))
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            return flag;
        }

        public bool Update(T entity)
        {
            bool flag = true;
            if (!_dbSet.Any(e => e == entity))
            {
                flag = false;
            }
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return flag;
        }
        public bool Delete(Guid id)
        {
            bool flag = true;
            var entity = _dbSet.Find(id);//tìm id sau đó nếu thực thế đó = null (tức là ko có ==> flag = false) còn lại thì sẽ xóa và lưu thay đổi
            if (entity == null)
            {
                flag = false;
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return flag;

        }
    }
}
