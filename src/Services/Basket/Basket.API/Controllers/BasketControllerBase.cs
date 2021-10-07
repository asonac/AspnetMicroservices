using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class BasketControllerBase
    {
        private readonly IBasketRepository _repository;
    }
}