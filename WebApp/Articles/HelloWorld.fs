namespace WebApp.Articles

module ``hello world`` =
    
    open Article
    
    let create =
        let title = "Hello World!"
        let article =
            { Title = "Creating a blog in F#"
              Name = "Creating a blog in F#"
              Summary = "This is how I managed to create a blog in F#, using WebSharper."
              ImageUrl = ""
              Sections =
                  [ { Title = "Goals"
                      Blocks =
                          [ { Type =
                                  OrderedList [ ItemText "Create a blog in F#"
                                                ItemText "Learn WebSharper."
                                                ItemText "Improve my F#." ] }
                            { Type = Paragraph(Text "This is really cool! WebSharper is really cool and so is F#.") } ] }
                    { Title = "Step 1 - Learn WebSharper"
                      Blocks = [ { Type = Paragraph(Text "Learn how to use WebSharper.") } ] }
                    { Title = "Step 2 - Improve F# Skills"
                      Blocks =
                          [ { Type = Paragraph(Text "F# is pretty cool. It lets you do some awesome stuff.") }
                            { Type = Code "let sum a b = b + a // Cool!" } ] } ] }
        (title, renderArticle article)