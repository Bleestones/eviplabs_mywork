using System.Xml.Linq;

namespace Linq2XmlSvgLab
{
    // Amennyiben áttekinthetőbbnek érzed a kódot, bizonyos funkciókat extension methodokba
    // is megvalósíthatsz. Az alábbi példa után egy XElement típusú rect változóra lesz "rect.GetId();".
    public static class ExtensionMethods
    {
        static public string GetId(this XElement self)
        {
            return self.Attribute("id").Value;
        }

        static public double GetDoubleAttribute(this XElement self, string attributeName)
        {
            return double.Parse(self.Attribute(attributeName).Value, System.Globalization.CultureInfo.InvariantCulture);
        }

        static public double GetX(this XElement self)
        {
            return self.GetDoubleAttribute("x");
        }

        static public double GetY(this XElement self)
        {
            return self.GetDoubleAttribute("y");
        }

        static public double GetWidth(this XElement self)
        {
            return self.GetDoubleAttribute("width");
        }

        static public double GetHeight(this XElement self)
        {
            return self.GetDoubleAttribute("height");
        }

        static public string GetFillColor(this XElement rect)
        {
            string style = rect.Attribute("style").Value;
            int idx = style.IndexOf("fill:");
            return style.Substring(idx + 5, 7);
        }

        static public (double, double) GetLocation(this XElement e)
        {
            return (e.GetX(), e.GetY());
        }
    }
}
