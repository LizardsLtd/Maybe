module Lizards.Tests.Maybe.Maybe

    open System
    open Lizards.Maybe
    open Xunit
    open FsUnit.Xunit

    [<Fact>]
    let ``Maybe Is Never Null`` () =
       let possibleMaybe: Maybe<string>  = Unchecked.defaultof<Maybe<string>>
       possibleMaybe |> should not' (be Null)

    [<Fact>]
    let ``Null Casted Maybe Is None`` () =
       let maybe: Maybe<string>  = Unchecked.defaultof<Maybe<string>>
       maybe.IsNone |> should be True

    [<Fact>]
    let ``Null Casted Maybe Is Not Some`` () =
       let maybe: Maybe<string>  = Unchecked.defaultof<Maybe<string>>
       maybe.IsSome |> should be False

    [<Fact>]
    let ``Value Casted Maybe Is Not None`` () =
        let maybe: Maybe<string> = Maybe.From("test");
        maybe.IsNone |> should be False;

    [<Fact>]
    let ``Value Casted Maybe Is Some`` () =
        let maybe: Maybe<string> = Maybe.From("test");
        maybe.IsSome |> should be True;

    [<Theory>]
    [<InlineData(5, 3, 1)>]
    [<InlineData(5, 8, -1)>]
    [<InlineData(5, 5, 0)>]
    let ``Comparision Works For Payload`` (initialValue: int, compareToValue: int, result: int) =
        let maybe: Maybe<int> = Maybe.From(initialValue);
        let comparisionValue: int = maybe.CompareTo(compareToValue);
        result |> should equal comparisionValue;

    [<Theory>]
    [<InlineData(5, 3, 1)>]
    [<InlineData(5, 8, -1)>]
    [<InlineData(5, 5, 0)>]
    let ``Comparision Works For Maybes`` (initialValue: int, compareToValue: int, result: int) =
       let maybe = Maybe.From(initialValue);
       let other = Maybe.From(compareToValue);
       let comparisionValue = maybe.CompareTo(other);
       result |> should equal comparisionValue;

    [<Theory>]
    [<InlineData(5, 5, true)>]
    [<InlineData(5, 8, false)>]
    let ``Equality Works For Payload`` (initialValue: int, compareToValue: int, result: bool) =
       let maybe = Maybe.From(initialValue);
       let comparisionValue = maybe.Equals(compareToValue);
       result |> should equal comparisionValue;

    [<Theory>]
    [<InlineData(5, 5, true)>]
    [<InlineData(5, 8, false)>]
    let ``Equality Works For Maybes`` (initialValue: int, compareToValue: int, result: bool) =
       let maybe = Maybe.From(initialValue);
       let comparisionValue = maybe.Equals(compareToValue);
       result |> should equal comparisionValue;