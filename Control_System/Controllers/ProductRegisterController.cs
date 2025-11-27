using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Control_System.Data;
using Control_System.Models;

namespace Control_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRegisterController : ControllerBase
    {
        private readonly ProductRegisterData _productRegisterData;

        public ProductRegisterController(ProductRegisterData productRegisterData)
        {
            _productRegisterData = productRegisterData;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<ProductRegister> List = new List<ProductRegister>();

            List = await _productRegisterData.ListProductsRegisters();

            var resultStatus = StatusCode(StatusCodes.Status200OK, List);

            return resultStatus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ProductRegister objectP = new ProductRegister();

            objectP = await _productRegisterData.GetProductRegister(id);

            var resultStatus = StatusCode(StatusCodes.Status200OK, objectP);

            return resultStatus;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRegister objectP)
        {
            bool response = await _productRegisterData.Create(objectP);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = response });

            return resultStatus;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductRegister objectP)
        {
            bool response = await _productRegisterData.Update(objectP);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = response });

            return resultStatus;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _productRegisterData.Delete(id);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = response });

            return resultStatus;
        }
    }
}
