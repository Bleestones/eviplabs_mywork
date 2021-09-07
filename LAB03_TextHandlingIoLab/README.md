# Szövegkezelés és I/O labor

Ennek a labornak a célja a .NET szövegkezelésével, azon belül is elsősorban a reguláris kifejezés támogatással való megismerkedés.

Feltételezzük, hogy korábbi tanulmányaitokból olyan metódusokat már ismertek, mint amivel meg lehet vizsgálni, hogy egy string azzal kezdődik-e, hogy "Hello". Ha mégsem, akkor itt a .NET eszköztára erre: [String methods](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

A reguláris kifejezés egy olyan, bizonyos szintaktikai szabályok szerint leírt string, amivel meghatározható stringek egy halmaza. Segítségével könnyedén tudunk szövegrészleteket keresni vagy megvizsgálni, hogy egy adott szövegrészlet egy szabálynak megfelel-e. Például érvényes telefonszám vagy e-mail cím-e.

# Felkészülés a laborra

A felkészülés során az alábbi anyagokat tekintsd át:

- Videók a Moodleben.
- [Reguláris kifejezések C# segítségével](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2)
- Tekintsd át a kiinduló forráskódot. A unit tesztekben szerepelnek kommentárok és tippek, valamint ezek ellenőrizik a megoldásaid helyes működését. A megoldások mind a Solutions.cs fájlba kerülnek majd.

# A labor feladatok

(A labor elején, már most hozz létre egy új branchet és utána azon dolgozz, hogy a pull requestet könnyű legyen majd a labor végén létrehozni! És ha az egyetemen kezdted el a munkát, mielőtt elmész, ne felejtsd el felpusholni a változásokat a laborgépről a githubra!)

A labor feladat unit tesztek formájában adott. A projekt futtatható alkalmazást nem is tartalmaz, a cél a unit tesztek bezöldítése (csak a Solutions.cs fájlba dolgozz).

A feladatokat a Solutions.cs fájlban szereplő sorrendben érdemes elkészíteni.
Minden elkészítendő metódushoz vannak unit tesztek (lásd Test Explorer), amiben tippek is szerepelnek, hogy hogyan kell megoldani őket.
A cél a unit tesztek bezöldítése (anélkül, hogy a unit teszteket módosítanád. :) ).

Az egyes feladat csoportok az alábbiak (lásd unit teszt csoportok), a javasolt sorrendben:
- EmailTests: e-mail címek felismerése
- PhoneNumberTests: telefonszámok felismerése
- MusicBoxTests: a "Mi van a zenedobozban?" játék, leírása a unit tesztek elején. Csoportos kitalálós játék. Akik még nem ismerik, azoknak példák alapján rá kell jönnie a szabályra, amivel eldől, hogy valami benne van-e a zenedobozban. Pl. "fűzfák" vannak benne, de "ékszer" nincs.
- PlusCodeTests: A Google által kifejlesztett Plus Code (avagy Open Location Code) felismerése. https://en.wikipedia.org/wiki/Open_Location_Code
- DateTests: pár dátum felismeréssel kapcsolatos feladat, hogy például ne lehessen május 35. (Kivéve itt: https://moly.hu/konyvek/erich-kastner-majus-35)

A legtöbb feladatben először egy stringről kell eldönteni, hogy az-e, amit vizsgáltunk, utána pedig hasonlóan reguláris kifejezéssel egy szövegből kell kigyűjteni az ennek megfelelő részleteket, pl. telefonszámokat.

Bág még később kerül elő, a Soltions.Collect metódus visszatérési értéke IEnumerable<string>. Erről most elég annyit tudni, hogy stringek egy felsorolása, amire ha hívunk egy .ToArray()-t, akkor string[] tömb lesz belőle. Ezt láthatjátok a Solutions.CollectingMatchesExample metódusban is.
