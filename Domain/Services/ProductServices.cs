using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class ProductServices : iProductServices
    {
        private readonly DataBaseContext _context;

        public ProductServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                product.Id = Guid.NewGuid();
                product.CreatedDate = DateTime.Now;
                _context.Products.Add(product); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el Product en la tabla
                return product;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Product> DeleteProductAsync(Guid id)
        {

            try
            {
                var product = await GetProductByIdAsync(id);

                if (product == null)
                {
                    return null;
                }

                _context.Products.Remove(product); // Creacion del query "Delete from Product"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return product;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Product> EditProductAsync(Product product)
        {
            try
            {
                product.ModifiedDate = DateTime.Now;
                _context.Products.Update(product);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {

            try
            {
                var products = await _context.Products.ToListAsync();

                return products;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {

            try
            {
                var products = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                return products;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

