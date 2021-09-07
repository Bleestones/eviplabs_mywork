using System.Collections.Generic;

namespace InstantiationUsingXaml
{
    [Windows.UI.Xaml.Markup.ContentProperty(Name = "Lectures")]
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Room Room { get; set; }

        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

    }
}
