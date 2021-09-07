# KonzolosHelloWorld laboratórium

Ennek a labornak a célja egy első C# alkalmazáson keresztük a tantárgy kereteiben használt infrastruktúra megismerése.

A labor során intenzíven fogjuk használni a git-et, így ha már nem rémlik, hogyan kell githubra belépni, klónozni egy repositoryt, a commit és push műveletek, akkor nézd át az ehhez kapcsolódó, kiadott online anyagokat. Még jobb, ha ezt a gyakorlatot is elvégzed:
http://bmeaut.github.io/snippets/snippets/0139_GitGyakorlat/

## Felkészülés a mérésre

Ehhez a laborhoz nagyon részletes videó útmutató tartozik, melyeket kérünk, hogy előre nézz meg!
(Lásd Moodle)

## 1. feladat: classroom.github.com

Hozd létre a saját repositorydat, amit a félév során fogsz használni!
GitHub classroom invitation URL a Moodleben szerepel.

## 2. feladat: git clone, labor megoldás elkezdése

- Klónozd a repositorydat a laborgépre a Visual Studio alatt.
- Hozz létre a master branch mellé egyet, amire a mostani laboron fogsz dolgozni LAB01 néven. A labor végén a pull requestben ennek az eltérését fogod majd beadni a master branchhez képest.
- Nyisd meg a kiadott keretprogramot.
- A továbbiakban mindig a saját repositoryda dolgozz! Még akkor is, ha a start nevű repositoryban nézed esetleg a leírást. Abba nem fogsz tudni push-olni.

## 3. feladat: kész kód áttekintése, debug feladat

- Futtasd le a kiadott programot és tekintsd át a futás eredményét és a program működését.
- Próbáld ki az alapvető debug funkciókat: töréspont elhelyezése, törlése, futtatás a töréspontig, soronkénti léptetés, tovább futtatás, változók nevének megtekintése.

## 4. feladat: kódolás, debug funkciók

- Egészítsd ki az alkalmazást úgy, hogy prímszámok összegét is ki tudja írni! A videóval ellentétben most ne a prímszámok darabszámát, hanem összegét határozd meg.
- Futtasd lépésenként a programot a debugger segítségével.
- Ha működik a megoldás, commitold (állítsd be a gitignore fájlt, hogy csak a forrásfájlokat commitolja), pushold githubra.

Egy visual studio projektben amiket NEM verziókövetünk: .vs, .obj, .bin és packages könyvtárak tartalma, .user fájlok.

## 5. feladat: unit teszt készítése

- A már elkészített unit teszthez hasonlóan készíts egy újat (mehet ugyanabba az osztályba), mely a prímszámok összegének meghatározását teszteli!
- Futtasd le a unit teszteket a Test Explorerben, hogy minden zöld-e.

## 6. feladat: pull request létrehozása

- A github webes felületén hozz létre egy pull requestet.

## 7. szorgalmi feladat: fejléc dekoráció

- Kiegészítő feladatként készíts egy újabb decoratort, ami ezúttal nem egy kis keretet ír a kiírt szöveg köré, hanem egy több soros fejlécet azzal, hogy ez az EViP tárgy első laborfeladatának designos megoldása.
- Commit és push után nézd meg, hogy a github webes felületén a pull request tényleg magától frissült-e.
