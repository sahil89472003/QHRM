using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using QHRM_Assignment.Models;


namespace QHRM_Assignment.Repositories
{
    public class ProductRepository: IProductRepository
    {
        
            private readonly IDbConnection _dbConnection;

            public ProductRepository(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<IEnumerable<Products>> GetAllProductsAsync()
            {
                var query = "SELECT * FROM Products";
                return await _dbConnection.QueryAsync<Products>(query);
            }

            public async Task<Products> GetProductByIdAsync(int id)
            {
                var query = "SELECT * FROM Products WHERE id = @Id";
                return await _dbConnection.QueryFirstOrDefaultAsync<Products>(query, new { Id = id });
            }

        public async Task AddProductAsync(Products product)
        {
            var query = "INSERT INTO Products (ProdName, Description, CreatedAt) VALUES (@ProdName, @Description, GETDATE())";
            await _dbConnection.ExecuteAsync(query, product);
        }

        public async Task UpdateProductAsync(Products product)
        {
            var query = "UPDATE Products SET ProdName = @ProdName, Description = @Description WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, product);
        }


        public async Task DeleteProductAsync(int id)
            {
                var query = "DELETE FROM Products WHERE id = @Id";
                await _dbConnection.ExecuteAsync(query, new { Id = id });
            }
    }
}
