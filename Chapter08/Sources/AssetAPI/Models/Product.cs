using System;

namespace AssetAPI.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public Uri AssetURL { get; set; }
        public string Price { get; set; }
        public string AssetName { get; set; }
    }
}