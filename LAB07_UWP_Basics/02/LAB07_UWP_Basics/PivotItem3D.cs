using HelixToolkit.UWP;
using SharpDX;
using System;
using System.Diagnostics;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LAB07_UWP_Basics
{
    public class PivotItem3D 
    {
        private Geometry3D Geometry { set; get; }
        private Geometry3D Sphere { set; get; }
        private Geometry3D FloorModel { set; get; }

        private BillboardText3D LabelGeometry { set; get; }

        private IEffectsManager EffectsManager { set; get; } = new DefaultEffectsManager();

        private PhongMaterial Material0 { set; get; }
        private PhongMaterial Material1 { set; get; }
        private PhongMaterial FloorMaterial { set; get; }

        private TextureModel EnvironmentMap { set; get; }
        private Vector3 DirectionalLightDirection { get; } = new Vector3(-0.5f, -1, 0);

        private Camera Camera { set; get; }
        private Vector3 UpDirection { get; set; } = Vector3.UnitY;

        public void MoveCamera(float forwardForce)
            => Camera.Position += forwardForce * 0.001f * Camera.LookDirection;

        public void RotateCamera(float dx, float dy)
            => viewport3DX.AddRotateForce(-dx, -dy);

        public event EventHandler<MouseDown3DEventArgs> Viewport3DX_OnMouse3DDown
        {
            add => viewport3DX.OnMouse3DDown += value;
            remove => viewport3DX.OnMouse3DDown -= value;
        }
        public event EventHandler<MouseUp3DEventArgs> Viewport3DX_OnMouse3DUp
        {
            add => viewport3DX.OnMouse3DUp += value;
            remove => viewport3DX.OnMouse3DUp -= value;
        }
        public event EventHandler<MouseMove3DEventArgs> Viewport3DX_OnMouse3DMove
        {
            add => viewport3DX.OnMouse3DMove += value;
            remove => viewport3DX.OnMouse3DMove -= value;
        }
        public event Windows.Foundation.TypedEventHandler<Windows.UI.Core.CoreWindow, Windows.UI.Core.KeyEventArgs> Viewport3DX_KeyDown
        {
            add => Window.Current.CoreWindow.KeyDown += value;
            remove => Window.Current.CoreWindow.KeyDown -= value;
        }

        public PivotItem3D(Grid grid3d)
        {
            Camera = new PerspectiveCamera()
            {
                Position = new Vector3(0, 15, 80),
                LookDirection = new Vector3(0, -10, -100),
                UpDirection = UpDirection,
                FarPlaneDistance = 500,
                NearPlaneDistance = 0.1
            };

            var builder = new MeshBuilder(true, true, true);
            builder.AddBox(new Vector3(0, 0, 0), 2, 2, 2);
            builder.AddSphere(new Vector3(0, 2, 0), 1.5);
            Geometry = builder.ToMesh();
            Geometry.UpdateOctree();
            builder = new MeshBuilder();
            builder.AddSphere(new Vector3(0, 2, 0), 2);
            Sphere = builder.ToMesh();
            Sphere.UpdateOctree();

            Material0 = new PhongMaterial()
            {
                AmbientColor = Color.Gray,
                DiffuseColor = new Color4(0.75f, 0.75f, 0.75f, 1.0f),
                SpecularColor = Color.White,
                SpecularShininess = 10f,
                ReflectiveColor = new Color4(0.2f, 0.2f, 0.2f, 0.5f),
                RenderEnvironmentMap = true
            };
            Material0.DiffuseMap = LoadTexture("TextureCheckerboard2.jpg");
            Material0.NormalMap = LoadTexture("TextureCheckerboard2_dot3.jpg");
            Material1 = Material0.CloneMaterial();
            Material1.ReflectiveColor = Color.Silver;
            Material1.RenderDiffuseMap = false;
            Material1.RenderNormalMap = false;
            Material1.RenderEnvironmentMap = true;
            Material1.RenderShadowMap = true;

            LabelGeometry = new BillboardText3D();
            LabelGeometry.TextInfo.Add(new TextInfo("Szép munka :)", new Vector3(0, 15f, 100f)) { Foreground = Color.Red });

            builder = new MeshBuilder();
            builder.AddBox(new Vector3(0, -6, 0), 30, 0.5, 30);
            FloorModel = builder.ToMesh();

            FloorMaterial = PhongMaterials.Obsidian;
            FloorMaterial.ReflectiveColor = Color.Silver;
            FloorMaterial.RenderShadowMap = true;

            EnvironmentMap = LoadTexture("Cubemap_Grandcanyon.dds");

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            timer.Start();

            buildPivotItem3D(grid3d);
        }

        private void buildPivotItem3D(Grid grid3d)
        {
            var modelContainer3DX = new ModelContainer3DX()
            {
                Name = "sharedModel",
                EffectsManager = EffectsManager
            };

            viewport3DX = new Viewport3DXCustom()
            {
                Name = "viewport",
                Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black),
                BackgroundColor = Windows.UI.Colors.Black,
                Camera = Camera,
                CameraMode = CameraMode.FixedPosition,
                IsRotationEnabled = true,
                IsInertiaEnabled = false,
                EnableAutoOctreeUpdate = true,
                EnableDeferredRendering = true,
                EnableDesignModeRendering = false,
                EnableSharedModelMode = true,
                FXAALevel = FXAALevel.Low,
                IsShadowMappingEnabled = true,
                ModelUpDirection = UpDirection,
                SharedModelContainer = modelContainer3DX,
                ShowCoordinateSystem = true,
                ShowViewCube = false,
                ShowFrameDetails = true,
                ShowFrameRate = true,
                IsZoomEnabled = false,
            };

            var directionalLight3D = new DirectionalLight3D()
            {
                Direction = DirectionalLightDirection,
                Color = Windows.UI.Colors.White
            };

            var environmentMap3D = new EnvironmentMap3D() { Texture = EnvironmentMap };

            var groupModel3D_0 = new GroupModel3D();
            var dynamicReflectionMap3D = new DynamicReflectionMap3D() { IsDynamicScene = true };
            var meshGeometryModel3D_0 = new MeshGeometryModel3D()
            {
                CullMode = SharpDX.Direct3D11.CullMode.Back,
                Geometry = Sphere,
                IsThrowingShadow = true,
                Material = Material1
            };
            dynamicReflectionMap3D.Children.Add(meshGeometryModel3D_0);
            groupModel3D_0.Children.Add(dynamicReflectionMap3D);

            groupModel3D_1 = new GroupModel3D()
            {
                Transform3D = Matrix.Identity,
                OctreeManager = new GeometryModel3DOctreeManager()
            };
            meshGeometryModel3D_1 = new MeshGeometryModel3D()
            {
                CullMode = SharpDX.Direct3D11.CullMode.Back,
                Geometry = Geometry,
                IsThrowingShadow = true,
                Material = Material0,
                Transform3D = Matrix.Identity
            };
            meshGeometryModel3D_2 = new MeshGeometryModel3D()
            {
                CullMode = SharpDX.Direct3D11.CullMode.Back,
                Geometry = Geometry,
                IsThrowingShadow = true,
                Material = Material0,
                Transform3D = Matrix.Identity
            };
            meshGeometryModel3D_3 = new MeshGeometryModel3D()
            {
                CullMode = SharpDX.Direct3D11.CullMode.Back,
                Geometry = Geometry,
                IsThrowingShadow = true,
                Material = Material0,
                Transform3D = Matrix.Identity
            };
            groupModel3D_1.Children.Add(meshGeometryModel3D_1);
            groupModel3D_1.Children.Add(meshGeometryModel3D_2);
            groupModel3D_1.Children.Add(meshGeometryModel3D_3);

            var meshGeometryModel3D_4 = new MeshGeometryModel3D()
            {
                Name = "floor",
                CullMode = SharpDX.Direct3D11.CullMode.Back,
                Geometry = FloorModel,
                IsHitTestVisible = false,
                Material = FloorMaterial
            };

            var billBoardTextModel = new BillboardTextModel3D()
            {
                Geometry = LabelGeometry,
                IsTransparent = true
            };

            viewport3DX.Items.Add(new ShadowMap3D());
            viewport3DX.Items.Add(directionalLight3D);
            viewport3DX.Items.Add(environmentMap3D);
            viewport3DX.Items.Add(groupModel3D_0);
            viewport3DX.Items.Add(groupModel3D_1);
            viewport3DX.Items.Add(meshGeometryModel3D_4);
            viewport3DX.Items.Add(billBoardTextModel);

            grid3d.Children.Add(modelContainer3DX);
            grid3d.Children.Add(viewport3DX);
        }

        private Viewport3DXCustom viewport3DX;
        private GroupModel3D groupModel3D_1;
        private MeshGeometryModel3D meshGeometryModel3D_1, meshGeometryModel3D_2, meshGeometryModel3D_3;
        private DispatcherTimer timer;
        private float scale = 1;
        private float rotationSpeed = 1;

        private Stream LoadTexture(string file)
        {
            var packageFolder = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "");
            var bytecode = global::SharpDX.IO.NativeFile.ReadAllBytes(packageFolder + @"\" + file);
            return new MemoryStream(bytecode);
        }

        private void Timer_Tick(object sender, object e)
        {
            var time = (float)Stopwatch.GetTimestamp() / Stopwatch.Frequency;
            groupModel3D_1.Transform3D = Matrix.Scaling(scale) * Matrix.RotationX(rotationSpeed * time)
                    * Matrix.RotationY(rotationSpeed * time * 2.0f) * Matrix.RotationZ(rotationSpeed * time * .7f);
            meshGeometryModel3D_1.Transform3D = Matrix.Scaling(scale) * Matrix.RotationX(-rotationSpeed * time * .7f)
                * Matrix.RotationY(-rotationSpeed * time * 1.0f) * Matrix.RotationZ(rotationSpeed * time) * Matrix.Translation(3, -3, -3);
            meshGeometryModel3D_2.Transform3D = Matrix.Scaling(scale) * Matrix.RotationX(-rotationSpeed * time * -.7f)
                    * Matrix.RotationY(-rotationSpeed * time * 1.0f) * Matrix.RotationZ(rotationSpeed * time) * Matrix.Translation(3, 3, 3);
            meshGeometryModel3D_3.Transform3D = Matrix.Scaling(scale) * Matrix.RotationX(-rotationSpeed * time * .7f)
                    * Matrix.RotationY(-rotationSpeed * time * -0.5f) * Matrix.RotationZ(rotationSpeed * time) * Matrix.Translation(-5, -5, 5);
        }
    }

    public class Viewport3DXCustom : Viewport3DX
    {
        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            var properties = e.GetCurrentPoint(this).Properties;
            if (properties.IsLeftButtonPressed)
                base.OnPointerPressed(e);
            else
                e.Handled = true;
        }
    }
}
