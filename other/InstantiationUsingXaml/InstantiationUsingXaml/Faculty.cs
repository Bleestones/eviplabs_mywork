using System.Collections.Generic;

namespace InstantiationUsingXaml
{
    public class Faculty
    {
        public string Title { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
