using MandelbrotCommon;
using System.Numerics;
using Windows.UI.Xaml.Media.Imaging;

namespace FavoriteMandelbrots.Model
{
    public class Area : ObservableObject
    {
        #region Properties
        private double top;
        public double Top
        {
            get
            {
                return top;
            }
            set
            {
                if (top != value)
                {
                    top = value;
                    Notify();
                }
            }
        }

        private double bottom;
        public double Bottom
        {
            get
            {
                return bottom;
            }
            set
            {
                if (bottom != value)
                {
                    bottom = value;
                    Notify();
                }
            }
        }

        private double left;
        public double Left
        {
            get
            {
                return left;
            }
            set
            {
                if (left != value)
                {
                    left = value;
                    Notify();
                }
            }
        }

        private double right;
        public double Right
        {
            get
            {
                return right;
            }
            set
            {
                if (right != value)
                {
                    right = value;
                    Notify();
                }
            }
        }
        #endregion

        // EVIP: Getter-only property and string interpolation
        public string AsString => $"{left:G4}+i{top:G4} - {right:G4}+i{bottom:G4}";

        public WriteableBitmap Render(int width, int height)
        {
            ImageRendererBase m = new Mandelbrot();
            return m.Render(new Complex(left, top), new Complex(right, bottom),
                width, height);
        }

        // Helper method used when replacing the model to notify the UI
        //  about all changes.
        internal void NotifyAllPropertiesChanged()
        {
            Notify(nameof(Top));
            Notify(nameof(Left));
            Notify(nameof(Bottom));
            Notify(nameof(Right));
        }

        public Area Clone()
        {
            return new Area() { Top = this.top, Bottom = this.bottom, Left = this.left, Right = this.right };
        }

        internal void CopyTo(Area target)
        {
            target.Top = this.Top;
            target.Bottom = this.Bottom;
            target.Left = this.Left;
            target.Right = this.Right;
        }

    }
}
