using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;
using Windows.Storage;

namespace FavoriteMandelbrots.ViewModel
{
    public class SaveFavoritesCommand : CommandBase
    {
        public SaveFavoritesCommand(MainViewerViewModel vm) : base(vm)
        {
        }

        public override async void Execute(object parameter)
        {
            // EVIP: FileSavePicker
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.FileTypeChoices.Add("XML", new List<string>() { ".xml" });
            savePicker.SuggestedFileName = "favorites.xml";

            StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                using (Stream stream = await file.OpenStreamForWriteAsync())
                {
                    // EVIP: Writing objects into XML file
                    XElement treeRoot = CreateXmlTree();
                    await treeRoot.SaveAsync(stream, SaveOptions.None,
                        new System.Threading.CancellationToken());
                }
            }
        }

        private XElement CreateXmlTree()
        {
            // EVIP: creating Xml using Linq to Xml
            var favorites = vm.Favorites
                .Select(areaViewModel => areaViewModel.Model).ToArray();
            XElement root = new XElement("favorites");
            var xmlElements = favorites.Select(f => new XElement("favorite",
                     new XAttribute("top", f.Top), new XAttribute("bottom", f.Bottom),
                     new XAttribute("left", f.Left), new XAttribute("right", f.Right)));
            foreach (var element in xmlElements)
                root.Add(element);
            return root;
        }
    }
}
