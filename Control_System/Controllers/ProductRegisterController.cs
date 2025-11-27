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
            List<ProductRegister> Lista = await _productRegisterData.ListProductsRegisters();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            ProductRegister objeto = await _productRegisterData.GetProductRegister(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductRegister objeto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            bool respuesta = await _productRegisterData.Create(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] ProductRegister objeto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            bool respuesta = await _productRegisterData.Update(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _productRegisterData.Delete(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}
