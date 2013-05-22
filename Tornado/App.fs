
namespace Tornado

open Nancy
open FSharp.Data

type TornadoInstance = {
    NumberInYear : string
    Year : string
    Month : string
    Day : string
    Date : string
    Time : string
    TimeZone : string
    State : string
    FIPS : string
    StateNumberInYear : string
    FScale : string
    Injuries : string
    Fatalities : string
    PropertyLoss : string
    CropLoss : string
    StartingLat : string
    StartingLon : string
    EndingLat : string
    EndingLon : string
    LengthInMiles : string
    (* WidthInYards : string
    NumStatesAffected : string
    IncludeStateNum : string
    TornadoSegmentNum : string
    CountyFIPS_1 : string
    CountyFIPS_2 : string
    CountyFIPS_3 : string
    CountyFIPS_4 : string
    StateName : string
    CountyName : string
    FIPSState : string
    FIPSCounty : string *)
}

module Data =

    let readTornados fileName = 
        System.IO.File.ReadLines fileName
        |> Seq.map (fun line -> line.Split(','))
        |> Seq.map (fun line -> { NumberInYear = line.[0]; Year = line.[1]; Month = line.[2]; Day = line.[3]; Date = line.[4]; Time = line.[5]; 
            TimeZone = line.[6]; State = line.[7]; FIPS = line.[8]; StateNumberInYear = line.[9]; FScale = line.[10]; Injuries = line.[11]; Fatalities = line.[12]; 
            PropertyLoss = line.[13]; CropLoss = line.[14]; StartingLat = line.[15]; StartingLon = line.[16]; EndingLat = line.[17]; EndingLon = line.[18]; 
            LengthInMiles = line.[7] }
        )
        |> Array.ofSeq
        
    let tornados = lazy readTornados "tornado-data.csv"

type IndexModule() as x =
    inherit NancyModule ()
    
    do
        x.Get.["/"] <- fun _ -> 
            let data = Data.tornados.Value
            data |> x.Response.AsJson :> obj
            
            
            
            