namespace WebApp.Components


module Footer =
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html

    let ws =
        small [] [
            text "Build with "
            a [] [
                text "WebSharper"
            ]
        ]
    
    let create = footer [] [  
        ws
    ]
