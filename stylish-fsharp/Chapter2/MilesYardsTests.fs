module ``MilesYards Tests``

open Models
open Xunit
open FsUnit.Xunit
open System

[<Fact>]
let ``Creating 1,5 miles from 1,0880 notation`` () =
    1.0880
    |> MilesYards.fromMilesPointYards
    |> MilesYards.toDecimalMiles
    |> should equal 1.5

[<Fact>]
let ``Require fraction portion to be less than 1760`` () =
    (fun () -> 1.1760 |> MilesYards.fromMilesPointYards |> ignore)
    |> should throw typeof<ArgumentException>

[<Fact>]
let ``Require positive number`` () =
    (fun () ->
        -1.0880
        |> MilesYards.fromMilesPointYards
        |> ignore)
    |> should throw typeof<ArgumentException>
