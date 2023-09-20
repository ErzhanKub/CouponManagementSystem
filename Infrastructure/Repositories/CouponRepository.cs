using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _appDbContext;

        public CouponRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task CreateAsync(Coupon entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<Coupon>> GetAllAsync()
        {
           return _appDbContext.CoffeCoupon.AsNoTracking().ToListAsync();
        }

        public void Update(Coupon entity)
        {
            throw new NotImplementedException();
        }
    }
}
