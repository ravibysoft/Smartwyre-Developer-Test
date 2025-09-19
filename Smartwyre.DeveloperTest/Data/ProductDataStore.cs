using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data
{
    public class ProductDataStore
    {
        private readonly List<Product> _products;

        public ProductDataStore()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Identifier = "Product1",
                    Price = 100m,
                    Uom = "Each",
                    SupportedIncentives = SupportedIncentiveType.FixedCashAmount | SupportedIncentiveType.FixedRateRebate
                },
                new Product
                {
                    Id = 2,
                    Identifier = "Product2",
                    Price = 200m,
                    Uom = "Each",
                    SupportedIncentives = SupportedIncentiveType.FixedRateRebate
                },
                new Product
                {
                    Id = 3,
                    Identifier = "Product3",
                    Price = 50m,
                    Uom = "Each",
                    SupportedIncentives = SupportedIncentiveType.AmountPerUom
                }
            };
        }

        public Product GetProduct(string productIdentifier)
        {
            return _products.FirstOrDefault(p => p.Identifier == productIdentifier);
        }
    }
}
