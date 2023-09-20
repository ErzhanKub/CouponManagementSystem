using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coupons.Queries
{
    public record GetAllCouponResponse
    {
        public Guid Id { get; init; }
    }
    public record GetAllCouponQuery : IRequest<IEnumerable<GetAllCouponResponse>> { }

    internal class GetHandler : IRequestHandler<GetAllCouponQuery, IEnumerable<GetAllCouponResponse>>
    {
        private readonly ICouponRepository _couponRepository;

        public GetHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<IEnumerable<GetAllCouponResponse>> Handle(GetAllCouponQuery request, CancellationToken cancellationToken)
        {
            List<Coupon> coupons = await _couponRepository.GetAllAsync();
            var response = new List<GetAllCouponResponse>();

            foreach (var coupon in coupons)
            {
                var result = new GetAllCouponResponse
                {
                    Id= coupon.Id,
                };
                response.Add(result);
            }
            return response;
        }
    }
}
