module Models

let private (~~) x = float x

type MilesYards = MilesYards of wholeMiles: int * yards: int

module MilesYards =
    let fromMilesPointYards (milesPointYards: float) : MilesYards =
        let wholeMiles = milesPointYards |> floor |> int
        let fraction = milesPointYards - ~~wholeMiles

        if wholeMiles < 0 then
            invalidArg (nameof milesPointYards) "Miles should be more than 0"

        if fraction > 0.1759 || fraction < 0. then
            invalidArg
                (nameof milesPointYards)
                "Fractional part must be more than 0 and less than 1760"

        let yards = fraction * 10_000. |> round |> int
        MilesYards(wholeMiles, yards)

    let toDecimalMiles (MilesYards (wholeMiles, yards)) : float =
        ~~wholeMiles + (~~yards / 1760.)

module MilesChains =
    type MilesChains = private MilesChains of wholeMiles: int * chains: int

    let fromMilesAndChains (wholeMiles: int, chains: int) : MilesChains =
        if wholeMiles < 0 then
            invalidArg (nameof wholeMiles) "Miles should be more than 0"

        if chains < 0 || chains >= 80 then
            invalidArg (nameof chains) "Chains should be more than 0 and less than 80"

        MilesChains(wholeMiles, chains)

    let toDecimalMiles (MilesChains (wholeMiles, chains)) : float =
        ~~wholeMiles + (~~chains / 80.)
