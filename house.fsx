type House = { Address : string; Price : decimal }

module House =
    let private random = System.Random(Seed = 1)
    /// Make an array of 'count' random houses.
    let getRandom count =
        Array.init count (fun i ->
            { 
                Address = sprintf "%i Stochastic Street" (i+1)
                Price = random.Next(50_000, 500_000) |> decimal })

module Distance =

    let private random = System.Random(Seed = 1)
    /// Try to get the distance to the nearest school.
    /// (Results are simulated)

    let tryToSchool (house : House) =
        // Because we simulate results, the house
        // parameter isn’t actually used.
        let dist = random.Next(10) |> double
        if dist < 5. then Some dist
        else None

type PriceBand = | Cheap | Medium | Expensive

module PriceBand =
    // Return a price band based on price.
    let fromPrice (price : decimal) =
        if price < 100_000m then Cheap
        elif price < 200_000m then Medium
        else Expensive


let housePrices = House.getRandom 20


