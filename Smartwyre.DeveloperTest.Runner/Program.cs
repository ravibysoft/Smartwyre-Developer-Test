using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main()
    {
        var rebateService = new RebateService();

        Console.WriteLine("Enter Product Identifier:");
        string productId = Console.ReadLine();

        Console.WriteLine("Enter Rebate Identifier:");
        string rebateId = Console.ReadLine();

        Console.WriteLine("Enter Volume:");
        decimal volume = decimal.Parse(Console.ReadLine() ?? "0");

        var request = new CalculateRebateRequest
        {
            ProductIdentifier = productId,
            RebateIdentifier = rebateId,
            Volume = volume
        };

        var result = rebateService.Calculate(request);

        if (result.Success)
        {
            Console.WriteLine("Rebate calculated successfully!");
        }
        else
        {
            Console.WriteLine("Failed to calculate rebate.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
