module App

// state type

// msg type

// init

// update

// view
open Feliz

let view =
  Html.div [
    Html.p $"You have {TODO} coins 💰"
    Html.button [
      prop.onClick (fun _ -> TODO)
      prop.text "Generate 🚀"
    ]
  ]

// program
