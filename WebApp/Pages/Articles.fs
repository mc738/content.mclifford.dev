namespace WebApp.Pages

module Articles =
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html
    open WebApp.Components

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
    
    let main =
        div [ attr.id "main" ] [
           overview
        ]

    let header =
        div [ attr.id "article-p"
              attr.``class`` "parallax" ] [
            header [] [
                div [] [
                    h1 [] [ text "Articles" ]
                    p [] [
                        span [ attr.``class`` "hl" ] [
                            text "Stay a while, and listen..."
                        ]
                    ]
                ]
            ]
        ]

    let footer = Footer.create
    let create = [ header; main; footer; ]