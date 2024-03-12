using Mongo.Services.CouponAPI.Data;
using Mongo.Services.CouponAPI.Interface;
using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _context;

        public CouponRepository(DataContext context)
        {
            this._context = context;
        }
        public bool CreateCoupon(Coupon coupon)
        {
            _context.Add(coupon);
            return Save();
        }

        public Coupon GetCouponByCode(string couponCode)
        {
            var coupon = _context.Coupons.Where(c => c.CouponCode.Trim() == couponCode.Trim()).FirstOrDefault();
            return coupon;
        }

        public Coupon GetCouponById(int couponId)
        {
            return _context.Coupons.Find(couponId);
        }

        public ICollection<Coupon> GetCoupons()
        {
            var coupons = _context.Coupons.ToList();
            return coupons;
        }

        public bool Save()
        {
           return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCoupon(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            return Save();
        }
    }
}
