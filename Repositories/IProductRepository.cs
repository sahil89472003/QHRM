using System.Collections.Generic;
using System.Threading.Tasks;
using QHRM_Assignment.Models;

public interface IProductRepository
{
    Task<IEnumerable<Products>> GetAllProductsAsync();
    Task<Products> GetProductByIdAsync(int id);
    Task AddProductAsync(Products product);
    Task UpdateProductAsync(Products product);
    Task DeleteProductAsync(int id);
}
