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
        public async Task<IActionResult> Lista()
        {
            List<ProductRegister> Lista = new List<ProductRegister>();

            Lista = await _productRegisterData.ListProductsRegisters();

            var resultStatus = StatusCode(StatusCodes.Status200OK, Lista);

            return resultStatus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            ProductRegister objeto = new ProductRegister();

            objeto = await _productRegisterData.GetProductRegister(id);

            var resultStatus = StatusCode(StatusCodes.Status200OK, objeto);

            return resultStatus;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductRegister objeto)
        {
            bool respuesta = await _productRegisterData.Create(objeto);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });

            return resultStatus;
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] ProductRegister objeto)
        {
            bool respuesta = await _productRegisterData.Update(objeto);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });

            return resultStatus;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _productRegisterData.Delete(id);

            var resultStatus = StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });

            return resultStatus;
        }
    }
}
