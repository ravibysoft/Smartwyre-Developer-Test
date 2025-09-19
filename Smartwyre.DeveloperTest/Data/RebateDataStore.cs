using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data
{
    public class RebateDataStore
    {
        private readonly List<Rebate> _rebates;
        private readonly List<RebateCalculation> _calculatedResults;

        public RebateDataStore()
        {
            _rebates = new List<Rebate>
            {
                new Rebate
                {
                    Identifier = "Rebate1",
                    Incentive = IncentiveType.FixedCashAmount,
                    Amount = 10m,
                    Percentage = 0
                },
                new Rebate
                {
                    Identifier = "RebateRate",
                    Incentive = IncentiveType.FixedRateRebate,
                    Amount = 0,
                    Percentage = 0.1m // 10%
                },
                new Rebate
                {
                    Identifier = "RebatePerUom",
                    Incentive = IncentiveType.AmountPerUom,
                    Amount = 5m,
                    Percentage = 0
                }
            };

            _calculatedResults = new List<RebateCalculation>();
        }

        public Rebate GetRebate(string rebateIdentifier)
        {
            return _rebates.FirstOrDefault(r => r.Identifier == rebateIdentifier);
        }

        public void StoreCalculationResult(Rebate rebate, decimal rebateAmount)
        {
            _calculatedResults.Add(new RebateCalculation
            {
                Id = _calculatedResults.Count + 1,
                Identifier = Guid.NewGuid().ToString(),
                RebateIdentifier = rebate.Identifier,
                IncentiveType = rebate.Incentive,
                Amount = rebateAmount
            });

            Console.WriteLine($"Rebate stored: {rebate.Identifier}, Amount: {rebateAmount}");
        }
    }
}
