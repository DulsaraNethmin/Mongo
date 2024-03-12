using AutoMapper;
using Mongo.Services.CouponAPI.Dto;
using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<CouponDto, Coupon>().ReverseMap();
        }
    }
}
