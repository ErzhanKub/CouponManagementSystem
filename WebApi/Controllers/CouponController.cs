using Application.Coupons.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CouponController> _logger;

        public CouponController(IMediator mediator, ILogger<CouponController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCouponQuery();
            var coupons = await _mediator.Send(query);
            return Ok(coupons);
        }
    }
}
