using Microsoft.EntityFrameworkCore;
using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
