(*
Feature: Applying a discount

Scenario: Eligible Registered Customers get 10% discount 
when they spend £100 or more

Given the following Registered Customers
|Customer Id|Email        |Is Eligible|
|John       |john@test.org|true       |
|Mary       |mary@test.org|true       |
|Richard    |             |false      |

When <Customer Id> spends <Spend>
Then their order total will be <Total>

Examples:
|Customer Id| Spend | Total |
|Mary       |  99.00|  99.00|
|John       | 100.00|  90.00|
|Richard    | 100.00| 100.00|
|Sarah      | 100.00| 100.00|

Eligible customers must have an email. Optional for Registered. No email needed for Guests.
*)

// Record type (AND)
type Customer = {
    Name:string
    Email:Option<string> // or option
    IsEligible:bool
    IsRegistered:bool
}

// type EligibleRegisteredCustomer = {
//     Name:string
//     Email:string
// }

// type RegisteredCustomer = {
//     Name:string
//     Email:string option
// }

// type UnregisteredCustomer = {
//     Name:string
// }

// type Customer =
//     | Eligible of EligibleRegisteredCustomer
//     | Registered of RegisteredCustomer
//     | Guest of UnregisteredCustomer

// let john = Eligible { Name = "John"; Email = "john@test.org" }
// let mary = Eligible { Name = "Mary"; Email = "mary@test.org" }
// let richard = Registered { Name = "Richard"; Email = None }
// let sarah = Guest { Name = "Sarah" }

// let calculateOrderTotal customer spend =
//     let discount = 
//         match customer with
//         | Eligible _ when spend >= 100M -> spend * 0.1M
//         | _ -> 0M
//     spend - discount

// let assertJohn = calculateOrderTotal john 100.0M = 90.0M
// let assertMary = calculateOrderTotal mary 99.0M = 99.0M
// let assertRichard = calculateOrderTotal richard 100.0M = 100.0M
// let assertSarah = calculateOrderTotal sarah 100.0M = 100.0M
