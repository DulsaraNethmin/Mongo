using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mongo.Services.CouponAPI.Dto;
using Mongo.Services.CouponAPI.Interface;
using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public CouponController(ICouponRepository couponRepository, IMapper mapper)
        {
            this._couponRepository = couponRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coupon>))]
        public IActionResult Get()
        {
            var coupons = _mapper.Map<List<Coupon>>( _couponRepository.GetCoupons());


            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(coupons);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateCoupon([FromBody] CouponDto couponToCreate)
        {
            if (couponToCreate == null)
            {
                return BadRequest();
            }

            // TODO: check coupon already exist.

            var coupon = _mapper.Map<Coupon>(couponToCreate);

            if (!_couponRepository.CreateCoupon(coupon))
            {
                ModelState.AddModelError("","Something went wrong.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK )]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCoupon(int id)
        {
            var coupon = _mapper.Map<CouponDto>(_couponRepository.GetCouponById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(coupon);
        }

        [HttpGet("GetByCouponCode/{couponCode}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCoupon(string couponCode)
        {
            var coupon = _mapper.Map<CouponDto>(_couponRepository.GetCouponByCode(couponCode));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(coupon);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCoupon([FromBody] CouponDto coupontoUpdate)
        {
            if (coupontoUpdate == null)
            {
                return BadRequest();
            }

            var coupon = _mapper.Map<Coupon>(coupontoUpdate);

            if (!_couponRepository.UpdateCoupon(coupon))
            {
                ModelState.AddModelError("", "Something went wrong.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Updated");
        }

    }
}
