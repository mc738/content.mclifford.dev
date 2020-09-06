namespace WebApp.Pages

open WebApp.Articles


module Article =
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI
    open WebSharper.UI.Client
    open WebSharper.UI.Html
    open WebApp.Components
    
    let loadArticle key =
        match key with
        | "hello_world" -> ``hello world``.create
        | _ -> ("Not Found",NotFound.create)
        
    
    let main content =
        div [ attr.id "main" ] content
        

    let header title subTitle =
        div [ attr.id "article-p"
              attr.``class`` "parallax" ] [
            header [] [
                div [] [
                    h1 [] [ text title ]
                    p [] [
                        span [ attr.``class`` "hl" ] [
                            text subTitle
                        ]
                    ]
                ]
            ]
        ]

    let create key =
        let (title, content) = loadArticle key
        
        let head = header title "Hello, World!"
        let body = main content
        let footer = Footer.create
        
        (title,[ head; body; footer ]) 