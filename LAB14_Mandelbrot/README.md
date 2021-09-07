# Mandelbrot Laboratórium

A laborra való felkészülést Moodle alatti videók segítik. (A videókon a mintamegoldás forráskódján keresztül mutatom ba a működést, a labor végére ehhez hasonló eredményt kell kapni.)

# A konkrét labor feladatok

(A labor elején, már most hozz létre egy új branchet és utána azon dolgozz, hogy a pull requestet könnyű legyen majd a labor végén létrehozni! És ha az egyetemen kezdted el a munkát, mielőtt elmész, ne felejtsd el felpusholni a változásokat a laborgépről a githubra!)

(E-mail érkezik az EViP Technologies vezetőségétől, a MandelbrotFavorites alkalmazásunk Product Ownerétől. A megolásnál figyelj rá, hogy ne a ShowFixedMandelbrot projektet indítsd el, hanem a MandelbrotFavorites-et.)

Kedves Kolléga!

Megrendelőink nagyon elégedettek a MandelbrotFavorites alkalmazással, de találtak benne néhány apróságot, amit szeretnék, ha módosítanánk, kiegészítenénk.
Kérlek, te, mint az alkalmazás egyik fő fejlesztője, végezd el a kért módosításokat! Remélem, minden fontosat leírtak, ennél többet nem sikerült kicsikarni belőlük. :(

Üdvözlettel,
Andezit Xenon,
Product Owner

----------

Kedves Andezit Xenon,

köszönjük a legutóbbi releaset, mindenkinek nagyon tetszett. A hétvégi demózáshoz még az alábbi módosításokat szeretnénk kérni. Remélem, nem gond...

Üdvözlettel,
Vas Mangán

## Apró UI kérések

- Nyomógombok sorrendjének változtatása: Re-render, Add to favorites, Update current favorite...
- Hotkey hozzáadások (amely nyomógomb nevében van (...), ott legyen az a betű hotkey is)
- Tooltip hozzáadása az újra renderelő nyomógombhoz: "Re-renders the main view, shortcut: R"
- Ahol megjelenik az éppen megjelenített részlet koordinátája, ott a "-1.2+i-1.3" formátum nem helyes. Az "i" legyen az imaginárius tag után.

## Kicsit nagyobb feladatok

- Thumbnail megjelenítése minden kedvenchez. A felirata (koordinátái) előtt jelenjen meg egy 50x50-es kép (Image). (Mintha a fejlesztőtök azt mondta volna, hogy a view model "Thumbnail" néven már tartalmazza és csak valami Image.ImageSource-nak kell beállítani.)
- Mentés/betöltés fájlból (lehet, hogy az egyik meg van írva és a másik hiányzik... lényeg, hogy mindkettő kellene)

## Kedvencek törlése

Nagyon jó ez a "kedvencek" funkció, csak nem lehet őket törölni. Tudnátok egy olyan nyomógombot is készíteni, ami az éppen kijelölt kedvencet törli a listáról? Ehhez egyik kollégám írt pár technikai tippet, ide másolom őket, mert én nem értem...

"Szia Mangán! Szólj nekik, hogy kellene egy MainViewerViewModel.RemoveFavoriteCommand a többi mellé. Ezeket a konstruktor példányosítja. Maga a command meg majdnem olyan, mint az UpdateFavoriteCommand. Ja és kell hozzá egy nyomógomb a MainViewer.xaml-be."

## További feladat lehetőségek

A fennmaradó időben további feladat lehetőség:

- Nyomógombokra piktogrammok készítése: piktogrammokat keress a neten vagy akár a Visual Studioban is lehet rajzolni.
