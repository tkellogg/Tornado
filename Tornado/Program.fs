// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

module Tornado.Main

open System
open Nancy.Hosting.Self

(*
Twilio - Give your app a phone number for SMS or voice call
 - request deals in XML, via webhook
 
 GM: Integrate with your car, where it is, onstar, etc. Stacks of money
 
 nexmo: Text messages
 - Ar
*)

[<EntryPoint>]
let main args = 
    let host = new NancyHost(new Uri("http://localhost:4020"))
    host.Start ()
    Console.WriteLine "Press any key to end..."
    Console.ReadKey () |> ignore
    host.Stop ()
    0

