﻿namespace PcBackEndAspNetAPI.Models.ProductModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductModel> Products { get; set; }



    }
}