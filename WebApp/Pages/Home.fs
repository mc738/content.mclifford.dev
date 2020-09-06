namespace WebApp.Pages

module Home =
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html

    let main =
        div [ attr.id "main" ] [
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
            p [] [ text "hello" ]
        ]




    let articles = div [ attr.``class`` "s-3" ] [ h2 [] [ text "Articles" ] ]

    let downloads = div [attr.``class`` "s-3"] [ h2 [] [ text "Articles" ] ]

    let documentation = div [attr.``class`` "s-3"] [ h2  [] [ text "Documentation" ] ]

    let overview =
        div [
            attr.``class`` "block h-50"
        ] [
            articles
            downloads
            documentation
        ]
    
    let header =
        div [ attr.id "home-p"
              attr.``class`` "parallax" ] [
            header [] [
                div [] [
                    h1 [] [ text "mclifford.dev Content" ]
                    p [] [
                        span [ attr.``class`` "hl" ] [
                            text "Hello, World!"
                        ]
                    ]
                ]
            ]
        ]

    let create = [ header; main ]
