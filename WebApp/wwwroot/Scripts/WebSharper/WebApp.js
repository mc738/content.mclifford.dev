(function()
{
 "use strict";
 var Global,WebApp,Articles,Article,Span,ImageType,Block,Section,Article$1,Client,WebSharper,UI,Doc,AttrProxy,List,Var$1,Submitter,View,Remoting,AjaxRemotingProvider,Concurrency;
 Global=self;
 WebApp=Global.WebApp=Global.WebApp||{};
 Articles=WebApp.Articles=WebApp.Articles||{};
 Article=Articles.Article=Articles.Article||{};
 Span=Article.Span=Article.Span||{};
 ImageType=Article.ImageType=Article.ImageType||{};
 Block=Article.Block=Article.Block||{};
 Section=Article.Section=Article.Section||{};
 Article$1=Article.Article=Article.Article||{};
 Client=WebApp.Client=WebApp.Client||{};
 WebSharper=Global.WebSharper;
 UI=WebSharper&&WebSharper.UI;
 Doc=UI&&UI.Doc;
 AttrProxy=UI&&UI.AttrProxy;
 List=WebSharper&&WebSharper.List;
 Var$1=UI&&UI.Var$1;
 Submitter=UI&&UI.Submitter;
 View=UI&&UI.View;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 Span.New=function(SpanText,Classes)
 {
  return{
   SpanText:SpanText,
   Classes:Classes
  };
 };
 ImageType.New=function(AltText,Description,Src)
 {
  return{
   AltText:AltText,
   Description:Description,
   Src:Src
  };
 };
 Block.New=function(Type)
 {
  return{
   Type:Type
  };
 };
 Section.New=function(Title,Blocks)
 {
  return{
   Title:Title,
   Blocks:Blocks
  };
 };
 Article$1.New=function(Name,Title,Summary,ImageUrl,Sections)
 {
  return{
   Name:Name,
   Title:Title,
   Summary:Summary,
   ImageUrl:ImageUrl,
   Sections:Sections
  };
 };
 Article.renderArticle=function(article)
 {
  var title,a,article$1;
  title=Doc.Element("h1",[AttrProxy.Create("class","article-title")],[Doc.TextNode(article.Title)]);
  a=List.ofArray([AttrProxy.Create("src",article.ImageUrl)]);
  article$1=new List.T({
   $:1,
   $0:title,
   $1:new List.T({
    $:1,
    $0:Doc.Element("p",[AttrProxy.Create("class","article-summary")],[Doc.TextNode(article.Summary)]),
    $1:List.map(Article.renderSection,List.ofSeq(article.Sections))
   })
  });
  return List.ofArray([Doc.Element("div",[AttrProxy.Create("class","article")],article$1)]);
 };
 Article.renderSection=function(section)
 {
  var section$1;
  section$1=new List.T({
   $:1,
   $0:Doc.Element("h2",[AttrProxy.Create("class","section-title")],[Doc.TextNode(section.Title)]),
   $1:List.map(Article.renderBlock,List.ofSeq(section.Blocks))
  });
  return Doc.Element("div",[AttrProxy.Create("class","section")],section$1);
 };
 Article.renderBlock=function(block)
 {
  var m;
  m=block.Type;
  return m.$==1?Article.renderOrderedList(m.$0):m.$==2?Article.renderParagraph(m.$0):m.$==3?Article.renderImage(m.$0):m.$==4?Article.renderCode(m.$0):Article.renderOrderedList(m.$0);
 };
 Article.renderCode=function(block)
 {
  return Doc.Element("code",[AttrProxy.Create("class","code")],[Doc.TextNode(block)]);
 };
 Article.renderImage=function(image)
 {
  return Doc.Element("div",[],[Doc.Element("img",[AttrProxy.Create("src",image.Src)],[]),Doc.Element("small",[AttrProxy.Create("class","image-description")],[Doc.TextNode(image.Description)])]);
 };
 Article.renderUnorderedList=function(items)
 {
  return Doc.Element("ul",[],List.map(Article.renderListItem,List.ofSeq(items)));
 };
 Article.renderOrderedList=function(items)
 {
  return Doc.Element("ol",[],List.map(Article.renderListItem,List.ofSeq(items)));
 };
 Article.renderListItem=function(item)
 {
  return item.$==1?Doc.Element("li",[],List.map(Article.renderParagraph,List.ofSeq(item.$0))):Doc.Element("li",[],[Doc.TextNode(item.$0)]);
 };
 Article.renderParagraph=function(paragraph)
 {
  return paragraph.$==1?Doc.Element("p",[],List.map(Article.renderSpan,List.ofSeq(paragraph.$0))):Doc.Element("p",[],[Doc.TextNode(paragraph.$0)]);
 };
 Article.renderSpan=function(s)
 {
  return Doc.Element("span",[AttrProxy.Create("class",s.Classes)],[Doc.TextNode(s.SpanText)]);
 };
 Client.Main=function()
 {
  var rvInput,submit,vReversed;
  rvInput=Var$1.Create$1("");
  submit=Submitter.CreateOption(rvInput.get_View());
  vReversed=View.MapAsync(function(a)
  {
   var b;
   return a!=null&&a.$==1?(new AjaxRemotingProvider.New()).Async("WebApp:WebApp.Server.DoSomething:-1259710604",[a.$0]):(b=null,Concurrency.Delay(function()
   {
    return Concurrency.Return("");
   }));
  },submit.view);
  return Doc.Element("div",[],[Doc.Input([],rvInput),Doc.Button("Send",[],function()
  {
   submit.Trigger();
  }),Doc.Element("hr",[],[]),Doc.Element("h4",[AttrProxy.Create("class","text-muted")],[Doc.TextNode("The server responded:")]),Doc.Element("div",[AttrProxy.Create("class","jumbotron")],[Doc.Element("h1",[],[Doc.TextView(vReversed)])])]);
 };
}());
