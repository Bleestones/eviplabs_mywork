# Linq to XML lekérdezés labor (kódnév: Linq2XmlSvgLab)

Az előzetes felkészüléshez az alábbi anyagokat tekintsd át:

- Videó a Moodle alatt.
- Linq dokumentáció: https://docs.microsoft.com/en-us/dotnet/csharp/linq/
- A code review labor feladathoz: .NET C# coding guides (MS), lásd a leírásban.

Ennek a labornak a célja a Linq to XML lekérdezések gyakorlása. Ehhez első körben kell egy adathalmaz, amire
utána a lekérdezésekkel megválaszolandó feladatok vonatkoznak. A szemléletesség kedvéért kihasználjuk, hogy az
SVG vektorgrafikus képformátum egy XML fájl, így a lekérdezések színes téglalapok és feliratok tulajdonságaira
fognak vonatkozni.

## A fájlok

- README.md: ez a leírás
- Solutions.cs: ebbe kell elkészíteni a megoldásokat. A feladatok valójában itteni metódusok, így ezek
fejlécéből és az előtte álló kommentárokból derül ki, mik is a tényleges feladatok.
- TaskTests.cs: a megoldásokat ellenőrző unit tesztek. Nevük megegyezik a tesztelt metódus nevével.
- ExtensionMethods.cs: bizonyos funkciók sokkal kényelmesebben használhatók, ha extension methodként
írjuk meg őket, amihez egy statikus osztály kell. Amit így szeretnél elkészíteni, annak itt van az előre
előkészített helye.
- rectangles1.svg, rectangles2.svg: XML alapú, vektorgrafikus kép, amire a unit tesztek az elkészült megoldás helyességét
tesztelik.
- rectangles1.png, rectangles2.png: PNG képként a megfelelő SVG fájlok tartalma, hátha van, akinek így könnyebb megnézni.

## A labor elvégzésének lépései

(A labor elején, már most hozz létre egy új branchet és utána azon dolgozz, hogy a pull requestet könnyű legyen majd a labor végén létrehozni! És ha az egyetemen kezdted el a munkát, mielőtt elmész, ne felejtsd el felpusholni a változásokat a laborgépről a githubra!)

- Nézd meg a projektben lévő SVG fájlok és a mellékelt PNG megfelelőik tartalmát. Milyen attribútumok
tartalmazzák például egy téglalap szélességét és a kontúr vonalvastagságát? Az id, x, y, width, height és style
attribútumokra szükség lesz a feladatok megoldása során.
- Nézd meg a példa Linq to XML lekérdezéseket a
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-queries-linq-to-xml
oldalon.
- A labor feladatainak megoldását a Solutions.cs osztály metódusaiban készítsd el. A feladatok rövid leírása
is ezen metódusok előtt szerepel a forráskódban. A metódusok helyes működését a
TasksToComplete unit tesztjei ellenőrzik. Természetesen a kód duplikáció elkerülése érdekében a Solutions
osztályban tetszőleges további segéd metódusokat is létrehozhatsz. Ugyanazt a szűrést ne írd le kérszer!
(Ajánlásként kommentárba felsoroltam pár metódust, amit jó eséllyel megéri elkészíteni. Ha van kedved,
szorgalmi feladatként ezek elkészítése előtt kifejezetten ezeket ellenőrző, további unit teszteket is
készíthetsz.)
- Mivel most Linq alapú lekérdezéseket kell majd írni, a ciklusok (while, for, foreach) mind code smellnek
minősülnek: valószínűleg arra utalak, hogy a megoldásod nem teljesen "Linq-es", ezért amikor csak lehet, került
el őket.
- A Linq-es kifejezések egy csomó lépést egymás után hajtanak végre, amit debuggolni elég nehéz. Debug
célokra ideiglenesen nyugodtan vezess be változókat, de a debugger az IEnumerable értékeit is össze tudja neked gyűjteni, csak húzd rá az egeret a változóra.
(Az IEnumerable végére ha lehet, ne tegyél .ToArray() hívást még ideiglenesen se, mert úgy marad és később igen komoly
teljesítmény gondokat, rengeteg másolgatást okozhat. Adatbázis kapcsolat esetén pedig még több gond lehet vele.)
- A fejlesztés során amint valami helyesen működik, a megfelelő unit teszt zölddé válik. Érdemes bekapcsolni
a Live Unit Testinget, mivel akkor nem kell mindig kézzel futtatgatni a unit teszteket.
- A munka során törekedj a kód duplikáció elkerülésére, ami azt is jelentheti, hogy egy korábban már elkészített 
feladatot kis mértékben módosítani kell, hogy például egy másikkal közös metódust használjon. A cél a végleges
kód duplikáció mentessége, vagyis néha vissza kell emiatt térni korábbi feladatokhoz és refactorálni kell
őket. Ez ipari környezetben is így van.

## Tippek, trükkök, kiegészítések a laborhoz a korábbi tapasztalatok alapján

- Annak eldöntésére, hogy egy szöveg egy téglalapban van-e, érdemes egy IsInside segédmetódust készíteni, ami a text x és y pozíciójára (a szöveg bal alsó sarka az SVG formátumnál) eldönti, hogy az a téglalapon belül van-e.
- Ezen a laboron egyre inkább előjön, hogy konzolra kiírásokkal és erős ránézéssel debuggolni egyre nehezebb. Használjátok a töréspontokat és a debuggert, mert nélküle olyan, mintha főzni akarnátok fakanál nélkül. Lehet, de nem érdemes.
- Az extension method lényege, hogy nem csak pl. "ExtensionMethods.GetHeight(rect)"-ként lehet meghívni, hanem "rect.GetHeight()"-ként is! Ettől lesz extension method.
- Ha valahol a double.Parse metódust használod, 2. paraméterként add meg a "CultureInfo.InvariantCulture"-t.
Így a Windows beállításoktól függetlenül a "." lesz a tizedespont. Magyar esetén "," lenne, ami nagyon bekavarhat.
- Ha a "rect" változó már egy konkrét téglalapra hivatkozik, akkor úgy tudom ellenőrizni, hogy a vonalvastagsága "width"-e, hogy rect.Attribute("style").Value.Contains($"stroke-width:{width}"). Először lekérem a style nevű attribútumot (érdemes belenézni az SVG fájlba, hogy minek milyen attribútumai vannak és abban milyen értékek lehetnek), aztán ennek az értéke kell, amire megvizsgáljuk, hogy szerepel-e benne egy string, amit pedig a $ kezdetű string interpolationnal írunk le, ahol behelyettesítődik a width értéke.

## A labor végére kiegészítő feladatok

Ha maradt még időd, nézd meg a GroupBy Linq metódus dokumentációját és készíts egy feladatot (unit teszttel) és
hozzá megoldást a GroupBy használatával.
