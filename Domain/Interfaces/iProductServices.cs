using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iProductServices
    {
        Task<IEnumerable<Product>> GetProductAsync(); // firma de un metodo

        Task<Product> CreateProductAsync(Product product);

        Task<Product> GetProductByIdAsync(Guid id);

        Task<Product> EditProductAsync(Product product);

        Task<Product> DeleteProductAsync(Guid id);
    }
}
