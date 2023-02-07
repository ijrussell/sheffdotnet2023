open System

type CustomerId = CustomerId of Guid

type ValidationError =
    | InputOutOfRange of string

type Spend = private Spend of decimal

[<RequireQualifiedAccess>]
module Spend =
    let value input = input |> fun (Spend value) -> value
    
    let create input =
        if input >= 0.0M && input <= 1000.0M then
            Ok (Spend input)
        else
            Error (InputOutOfRange "You can only spend between 0 and 1000")


let s1 = Spend.create -1000.0M
let s2 = Spend.create 500.0M






