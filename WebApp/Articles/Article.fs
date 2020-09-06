namespace WebApp.Articles

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html

[<JavaScript>]
module Article =
    type Span = { SpanText: string; Classes: string }

    type ParagraphType =
        | Text of string
        | Spans of Span seq

    type ImageType =
        { AltText: string
          Description: string
          Src: string }

    type CodeType = string

    type ListItem =
        | ItemText of string
        | Paragraphs of ParagraphType seq

    type BlockType =
        | OrderedList of ListItem seq
        | UnorderedList of ListItem seq
        | Paragraph of ParagraphType
        | Image of ImageType
        | Code of CodeType

    type Block = { Type: BlockType; }

    type Section = { Title: string; Blocks: Block seq }

    type Article =
        { Name: string
          Title: string
          Summary: string
          ImageUrl: string
          Sections: Section seq }

    let renderSpan s =
        span [ attr.``class`` s.Classes ] [text s.SpanText]

    let renderParagraph (paragraph: ParagraphType) =
        match paragraph with
        | Text t -> p [] [ text t ]
        | Spans s ->
            let spans = s |> List.ofSeq |> List.map renderSpan
            p [] spans
            
    let renderListItem (item: ListItem) =
        match item with
        | ItemText t -> li [] [ text t ]
        | Paragraphs p ->
            let paragraphs =
                p |> List.ofSeq |> List.map renderParagraph

            li [] paragraphs

    let renderOrderedList (items: ListItem seq) =
        let renderedItems =
            items |> List.ofSeq |> List.map renderListItem

        ol [] renderedItems

    let renderUnorderedList (items: ListItem seq) =
        let renderedItems =
            items |> List.ofSeq |> List.map renderListItem

        ul [] renderedItems

    let renderImage (image:ImageType) = div [] [
        img [ attr.src image.Src ] []
        small [ attr.``class`` "image-description" ] [ text image.Description ]
    ]

    let renderCode (block: CodeType) = code [ attr.``class`` "code" ] [text block ]


    let renderBlock block =
        match block.Type with
        | OrderedList items -> renderOrderedList items 
        | UnorderedList items -> renderOrderedList items
        | Paragraph para -> renderParagraph para
        | Image image -> renderImage image
        | Code code -> renderCode code
        
    let renderSection (section: Section) =
        let title =
            h2 [ attr.``class`` "section-title" ] [
                text section.Title
            ]

        let blocks =
            section.Blocks
            |> List.ofSeq
            |> List.map renderBlock

        let section = title :: blocks

        div [ attr.``class`` "section" ] section
        
    let renderArticle article =
        
        let title =
            h1 [ attr.``class`` "article-title" ] [
                text article.Title
            ]

        let image = img [ attr.src article.ImageUrl ]

        let summary =
            p [ attr.``class`` "article-summary" ] [
                text article.Summary
            ]

        let sections =
            article.Sections
            |> List.ofSeq
            |> List.map renderSection

        // Add the title and sections together.
        let article = title :: summary :: sections

        div [ attr.``class`` "article" ] article