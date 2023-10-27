using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Product FindProduct(int proId)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Products.SingleOrDefault(p => p.CategoryId == proId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Products.Remove(context.Products.SingleOrDefault(p => p.ProductId == product.ProductId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}