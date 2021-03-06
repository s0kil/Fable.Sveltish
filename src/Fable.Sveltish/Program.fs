module Sveltish.Program

    //
    // Sveltish Elmish
    // The model mutates in Sveltish, so the function signatures are slightly different to Elmish.
    // This approach isn't necessary, but it could be helpful in that it encourages the view to
    // dispatch messages that are then processed only in the update function.
    //
    let makeProgram host init update view =
        let model = init()

        let makeDispatcher update =
            (fun msg -> update msg model)

        Sveltish.DOM.mountElement host <| view model (makeDispatcher update)