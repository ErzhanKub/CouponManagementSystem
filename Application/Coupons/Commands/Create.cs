//using Application.Shared;
//using Domain.Entities;
//using Domain.Repositories;
//using MediatR;


//namespace Application.Coupons.Commands
//{
//    public record CreateCouponResponse
//    {
//        public Guid Id { get; init; }
//    }
//    public record CreateCouponCommand : IRequest<CreateCouponResponse> { }

//    internal class CreateCouponHandler : IRequestHandler<CreateCouponCommand, CreateCouponResponse>
//    {
//        private readonly ICouponRepository _couponRepository;
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateCouponHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
//        {
//            _couponRepository = couponRepository;
//            _unitOfWork = unitOfWork;
//        }

//        public Task<CreateCouponResponse> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
//        {
//            var coupon = new Coupon();
//            var response = new CreateCouponResponse
//            {
//                Id = coupon.Id,
//            };
//            return response;
//        }
//    }
//}
