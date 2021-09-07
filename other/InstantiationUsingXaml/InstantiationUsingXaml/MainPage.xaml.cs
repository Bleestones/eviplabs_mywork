using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Documentation on classes used from XAML
// https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/xaml-and-custom-classes-for-wpf

namespace InstantiationUsingXaml
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var dict = CreateDictionary();
            //var dict = this.Resources;

            var room = (Room)dict["RoomQBF08"];

            sb.AppendLine($"Room {room.Name} has capacity {room.Capacity}.");

            var faculty = (Faculty)dict["FacultyVIK"];
            sb.AppendLine($"Courses of faculty {faculty.Title}");
            foreach (Course c in faculty.Courses)
            {
                sb.AppendLine($"- Course {c.Name} ({c.Code}) in room {c.Room.Name}:");
                sb.AppendLine($"   Lectures of {c.Name}:");
                foreach (Lecture l in c.Lectures)
                    sb.AppendLine($"   - {l.Title} ({l.Description})");
            }

            TextBox.Text = sb.ToString();
        }

        private Dictionary<string, object> CreateDictionary()
        {
            var dict = new Dictionary<string, object>();

            dict.Add("RoomIB028", new Room() { Name = "IB028", Capacity = 400 });
            dict.Add("RoomQBF08", new Room() { Name = "QBF08", Capacity = 95 });
            dict.Add("RoomQBF09", new Room() { Name = "QBF09", Capacity = 105 });

            var f = new Faculty() { Title = "VIK" };
            dict.Add("FacultyVIK", f);

            var bambi = new Course() { Name = "BAMBI", Code = "VIMIA347",
                Room = (Room)dict["RoomQBF08"] };
            f.Courses.Add(bambi);

            var evip = new Course() { Name = "EViP", Code = "VIAUBB01",
                Room = (Room)dict["RoomIB028"] };
            evip.Lectures.Add(new Lecture() { Title = "Bevezető",
                Description = "Itt a tárgy egészéről lesz szó..."});
            evip.Lectures.Add(new Lecture() { Title = "C# alapok",
                Description = "Itt elkezdünk foglalkozni a C# nyelv alapjaival." });
            evip.Lectures.Add(new Lecture() { Title = "Szövegfeldolgozás és I/O",
                Description = "Itt egy Regex + I/O labort készítünk elő..." });
            f.Courses.Add(evip);

            return dict;
        }
    }
}
