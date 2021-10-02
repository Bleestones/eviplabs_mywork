using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Globalization;

namespace Linq2XmlSvgLab
{
    public class Solutions
    {
        private readonly XElement root;
        private readonly XNamespace ns = "http://www.w3.org/2000/svg";

        public Solutions(string svgFileName)
        {
            root = XElement.Load(svgFileName);
        }

        private IEnumerable<XElement> Rects => root.Descendants(ns + "rect");
        private IEnumerable<XElement> Texts => root.Descendants(ns + "text");

        #region A laborfeladatok megoldásai
        // Minden téglalap (rect elem) felsorolása
        internal IEnumerable<XElement> GetAllRectangles()
        {
            return Rects;
        }

        // Hány olyan szöveg van, aminek ez a tartalma?
        internal int CountTextsWithValue(string v)
        {
            return Texts
                .Where(text => text.Value
                .Contains(v)).Count();
        }

        #region Téglalap szűrések
        // Minden olyan rect elem felsorolása, aminek a kerete adott vastagságú.
        //  A keretvastagság (más beállításokkal együtt) a "style" szöveges attribútumban
        //  szerepel, pl. "stroke-width:2".
        internal IEnumerable<XElement> GetRectanglesWithStrokeWidth(int width)
        {
            return Rects
                .Where(r => r.Attribute("style").Value
                .Contains($"stroke-width:{width}"));
        }

        // Adott x koordinátájú téglalapok színének visszaadása szövegesen (pl. piros esetén "#ff0000").
        internal IEnumerable<string> GetColorOfRectanglesWithGivenX(double x)
        {
            var regex = new Regex("(fill:)([#][a-f0-9]{6});");
            return Rects
                .Where(coords => coords.Attribute("x").Value
                .StartsWith(x.ToString()))
                .Select(styleAttributes => styleAttributes.Attribute("style").Value)
                .Select(color => regex.Match(color).Groups[2].Value.ToString());
        }

        // Az adott ID-jú téglalap pozíciójának (x,y) visszaadása.
        internal (double X, double Y) GetRectangleLocationById(string id)
        {
            return (Convert.ToDouble(Rects
                .FirstOrDefault(rectID => rectID.Attribute("id").Value
                .Equals(id))
                .Attribute("x").Value.ToString(), CultureInfo.InvariantCulture),
                Convert.ToDouble(Rects
                .FirstOrDefault(rectID => rectID.Attribute("id").Value
                .Equals(id))
                .Attribute("y").Value.ToString(), CultureInfo.InvariantCulture));          
        }

        // A legnagyobb y értékkel rendezkező téglalap ID-jának visszaadása.
        internal string GetIdOfRectangeWithLargestY()
        {
            return Rects
                .OrderByDescending(y => (double)(y.Attribute("y")))
                .First()
                .Attribute("id").Value.ToString();
                
        }

        // Minden olyan téglalap ID-jának felsorolása, ami legalább kétszer olyan magas mint széles.
        internal IEnumerable<string> GetRectanglesAtLeastTwiceAsHighAsWide()
        {
            return null;
        }
        #endregion

        #region Group kezelés
        // Adott ID-jú group-ban lévő téglalapok színét sorolja fel.
        internal IEnumerable<string> GetColorsOfRectsInGroup(string id)
        {
            return null;
        }
        #endregion

        #region Téglalapok és szövegek viszonya
        // Minden olyan rect elem felsorolása, amiben van bármilyen szöveg.
        //  (Olyan rect, aminek a területén van egy szövegnek a kezdőpontja (x,y).)
        internal IEnumerable<XElement> GetRectanglesWithTextInside()
        {
            return null;
        }

        // Adott színű téglalapon belüli szöveg visszaadása.
        //  Feltételezhetjük, hogy csak egyetlen ilyen színű téglalap van és abban egyetlen
        //  szöveg szerepel.
        internal string GetSingleTextInSingleRectangleWithColor(string color)
        {
            return null;
        }

