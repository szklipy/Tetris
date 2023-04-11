# Tetris

## Ötlet
lehetne a pálya pl ilyen
2:a pálya széle
0,1 a pályán belül lehet. 0 az üres blokk, 1 a teli blokk, ha egy sorban csak 1 esek vannak, akkor 
lehet a sort törölni! :D	 a spawn point az a felső kettő sorban van, ha odafér a forma

200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
200000000002
222222222222

## Roadmap

v1.0	-	"szabad lábon"
tudjon mozogni minden irányban és az esc gomb megnyomásával bármikor ki tudjon lépni a játékból

v1.1.1	-	"börtönbe zárva"
a ne használj console.cleart és úgy legyen jó!	amikor lefele mozog--> a felsőt letörli és alúlra rak egy kockát
v1.1.2
ne tudjon kimenni a konzolról!, ne jelezzen ki hibát!

v1.2.1	-	"a pálya"
legyen egy megadott méretű pálya(20*10) amin belül mozog a forma, a pálya széle körül legyen '#'-t
(csak a pálát kell elősször elkészíteni, ha megvan, akkor mehet majd a forma is bele)

v1.3.1	-	"első pár szabály"
a megadott pozícióba "spawnoljon" a forma (középen felül)--> pontosabban: a felső 2 sorban
v1.3.2
csak jobbra, balra és lefele tudjon mozogni
v1.3.3
ha leért a pálya aljára akkor ne tudjon tovább mozogni

v1.4.1	-	"pre-alfa"
ha leért a pálya aljára, akkor spawnoljon egy újabb forma
v1.4.2
addig "spawnoljon" újabb forma, amíg el nem éri egy forma a "spawn pont" határát
v1.4.2
ha elérte a határt, akkor írja ki, hogy "game over!"
v1.4.3
és kérdezze meg, hogy akar e játszani egy újat, vagy nem
v1.4.4
ha igen, akkor a consolt takarítsa le és indítsa újra a "játékot"
v1.4.5
ha nem, akkor lépjen ki

v1.5.1	-	"hoppá, már el tűnnek a sorok!"
készítsd el, hogy ha egy sor minden pontjában van egy "kocka", akkor az a sor eltűnjön
v1.5.2
miután eltűnt, az összes elem le egy annyi blokkot ahány sor eltűnt! 

v1.6.1 	-	"pontrendszer"
készíts egy pontszámláló rendszert! a szabályoknak megfelelően
10 pont egy forma elhelyezése, 100 pedig ha egy egész sort eltüntet.
v1.6.2
a pontokat valós időben ki is írja a pálya mellett
v1.6.3
ha vége a játéknak a "game over" még a pontszámot is kiírja, pl.: Pontszám:6543

v1.7	-	"új rabok érkeztek"
készítsd el az összes többi elemet a játékhoz!

v1.8	-	"forog a világ"
legyenek a formák forgathatók!

(kozmetika)
v1.9	-	készíts egy menü rendszert