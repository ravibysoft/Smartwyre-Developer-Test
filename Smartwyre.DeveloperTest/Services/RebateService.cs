using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var result = new CalculateRebateResult();

        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();

        var rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = productDataStore.GetProduct(request.ProductIdentifier);

        if (rebate == null || product == null)
        {
            result.Success = false;
            return result;
        }

        decimal rebateAmount = 0m;

        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount <= 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount = rebate.Amount;
                    result.Success = true;
                }
                break;

            case IncentiveType.FixedRateRebate:
                if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate)
                    || rebate.Percentage <= 0
                    || product.Price <= 0
                    || request.Volume <= 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount = product.Price * rebate.Percentage * request.Volume;
                    result.Success = true;
                }
                break;

            case IncentiveType.AmountPerUom:
                if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
                    || rebate.Amount <= 0
                    || request.Volume <= 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount = rebate.Amount * request.Volume;
                    result.Success = true;
                }
                break;

            default:
                result.Success = false;
                break;
        }

        if (result.Success)
        {
            rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }
}
