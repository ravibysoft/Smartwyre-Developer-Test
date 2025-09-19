using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateServiceTests
    {
        private readonly RebateService _rebateService;

        public RebateServiceTests()
        {
            _rebateService = new RebateService();
        }

        [Fact]
        public void FixedCashAmount_Valid_ShouldReturnSuccess()
        {
            var request = new CalculateRebateRequest
            {
                ProductIdentifier = "Product1",
                RebateIdentifier = "Rebate1",
                Volume = 1
            };

            var result = _rebateService.Calculate(request);

            Assert.True(result.Success);
        }

        [Fact]
        public void FixedRateRebate_Valid_ShouldReturnCorrectAmount()
        {
            var request = new CalculateRebateRequest
            {
                ProductIdentifier = "Product2", // price = 100
                RebateIdentifier = "RebateRate", // percentage = 0.1
                Volume = 2
            };

            var result = _rebateService.Calculate(request);

            Assert.True(result.Success);
        }

        [Fact]
        public void AmountPerUom_Valid_ShouldReturnSuccess()
        {
            var request = new CalculateRebateRequest
            {
                ProductIdentifier = "Product3",
                RebateIdentifier = "RebatePerUom",
                Volume = 3
            };

            var result = _rebateService.Calculate(request);

            Assert.True(result.Success);
        }

        [Fact]
        public void InvalidProduct_ShouldReturnFailure()
        {
            var request = new CalculateRebateRequest
            {
                ProductIdentifier = "InvalidProduct",
                RebateIdentifier = "Rebate1",
                Volume = 1
            };

            var result = _rebateService.Calculate(request);

            Assert.False(result.Success);
        }

        [Fact]
        public void InvalidRebate_ShouldReturnFailure()
        {
            var request = new CalculateRebateRequest
            {
                ProductIdentifier = "Product1",
                RebateIdentifier = "InvalidRebate",
                Volume = 1
            };

            var result = _rebateService.Calculate(request);

            Assert.False(result.Success);
        }
    }
}
