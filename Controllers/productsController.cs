using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : Controller
    {
        private readonly iProductServices _productServices;

        public productsController(iProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductAsync()
        {
            var products = await _productServices.GetProductAsync();

            if (products == null || !products.Any()) return NotFound();

            return Ok(products);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(Guid id)
        {
            var products = await _productServices.GetProductByIdAsync(id);

            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Product>> CreateProductAsync(Product product)
        {
            try
            {
                var newProduct = await _productServices.CreateProductAsync(product);
                if (newProduct == null) return NotFound();
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", product.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Product>> EditProductAsync(Product product)
        {
            try
            {
                var editedProduct = await _productServices.EditProductAsync(product);
                if (editedProduct == null) return NotFound();
                return Ok(editedProduct);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", product.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Product>> DeleteProductAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedProduct = await _productServices.DeleteProductAsync(id);
            if (deletedProduct == null) return NotFound();
            return Ok(deletedProduct);
        }
    }
}
