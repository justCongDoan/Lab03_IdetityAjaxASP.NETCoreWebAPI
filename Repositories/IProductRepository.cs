using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);

        Product GetProduct(int id);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        List<Category> GetCategories();

        List<Product> GetProducts();
    }
}