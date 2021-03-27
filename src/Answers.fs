module Answers

// state type
type State =
  { Counter: int }

// msg type
type Msg =
  | Increment

// init
let init initialCounter =
  { Counter = initialCounter }

// update
let update msg state =
  match msg with
  | Increment -> { state with Counter = state.Counter + 1 }

// view
open Feliz

let view (state: State) dispatch =
  Html.div [
    Html.p $"You have {state.Counter} coins 💰"
    Html.button [
      prop.onClick (fun _ -> dispatch Increment)
      prop.text "Generate 🚀"
    ]
  ]

// program
open Elmish
open Elmish.React

Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.runWith 0


// UseElmish

module App

// state type
type State =
  { Counter: int }

// msg type
type Msg =
  | Increment

open Elmish

// init
let init initialCounter =
  { Counter = initialCounter }, Cmd.none

// update
let update msg state =
  match msg with
  | Increment -> { state with Counter = state.Counter + 1 }, Cmd.none

// view
open Feliz
open Feliz.UseElmish

[<ReactComponent>]
let view () =
  let state, dispatch = React.useElmish((fun () -> init 0), update)

  Html.div [
    Html.p $"You have {state.Counter} coins 💰"
    Html.button [
      prop.onClick (fun _ -> dispatch Increment)
      prop.text "Generate 🚀"
    ]
  ]

// program
open Elmish
open Elmish.React

let initRoot () = ()
let updateRoot msg state = ()
let viewRoot state dispatch = view()

Program.mkSimple initRoot updateRoot viewRoot
|> Program.withReactSynchronous "elmish-app"
|> Program.run
