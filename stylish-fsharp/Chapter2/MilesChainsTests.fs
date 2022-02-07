module ``MilesChains Tests``

open Models
open Xunit
open FsUnit.Xunit
open System

[<Fact>]
let ``Creating 1,5 miles from 1 mile and 40 chains`` () =
    MilesChains.fromMilesAndChains (1, 40)
    |> MilesChains.toDecimalMiles
    |> should equal 1.5

[<Fact>]
let ``Chains should be less than 80`` () =
    (fun () -> MilesChains.fromMilesAndChains (1, 88) |> ignore)
    |> should throw typeof<ArgumentException>

[<Fact>]
let ``Accept positive numbers only`` () =
    (fun () -> MilesChains.fromMilesAndChains (-1, 40) |> ignore)
    |> should throw typeof<ArgumentException>

    (fun () -> MilesChains.fromMilesAndChains (1, -40) |> ignore)
    |> should throw typeof<ArgumentException>
