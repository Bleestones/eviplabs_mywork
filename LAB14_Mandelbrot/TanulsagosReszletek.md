# Tanulságos részletek a Mandelbrot solutionben

(Ebből mi van benne a kiadott anyagban is?! Ha labor, akkor nem tudom publikus helyen mutogatni a mintamegoldást!)

- Két UWP application és egy UWP Class Library projekt egy solutionben.

## MandelbrotCommon

- UWP class library, 2 helyről  használva
- ImageRendererBase osztály
  - publikus metódus az alapfunkció hívására
  - protected absztrakt metódus a specifikus dolgokhoz (Render)
  - protected helper metódus.
  - absztrakt RenderDefault metódus, ami egy demó beállítással fogja hívni a publikus Render metódust.
  - StopWatch
- Mandelbrot osztály:
  - csak a specifikus dolgok az ősosztályhoz képest
  - Linq-es renderelés, először pixel forrás, majd AsParallel, helper method felhasználása (ősosztályból ToScaledComplex(), innen GetMandelbrotDivergenceIndex() és Index2HSV()), ImageIndexingExtensions.SetPixels extension method Linq-konformra.
  - Komplex számok a GetMandelbrotDivergenceIndex()-ben. Itt van az egész matematikája, összesen 8 sorban.

## ShowFixedMandelbrot

- XAML alapok: névterek, példányosítás, attached property (RelativePanel), alap controlok: Page, RelativePanel, Button, Image
- RelativePanel egyszerű használata (MainPage.xaml), nyomógombhoz közvetlen eseménykezelő.
- ImageRendererBase ősosztály leszármazottjai (Mandelbrot, TestGridImageRenderer) csereszabatosak, debug célokra könnyen cserélhetőek. (MainPage.xaml.cs Button_Click)

## FavoriteMandelbrots

- MVVM architektúra, VM-ben ICommand-ok.
- CommandBase absztrakt ősosztály, benne néhány gyakran kellő dolog (VM hivatkozás, CanExecute())
- CommandBase-ben pragma warning disable/restore
- MainViewer user control
- ScrollViewer, StackPanel, Button: KeyboardAccelerator, Tooltip
- Command binding és Command parameter
- ListView, ItemContainerStyle (xaml Style!), ItemTemplate, DataTemplate

- View model INPC és hatásláncok, lásd AreaViewModel.ShowInMainViewerCommand nested command class!
- XML perzisztencia: Linq2xml (de)szerializálás
- string interpolation

- Kezdetben egyből jelenjen meg: MainViewer.xaml.cs Loaded event: UserControl_Loaded (VM ctorban még túl korai, a scrollviewer még nem reagál rá).