        // Minden téglalapon kívüli szöveg felsorolása.
        internal IEnumerable<string> GetTextsOutsideRectangles()
        {
            return null;
        }
        #endregion

        #region Téglalapok egymáshoz képesti viszonya
        // Az egyetlen olyan téglalap pár visszaadása (id attribútumuk értékével), amik legfeljebb
        //  adott távolságra vannak egymástól.
        // (Itt nem gond, ha foreach-et használsz, de jobb, ha nem.)
        internal (string id1, string id2) GetSingleRectanglePairCloseToEachOther(double maxDistance)
        {
            return (null, null);
        }
        #endregion

        #region ILookup és Aggregate használata
        // Egy ILookup visszaadása, mely minden szöveghez megadja az ilyen szöveget tartalmazó
        //  téglalapok színét. (Az ILookup-ban csak azok a szövegek szerepelnek kulcsként, amikhez van
        //  is téglalap.)
        internal ILookup<string, string> GetBoundingRectangleColorListForEveryText()
        {
            return null;
        }

        // Minden téglalapon belüli szöveg ABC sorrendben egymás mögé fűzése, ", "-zel elválasztva.
        //  (Az "OrderBy(s=>s)" rendezése most elegendő lesz.)
        // Használd az Aggregate Linq metódust egy StringBuilderrel az összegyűjtéshez!
        internal string ConcatenateOrderedTextsInsideRectangles()
        {
            return string.Empty;
        }

        // Az adott kontúrszélességű (stroke width) téglalapok által együttesen lefedett terület
        //  szélességét és magasságát adja meg
        internal (double Width, double Height) GetEffectiveWidthAndHeight(int strokeThickness)
        {
            return (Width: 0, Height: 0);

        }
        #endregion
        #endregion

        #region Segédmetódusok
        // Ezeknek a metódusoknak az implementálása nem kötelező, csak ajánlás.
        //  Ezekre a funkciókra lehet, hogy többször is szükséged lesz a feladatok
        //  megoldása során, így érdemes őket kiszervezni külön metódusokba.
        class Boundary
        {
            public double Left = double.MaxValue;
            public double Top = double.MaxValue;
            public double Right = double.MinValue;
            public double Bottom = double.MinValue;

            public double Width => Right - Left + 1;
            public double Height => Bottom - Top + 1;

            public void UpdateToCoverRect(XElement rect)
            {
                Left = Math.Min(Left, rect.GetX());
                Right = Math.Max(Right, rect.GetX() + rect.GetWidth() - 1);
                Top = Math.Min(Top, rect.GetY());
                Bottom = Math.Max(Bottom, rect.GetY() + rect.GetHeight() - 1);
            }
        }

        // A kapott rect magassága legalább kétszer akkora, mint a szélessége?
        private bool IsAtLeastTwiceAsHighAsWide(XElement rect)
        {
            return false;
        }

        // A this.Rects attribútumból felsorolja azokat az elemeket, melyek kitöltési színe a megadott szín.
        private IEnumerable<XElement> GetRectanglesWithColor(string color)
        {
            return null;
        }

        // Igaz, ha a megadott pont a rect-en belül van.
        //  Használhatod a lentebb megírandó GetRectBoundaries-t.
        private bool IsInside(XElement rect, (double x, double y) p)
        {
            return false;
        }

        // Igaz, ha a két téglalap (r1 és r2) között a távolság egyik tengely
        //  mentén sem nagyobb, mint maxDistance.
        private bool AreClose(XElement r1, XElement r2, double maxDistance)
        {
            return false;
        }

        // Visszaadja egy téglalap határait. Figyelem! Ha left==2 és width==3,
        //  akkor right==4 és nem 5! Hasonlóan a magasságra is.
        private (double left,double top,double right,double bottom) GetRectBoundaries(XElement r)
        {
            return (0,0,0,0);
        }
        #endregion
    }
}
