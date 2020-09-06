namespace WebApp.Pages

module StyleGuide =
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html

    let eLT = "Example (light):"
    let eDT = "Example (dark):"

    let lorem =
        "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Aperiam quaerat est nobis rerum, id explicabo ullam soluta iste vitae distinctio? Deleniti assumenda quis enim harum laborum magnam ratione cupiditate voluptate."

    let paragraphs =
        details [ attr.``open`` "true" ] [
            summary [] [
                h3 [] [ text "Paragraphs" ]
            ]
            p [] [ text "Basic paragraph styles." ]
            code [] [ text eLT ]
            div [ attr.``class`` "example lm" ] [
                p [] [ text lorem ]
                p [] [ text lorem ]
            ]
            code [] [ text eDT ]
            div [ attr.``class`` "example dm" ] [
                p [] [ text lorem ]
                p [] [ text lorem ]
            ]
        ]

    let generalSection =
        details [ attr.id "general"
                  attr.``open`` "true" ] [
            summary [] [ h2 [] [ text "General" ] ]
            paragraphs
        ]

    let header =
        div [ attr.``class`` "parallax" ] [
            header [ attr.``class`` "dm" ] [
                div [] [
                    h1 [] [
                        text "mclifford.dev Style Document"
                    ]
                    p [] [
                        span [ attr.``class`` "hl" ] [
                            text "Version 1"
                        ]
                    ]
                ]
            ]
        ]

    let main = div [ attr.id "main" ] [
        generalSection
    ]

    let footer = footer [] []

    /// Create the style guide.
    let create = [
        header
        main
        footer
    ]