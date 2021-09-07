
using Windows.UI;

namespace MandelbrotCommon
{
    class HsvRgbConverter
    {
        // Based on https://stackoverflow.com/questions/17080535/hsv-to-rgb-stops-at-yellow-c-sharp
        // hue should be 0-255
        public static Color Hue2RGB(int hue)
        {
            float h = hue / 255.0f;
            float saturation = 0.999f;
            float value = 0.999f;
            if (h > 0.999f) { h = 0.999f; }
            if (h < 0.001f) { h = 0.001f; }

            float h6 = h * 6f;
            if (h6 == 6f) { h6 = 0f; }
            int ihue = (int)(h6);
            float p = value * (1f - saturation);
            float q = value * (1f - (saturation * (h6 - (float)ihue)));
            float t = value * (1f - (saturation * (1f - (h6 - (float)ihue))));
            switch (ihue)
            {
                case 0:
                    return CreateColor(value, t, p);
                case 1:
                    return CreateColor(q, value, p);
                case 2:
                    return CreateColor(p, value, t);
                case 3:
                    return CreateColor(p, q, value);
                case 4:
                    return CreateColor(t, p, value);
                default:
                    return CreateColor(value, p, q);
            }
        }

        private static Color CreateColor(float r, float g, float b)
        {
            // EVIP: creating a Color from ARGB values.
            //  Static factory method inside Color.
            return Color.FromArgb(255, (byte)(r * 255.0),
                (byte)(g * 255.0), (byte)(b * 255.0));
        }
    }
}
