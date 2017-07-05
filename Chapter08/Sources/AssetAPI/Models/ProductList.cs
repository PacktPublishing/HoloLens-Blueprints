using System.Collections.Generic;

namespace AssetAPI.Models
{
    /// <summary>
    /// Product Lists
    /// </summary>
    public class ProductList
    {
        public string Id { get; set; }
        public List<Product> Products { get; set; }
    }

   
}