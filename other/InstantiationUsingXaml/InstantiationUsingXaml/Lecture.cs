namespace InstantiationUsingXaml
{
    [Windows.UI.Xaml.Markup.ContentProperty(Name = "Description")]
    public class Lecture
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}