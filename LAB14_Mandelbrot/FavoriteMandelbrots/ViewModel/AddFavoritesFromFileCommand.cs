using FavoriteMandelbrots.Model;
using FavoriteMandelbrots.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.Storage;

namespace FavoriteMandelbrots.ViewModel
{
    public class AddFavoritesFromFileCommand : CommandBase
    {
        private readonly Action<Area> addAction;

        public AddFavoritesFromFileCommand(MainViewerViewModel vm, Action<Area> addAction)
            : base(vm)
        {
            this.addAction = addAction;
        }

        public async override void Execute(object parameter)
        {
            var loadPicker = new Windows.Storage.Pickers.FileOpenPicker();
            loadPicker.FileTypeFilter.Add(".xml");

            StorageFile file = await loadPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    vm.Favorites.Clear();
                    LoadFromXml(stream);
                }
            }
        }

        public void LoadFromXml(Stream stream)
        {
            XElement XMLFile = XElement.Load(stream);
            IEnumerable<XElement> xmlElements = XMLFile.Elements("favorite");
            Area area;
            foreach (var xmlElement in xmlElements)
            {
                area = new Area()
                {
                    Top = Double.Parse(xmlElement.Attribute("top").Value),
                    Bottom = Double.Parse(xmlElement.Attribute("bottom").Value),
                    Left = Double.Parse(xmlElement.Attribute("left").Value),
                    Right = Double.Parse(xmlElement.Attribute("right").Value)
                };
                addAction.Invoke(area);
            }
        }
    }
}