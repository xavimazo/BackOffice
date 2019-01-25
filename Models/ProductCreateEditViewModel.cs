using Data.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Models
{
    public class ProductCreateEditViewModel
    {
        public Product Product;
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