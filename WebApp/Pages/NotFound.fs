namespace WebApp.Pages

module NotFound =
    
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html
    
    let create =
        [
            div [][
                h1 [] [ text "Not Found" ]
                p [] [text "The resource you were looking for could not be found."]
            ]
        ]

