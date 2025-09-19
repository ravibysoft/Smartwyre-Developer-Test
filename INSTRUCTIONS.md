 Smartwyre Developer Test – Instructions

 1. Design Choices

 a. Human-Coded, Readable Style

 The solution was written in a straightforward style, avoiding over-engineered patterns like factories or dependency injection frameworks.
 All logic is easy to follow and maintain, similar to how a developer would hand-write code.

 b. Separation of Concerns

 Data Stores (ProductDataStore, RebateDataStore) handle retrieving and storing products and rebates.
 RebateService handles all rebate calculation logic.
 Console App handles user input/output.

 c. Incentive Type Handling

 Each incentive type (FixedCashAmount, FixedRateRebate, AmountPerUom) is handled explicitly in a switch statement in RebateService.
 Validation for product support, zero amounts, and invalid input is performed inside each case.
 Easy to extend: adding a new incentive type only requires adding another case.

 d. Testability

 The code uses in-memory sample data in ProductDataStore and RebateDataStore, making it easy to test without a database.
 Unit tests are human-readable and cover all scenarios: valid rebates, invalid inputs, unsupported incentives, and unknown identifiers.

 2. How the Solution Works

 Step 1: User Input

 The console app prompts the user for:

   Product Identifier
   Rebate Identifier
   Volume

 Step 2: Load Data

 RebateService retrieves the product and rebate from the in-memory data stores.

 Step 3: Validate Input

 Checks if the product or rebate is null.
 Checks if the product supports the incentive type.
 Checks if the rebate amount/percentage and volume are valid (> 0).

 Step 4: Calculate Rebate

 Depending on the incentive type:

  1. FixedCashAmount → rebate amount = fixed value.
  2. FixedRateRebate → rebate amount = product price × rebate percentage × volume.
  3. AmountPerUom → rebate amount = rebate amount × volume.

 Step 5: Store Result

 If the calculation is valid, the result is stored in the RebateDataStore and printed to the console.

 Step 6: Return Result

 Returns CalculateRebateResult with Success = true if calculated, false otherwise.

 3. Running the Console App

1. Build and run the project.
2. Enter sample inputs. Example:

| Product Identifier | Rebate Identifier | Volume |
| ------------------ | ----------------- | ------ |
| Product1           | Rebate1           | 1      |
| Product2           | RebateRate        | 2      |
| Product3           | RebatePerUom      | 3      |

3. Expected outputs:


Rebate stored: Rebate1, Amount: 10
Rebate calculated successfully!



Rebate stored: RebateRate, Amount: 40
Rebate calculated successfully!



Rebate stored: RebatePerUom, Amount: 15
Rebate calculated successfully!


 If an invalid product or rebate is entered:


Failed to calculate rebate.


 4. Unit Tests

 Located in Smartwyre.DeveloperTest.Tests.
 Covers:

   Valid rebates for each incentive type.
   Invalid product or rebate identifiers.
   Zero amounts or volume.
   Unsupported incentive types.
 Written in a human-readable, simple style for easy understanding and maintenance.

 5. Extending the Solution

 Add a new incentive type:

  1. Add a new value to IncentiveType enum.
  2. Add a case in the RebateService.Calculate() method.
  3. Add corresponding validation and calculation logic.
  4. Update unit tests to cover the new type.
