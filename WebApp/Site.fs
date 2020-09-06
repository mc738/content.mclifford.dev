namespace WebApp

open WebApp.Articles
open WebApp.Articles.Article
open WebSharper
open WebSharper.Sitelets
open WebSharper.UI
open WebSharper.UI.Server
open WebApp.Pages

type EndPoint =
    | [<EndPoint "/">] Home
    | [<EndPoint "/about">] About
    | [<EndPoint "/style-document">] StyleDocument
    | [<EndPoint "/download">] Download
    | [<EndPoint "/articles">] Articles
    | [<EndPoint "/article/">] Article of key: string

module Templating =

    open WebSharper.UI.Html

    type MainTemplate = Templating.Template<"Main.html">

    // Compute a menubar where the menu item for the given endpoint is active
    let MenuBar (ctx: Context<EndPoint>) endpoint: Doc list =
        let (=>) txt act =
            li [ if endpoint = act then yield attr.``class`` "active" ] [
                a [ attr.href (ctx.Link act) ] [
                    text txt
                ]
            ]

        [ "Home" => EndPoint.Home
          "About" => EndPoint.About
          "Style Document" => EndPoint.StyleDocument ]

    let Main ctx action (title: string) (body: Doc list) =
        Content.Page(MainTemplate().Title(title).MenuBar(MenuBar ctx action).Body(body).Doc())

module Site =
    open WebSharper.UI.Html

    let HomePage ctx =
        Templating.Main ctx EndPoint.Home "Home" Home.create

    let AboutPage ctx =
        Templating.Main ctx EndPoint.About "About" About.create

    let StyleDocument ctx =
        Templating.Main ctx EndPoint.StyleDocument "Style Document" StyleGuide.create

    let Articles ctx =
        Templating.Main ctx EndPoint.StyleDocument "Articles" Articles.create

    let Article ctx key =
        // Load the example
        let (title,content) = Article.create key
        
        Templating.Main ctx EndPoint.StyleDocument title content


    let Download =
        Content.File("../WebApp/Thanks.md", AllowOutsideRootFolder = true, ContentType = "text/plain")

    [<Website>]
    let Main =
        Application.MultiPage(fun ctx endpoint ->
            match endpoint with
            | EndPoint.Home -> HomePage ctx
            | EndPoint.About -> AboutPage ctx
            | EndPoint.StyleDocument -> StyleDocument ctx
            | EndPoint.Download -> Download
            | EndPoint.Articles -> Articles ctx
            | EndPoint.Article key -> Article ctx key

            )
