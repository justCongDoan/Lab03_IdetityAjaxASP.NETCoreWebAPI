using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}