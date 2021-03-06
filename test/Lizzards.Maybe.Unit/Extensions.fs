module Lizzards.Tests.Maybe.Extensions

open System
open Lizzards.Maybe
open Lizzards.Tests
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``None Extension Returns Maybe Nothing`` () =
    let  maybe: Maybe<string> = Maybe.None<string>();
    maybe.IsNone |> should be True

[<Fact>]
let ``From Extension Restuns Maybe`` () =
    let maybe: Maybe<string> = Maybe.From<string>("example");
    maybe.IsSome |> should be True