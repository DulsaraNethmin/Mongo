using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Interface
{
    public interface ICouponRepository
    {
        ICollection<Coupon> GetCoupons();
        Coupon GetCouponByCode(string couponCode);
        Coupon GetCouponById(int couponId);
        bool UpdateCoupon(Coupon coupon);
        bool CreateCoupon(Coupon coupon);
        bool Save();
    }
}
