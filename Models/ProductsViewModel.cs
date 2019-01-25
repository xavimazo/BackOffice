using Data.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products;
        public IEnumerable<ShortDescription> ShortDescriptions;
        public IEnumerable<FullDescription> FullDescriptions;
        public IEnumerable<Observation> Observations;
        public IEnumerable<Recommendation> Recommendations;
        public IEnumerable<Capacity> Capacities;
        public IEnumerable<Category> Categories;
        public IEnumerable<Color> Colors;
        public IEnumerable<Line> Lines;
        public IEnumerable<Origin> Origins;
        public IEnumerable<Part> Parts;
    }
}