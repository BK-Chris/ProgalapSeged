# Programozási tételek

Segédanyag az ***IK-19fszPAEG** (2024/25/1)* [ELTE](https://www.inf.elte.hu/) tantárgyához.

- [Specifikáció Készítő](https://progalapfsz.elte.hu/specifikacio/)
- [C# leírás angol nyelven (tutorialspoint)](https://www.tutorialspoint.com/csharp/index.htm)

*Forrás: órai anyag*

A specifikációban, pszeudokódban az indexelés 1-től kezdődik, C# kódban 0-tól!
                                                            
>## Tartalom
>
>- [Specifikáció kisokos](#specifikáció-kisokos)
>- [Alapvető proramozási tételek](#alapvető-programozási-tételek)
>    - [Összegzés](#összegzés)
>    - [Megszámolás](#megszámolás)
>    - [Maximum kiválasztás](#maximum-kiválasztás)
>        - [Minimum kiválasztás](#minimum-kiválasztás)
>    - [Feltételes maximum keresés](#feltételes-maximum-keresés)
>    - [Keresés](#keresés)
>    - [Eldöntés](#eldöntés)
>       - [Mind eldöntés](#mind-eldöntés)
>    - [Kiválasztás](#kiválasztás)
>    - [Másolás](#másolás)
>    - [Kiválogatás](#kiválogatás)

## Specifikáció kisokos

#### Jelzések
| Jelek | Jelentése |
| :---: | :--- |
| ∈ | eleme |
| ∀ | minden |
| ∃ | létezik |
| L | logikai |
| R | valós |
| N | természetes |
| Z | Egész |
| S | Szöveg |

- **Tömb:** elemek∈N[1..10], elemek∈STRUKTÚRA[0..9]
- **Struktúra:** STRUKTÚRA=(ELSOELEM:S x MASODIKELEM:N)
- **T(elem)**: Valamilyen tulajdonságú elem. Ez lehet egy függvény valamilyen visszatérési értékkel vagy egy logikai állítás is például *elemek[i] > 0.*
- **f(elem)**: Valamilyen függvény valamilyen visszatérési értékkel.

#### Gyakori beépített függvények
```
osszegzes = SZUM(i=1..elemszám,elemek[i])
darab = DARAB(i=1..elemszám,T(elemek[i]))
(maxIndex,maxÉrték) = MAX(i=1..elemszám, T(elemek[i])) 
(minIndex,minÉrték) = MAX(i=1..elemszám, T(elemek[i]))
(van,maxIndex,maxÉrték) = MAXHA(i=1..elemszám,elemek[i],T(elemek[i]))
(van,minxIndex,minÉrték) = MINHA(i=1..elemszám,elemek[i],T(elemek[i]))
(van,index) = KERES(i=1..elemszám,T(elemek[i]))
van = VAN(i=1..elemszám,T(elemek[i]))
mind = MIND(i=1..elemszám,T(elemek[i]))
index = KIVÁLASZT(i>=1,T(elemek[i]))
tömb = MÁSOL(i=1..elemszám, f(elemek[i]))
(újElemszám,újTömb) = KIVÁLOGAT(i=1..elemszám, T(elemek[i]))
```

**Megjegyzés:** Ahol több visszatérési érték van, lehet így is használni: **(,minÉrték)=MAX(i=1..elemszám, T(elemek[i]))** ha például csak az értékre vagyunk kíváncsiak.

#### Saját függvény
```
Fv: függvénynév:TÍPUS->TÍPUS,           // Deklaráció egy bemenő paraméterrel
    függvénynév(PARAMÉTER1)=(/* Függvény leírása */)

Fv: függvénynév:TÍPUS x TÍPUS->TÍPUS,   // Deklaráció több paraméterrel
    függvénynév(PARAMÉTER1,PARAMÉTER2)=(/* Függvény leírása */)
```
#### Specifikáció struktúra
**Ezek sorrendje nem felcserélhető!**
```
Be: // Bemenet
Sa: // Segédváltozó
Ki: // Kimenet
Fv: // Függvény
Fv: // További függvény
Ef: // Előfeltétel
Uf: // Utófeltétel
```
----

## Alapvető programozási tételek

### Összegzés

Ezt az algoritmust akkor alkalmazzuk, amikor több elem összegét szeretnénk meghatározni.

**Példa:** Hány gyerek jár egy iskolában, ha tudjuk az osztályok létszámát?
**Specifikáció** [LINK](https://tinyurl.com/yfx8r9mx)
```
Be: db∈N, osztalyok∈N[1..db]
Ki: osszesdiak∈N
Ef: db > 1
Uf: osszesdiak = SZUM(i=1..db,osztalyok[i])
```
**Visszavezetés**
```
össz        ~   osszesdiak
1..elemszám ~   1..db
elemek[i]   ~   osztalyok[i] 
```
**Pszeudokód**
```
i:Egész
osszesdiak:= 0
Ciklus i = 1 -től db-ig
    osszesdiak = osszesdiak + osztalyok[i]
Ciklus vége
Ki: osszesdiak
```
**C# algoritmus**
```csharp
int Osszegzes(ref int[] elemek)
{
    int ossz = 0;
    for (int i = 0; i < elemek.Length; i++)
    {
        ossz += elemek[i];
    }
    return ossz;
}
```
---
## Megszámolás
Ezt az algoritmust akkor alkalmazzuk, amikor össze szeretnénk gyűjteni hány darab valamilyen(T) tulajdonságú elem van például egy tömbben.

**Példa:** Hányszor fagyott a hőmérsékleti adatok alapján?
**Specifikáció**  [LINK](https://tinyurl.com/ycxf8xky)
```
Be: db∈N, homersekletiAdatok∈R[1..db]
Ki: fagyottNapok∈N
Ef: db > 0 és ∀ i∈[1..db]:(-89 <= homersekletiAdatok[i] <= 58)
Uf: fagyottNapok = DARAB(i=1..db,homersekletiAdatok[i] < 0)
```
**Visszavezetés**
```
1..elemszám    ~   1..db
T(elemek[i])   ~   homersekletiAdatok[i] < 0
```
**Pszeudokód**
```
i:Egész
fagyottNapok = 0
Ciklus i = 1 -től db-ig
    Ha (homersekletiAdatok[i] < 0) akkor
        fagyottNapok = fagyottNapok + 1
    Elágazás vége
Ciklus vége
Ki: fagyottNapok
```
**C# algoritmus**
```csharp
int darab = 0;
for (int i = 0; i < elemek.Length; i++)
{
    if (elemek[i] < 0)
    {
        darab++;
    }
}
return darab;
```
---
## Maximum kiválasztás
Gyakran kell a maximum illetve minimum érték programozás során, ezekkel az algoritmusokkal tudjuk megtalálni őket. A maximum és minimum kiválasztás között csak a logikai feltétel a különbség. Néha az index-re (a tömbnek a hányadik elemére), néha pedig az értékére vagy mindkettőre, algoritmuson nem változtat csak a kimeneten.
**Példa:** Mennyi a legalacsonyabb illetve legmagasabb ember magassága?
**Specifikáció** [LINK](https://tinyurl.com/3asmfjnb)
```
Be: db∈N, emberek∈EMBER[1..db], EMBER=(nev:S x magassag:N)
Ki: maxért∈N
Ef: db > 0 és ∀ i∈[1..db]:(100 <= emberek[i].magassag <= 250)
Uf: (,maxért)=MAX(i=1..db, emberek[i].magassag)
```
**Visszavezetés**
```
maxind, maxért ~   maxért
1..elemszám    ~   1..db
elemek[i]      ~   emberek[i].magassagok
```
**Pszeudokód**
```
i:Egész
maxért = emberek[1].magassag
Ciklus i = 2 -től db-ig
    Ha (emberek[i].magassag > maxért) akkor
        maxért = emberek[i].magassag
    Elágazás vége
Ciklus vége
Ki: maxért
```
**C# algoritmus**
```csharp
int maxErtek = emberek[0].magassag;
for (int i = 1; i < emberek.Length; i++)
{
    if (emberek[i].magassag > maxErtek)
    {
        maxErtek = emberek[i].magassag;
    }
}
return maxErtek;
```
### Minimum kiválasztás
**Specifikáció** [LINK](https://tinyurl.com/3mu5zm4b)
```
Be: db∈N, emberek∈EMBER[1..db], EMBER=(nev:S x magassag:N)
Ki: minért∈N
Ef: db > 0 és ∀ i∈[1..db]:(100 <= emberek[i].magassag <= 250)
Uf: (,minért)=MIN(i=1..db, emberek[i].magassag)
```
**Visszavezetés**
```
minind, minért ~   minért
1..elemszám    ~   1..db
elemek[i]      ~   emberek[i].magassag
```
**Pszeudokód**
```
i:Egész
minért = emberek[1].magassag
Ciklus i = 2 -től db-ig
    Ha (emberek[i].magassag < minért) akkor
        minért = emberek[i].magassag
    Elágazás vége
Ciklus vége
Ki: minért
```
**C# algoritmus**
```csharp
int minErtek = emberek[0].magassag;
for (int i = 1; i < emberek.Length; i++)
{
    if (emberek[i].magassag < minErtek)
    {
        minErtek = emberek[i].magassag;
    }
}
return minErtek;
```
---
## Feltételes maximum keresés
Ez az algoritmus gyakorlatilag a keresés illetve maximum kiválasztás kombinációja.
**Példa:** Adjuk meg a legmelegebb fagyos napot.
**Specifikáció** [LINK](https://tinyurl.com/2knb52vp)
```
Be: db∈N, homersekletek∈R[1..db]
Ki: van∈L,maxind∈N,maxert∈R
Ef: db > 0 és ∀ i∈[1..db]:(-89 <= homersekletek[i] <= 58)
Uf: (van,maxind,maxert) = MAXHA(i=1..db,homersekletek[i],homersekletek[i] < 0)
```
**Visszavezetés**
```
1..elemszám    ~   1..db
elemek[i]      ~   homersekletek[i]
T(elemek[i])   ~   homersekletek[i] < 0
```
**Pszeudokód**
```
i:Egész
van = hamis
Ciklus i = 1 -től db-ig
    Ha (homersekletek[i] < 0)
       Ha (van) akkor
           Ha (homersekletek[i] > maxert)
               maxind = i
               maxert = homersekletek[i]
           Elágazás vége
       különben
           van = igaz
           maxind = i
           maxert = homersekletek[i]
       Elágazás vége
   Elágazás vége
Ciklus vége
Ki: (van, maxind, maxert)
```
**C# algoritmus**
```csharp
bool van = false;
int maxind = -1;
double maxert = -1;
for (int i = 0; i < homersekletek.Length; i++)
{
    if (homersekletek[i] < 0)
    {
        if (van)
        {
            if (homersekletek[i] > maxert)
            {
                maxind = i;
                maxert = homersekletek[i];
            }
        }
        else
        {
            van = true;
            maxind = i;
            maxert = homersekletek[i];
        }
    }
}
return (van, maxind, maxert);
```
---
## Keresés
Kereséskor általában az indexre vagyunk kíváncsiak és a legtöbb nyelvben ha nincs érték -1 érték szokott lenni a visszatérési érték. Specifikációban készítő egy logika (van/nincs) és az indexet adja vissza.
**Példa:** Volt-e 20C° a korábbi hőmérsékleti adatainkban?
**Specifikáció** [LINK](https://tinyurl.com/mryw2srf)
```
Be: db∈N, homersekletek∈R[1..db]
Ki: van∈L, index∈Z
Ef: db > 0 és ∀ i∈[1..db]:(-89 <= homersekletek[i] <= 58)
Uf: (van,index) = KERES(i=1..db,homersekletek[i] = 20)
```
**Visszavezetés**
```
ind            ~   index
1..elemszám    ~   1..db
T(elemek[i])   ~   homersekletek[i] = 20
```
**Pszeudokód**
```
i:Egész
i=1
van=hamis
index=-1
Ciklus amíg i <= db és homersekletek[i] != 20
   i = i + 1
Ciklus vége
Ha i < db akkor
    index:= i
    van:= igaz
Elágazás vége
Ki: (van, index)
```
**C# algoritmus**
```csharp
int i = 0;
bool van = false;
int index = -1;
while ((i < homersekletek.Length) && homersekletek[i] != 20)
    i++;
if (i != homersekletek.Length)
{
    van = true;
    index = i;
}
return (van, index);
```
---
## Eldöntés
**Példa:** Döntsük el hogy 7417 prímszám-e!
**Specifikáció** [LINK](https://tinyurl.com/3rpzz49s)
```
Be: szam∈Z
Ki: primszam∈L
Ef: szam > 2
Uf: primszam != VAN(i=2..szam-1,szam % i = 0)
```
Megj.: Specifikációban nem tudom hogyan kell jelölni, de elég a kért szám gyökéig elszámolni, enélkül is müködik csak fölösleges iterációkat fut le.`

**Visszavezetés**
```
van            ~   primszam
1..elemszám    ~   2..szam-1
T(elemek[i])   ~   i mod szam = 0
```
**Pszeudokód**
```
i:Egész
primszam: hamis
Be:szam
i=2
Ciklus amíg (i <= szam-1 és szam mod i != 0)
   i = i + 1
Ciklus vége
Ha (i > szam-1) akkor
   primszam = igaz
Elágazás vége
Ki: primszam
```
**C# algoritmus**
```csharp
int szamGyoke = (int)Math.Sqrt(szam);
int i = 2;
while (i <= szamGyoke && szam % i != 0)
    i++;
return (i > szamGyoke);
```
---
### Mind eldöntés
**Példa:** Maradva az előző prímes példánál, döntsük el hogy egy tömb elemei mind prímszám-e vagy sem!
**Specifikáció** [LINK](https://tinyurl.com/mrmkxff)
```
Be: db∈N, szamok∈N[1..db]
Ki: mind∈L
Ef: ∀ i∈[1..db]:(szamok[i] > 2)
Uf: mind = MIND(i=1..db,(VAN(j=2..szamok[i]-1,szamok[i] % j = 0) = hamis))
```
**Visszavezetés**
```
van            ~   mind
1..elemszám    ~   1..db
T(elemek[i])   ~   PrimszamE(szamok[i])
```
**Pszeudokód**
```
i:Egész
mind: hamis
i=1
Ciklus amíg (i != db és PrimszamE(szamok[i] = igaz))
   i = i + 1
Ciklus vége
Ha (i == db) akkor
   mind = igaz
Elágazás vége
Ki: mind

Függvény PrimszamE(szam: Egész):Logikai
    j:Egész
    prim: hamis
    j=2
    Ciklus amíg (j <= szam-1 és szam mod j != 0)
        j = j + 1
    Ciklus vége
    Ha (j > szam-1) akkor
        primszam = igaz
    Elágazás vége
    PrimszamE:= prim
Függvény vége
```
**C# algoritmus**
```csharp
int i = 0;
bool mind = false;
while (i < szamok.Length && PrimszamE(szamok[i]))
    i++;
if (i == szamok.Length)
{
    mind = true;
}
return mind;
```
---
## Kiválasztás
Kiválasztásnál ***tudjuk***, hogy létezik az elem, ezért előfeltétel, hogy létezen az adott elem.
**Példa:** Magyarkártyáknál kíváncsiak vagyunk egy adott kártya értékére.
**Specifikáció** [LINK](https://tinyurl.com/yz56hxh6)
```
Be: kártya∈S, kártyák∈S[1..8]=["VII", "VIII","IX","X","Alsó","Felső","Király","Ász"], értékek∈N[1..8]=[7,8,9,10,2,3,4,11]
Ki: érték∈N, ind∈N
Ef: létezik i eleme [1..8]: (kártya = kártyák[i])
Uf: ind=KIVÁLASZT(i>=1,kártya=kártyák[i] és érték=értékek[ind])
```
**Visszavezetés**
```
ind              ~   i
T(elemek[ind])   ~   kártya=kártyák[i] és érték=értékek[ind] 
```
**Pszeudokód**
```
i: egész
i:= 1
Ciklus amíg (Kártyák[i] != kártya)
     i := i + 1
Ciklus vége
Ha i > kártyák.hossz akkor
    Ki: -1, -1
különben
    Ki: i, Kártyák[i]
Elágazás vége
```
**C# algoritmus**
```csharp
int i = 0;
while (i < kartyak.Length && kartyak[i] != kartya)
    i++;

if (i == kartyak.Length)
    return (-1, -1);
else
    return (i, ertekek[i]);
```
`Megj.: Fontos meggyőződni arról, hogy létezik-e a kért elem, különben IndexOutOfRangeException-t dob a programunk!`

---
## Másolás
**Példa:** Szeretnénk a hőmérsékleti adatainkat át konvertálni C° -ból F°-be.
**Specifikáció** [LINK](https://tinyurl.com/5n8u8jwt)
```
Be: db∈N,homC∈R[1..db]
Ki: homF∈R[1..db]
Fv: valt:R->R,
    valt(celsius)=(celsius * 9/5 + 32)
Ef: db > 0 és ∀ i∈[1..db]:(-89 <= homC[i] <= 58)
Uf: homF=MÁSOL(i=1..db, valt(homC[i]))
```
**Visszavezetés**
```
fvelemek       ~   homF
1..elemszám    ~   homC[1..db]
f(elemek[i])   ~   valt(homC[i])
```
**Pszeudokód**
```
i: egész
homF[db]: Valós
Ciklus i=1-től db-ig
   homF[i]=(homC[i] * 9/5 + 32)
Ciklus vége
Ki: homF
```
**C# algoritmus**
```csharp
double[] homF = new double[homC.Length];
for(int i = 0; i < homC.Length; i++)
{
    homF[i] = homC[i] * 9/5 + 32;
}
return homF;
```
--
## Kiválogatás
**Példa:** Válogassuk ki a 20C° nagyobb értékeket egy másik tömbbe!
**Specifikáció** [LINK](https://tinyurl.com/4uveverm)
```
Be: elemszam∈N,homC∈R[1..elemszam]
Ki: db∈N,nagyobb20∈R[1..db]
Ef: db > 0 és ∀ i∈[1..db]:(-89 <= homC[i] <= 58)
Uf: (db,nagyobb20)=KIVÁLOGAT(i=1..elemszam, homC[i] > 20,homC[i])
```
**Visszavezetés**
```
kivindexek     ~ nagyobb20
1..elemszám    ~ 1..elemszam
T(elemek[i])   ~ homC[i] > 20
i              ~ i
```
**Pszeudokód**
```
nagyobb20[db]: Valós
i: egész
db: Egész
db = 1
Ciklus i=1-től elemszam-ig
   Ha (homC[i] > 20) akkor
        nagyobb20[db] = homC[i]
        db = db + 1
    Elágazás vége
Ciklus vége
Ki: nagyobb20
```
**C# algoritmus**
```csharp
double[] nagyobb20 = new double[homC.Length];
int db = 0;
for (int i = 0; i < homC.Length; i++) 
{
    if (homC[i] > 20)
    {
        nagyobb20[db] = homC[i];
        db++;
    }
}
return nagyobb20;
```
#### **[FEL](#programozási-tételek)**