# Programozási tételek

[Főoldal](../readme.md)

> Az alábbi segédanyag az [Eötvös Loránd Tudomány Egyetem](https://www.inf.elte.hu/) - Programtervező Informatikus (FOSZK) - Programozási Alapismeretek (IK-19fszPAEG) - 2024/25/I. félévben oktatott tantárgyához készült.

A képzés során az alapvető programozási tételek, ezek algoritmusának megírásáról és használatukról tanulunk. A képzés során egy [specifikációs szoftver](https://progalapfsz.elte.hu/specifikacio/)t is használunk. A program jelentős segítséget nyújt az elméleti feladatok gyors megoldásában, lehetővé téve, hogy hamarabb áttérjünk az algoritmusok megírására és a kódolásra. Ezen kívül a szoftver lehetőséget biztosít tesztesetek vizsgálatára, amely elősegíti a korai felismerését annak, hogy a megoldás helyes irányba halad-e.

Az itt felsorolt algoritmusok a legtöbb magas szintű programozási nyelvekben kivétel nélkül megtalálhatóak, azonban ezeknek az ismerete és működése nélkülözhetetlen tudás a továbbiakban azok számára akik ezt a pályát választják.

## Tartalom

- [Specifikáció kisokos](#specifikáció-kisokos)
  - [Jelzések](#jelzések)
  - [Gyakori beéptett függvények](#gyakori-beépített-függvények)
  - [Saját függvény készítése](#saját-függvény-készítése)
  - [Specifikáció felépítése](#specifikáció-felépítése)
  - [Egyebek](#egyéb-tudnivalók)
    - [Lambda kifejezések](#lambda-kifejezésekről)
    - [Ternáris kifejezés](#ternáris-kifejezés)
- [Alapvető programozási tételek](#alapvető-programozási-tételek)
  - [Összegzés](#összegzés)
  - [Megszámolás](#megszámolás)
  - [Maximum kiválasztás](#maximum-kiválasztás)
    - [Minimum kiválasztás](#minimum-kiválasztás)
  - [Feltételes maximum keresés](#feltételes-maximum-keresés)
    - [Feltételes minimum keresés](#feltételes-minimum-keresés)
  - [Keresés](#keresés)
  - [Eldöntés](#eldöntés)
    - [Mind eldöntés](#mind-eldöntés)
  - [Kiválasztás](#kiválasztás)
  - [Másolás](#másolás)
  - [Kiválogatás](#kiválogatás)

## Specifikáció kisokos

### Jelzések

| Jelek | Jelentése              |
| :---: | :--------------------- |
|   ∈   | Eleme                  |
|   ∀   | Minden                 |
|   ∃   | Létezik                |
|   L   | Logikai                |
|   R   | Valós szám             |
|   N   | Természetes egész szám |
|   Z   | Egész szám             |
|   S   | Szöveg                 |

- **Tömb:** elemek∈TÍPUS[1..10]
- **Struktúra:** STRUKTÚRA=(ELEM_1:TÍPUS x ELEM_2:TÍPUS)
- **T(elem)**: Valamilyen tulajdonságú elem. Ez lehet egy függvény valamilyen visszatérési értékkel vagy egy logikai állítás is például _elemek[i] > 0._
- **f(elem)**: Valamilyen függvény valamilyen visszatérési értékkel.

### Gyakori beépített függvények

```csharp
// Összegzés
osszeg = SZUM(i=1..elemszám,elemek[i])
```

```csharp
// Megszámlálás
darab = DARAB(i=1..elemszám,T(elemek[i]))
```

```csharp
// Maximum kiválasztás
(maxIndex,maxÉrték) = MAX(i=1..elemszám, T(elemek[i]))
```

```csharp
// Minimum kiválasztás
(minIndex,minÉrték) = MIN(i=1..elemszám, T(elemek[i]))
```

```csharp
// Feltételes maximum kiválasztás
(van,maxIndex,maxÉrték) = MAXHA(i=1..elemszám,elemek[i],T(elemek[i]))
```

```csharp
// Feltételes minimum kiválasztás
(van,minIndex,minÉrték) = MINHA(i=1..elemszám,elemek[i],T(elemek[i]))
```

```csharp
// Keresés
(van,index) = KERES(i=1..elemszám,T(elemek[i]))
```

```csharp
// Eldöntés
van = VAN(i=1..elemszám,T(elemek[i]))
```

```csharp
// Mind eldöntés
mind = MIND(i=1..elemszám,T(elemek[i]))
```

```csharp
// Kiválasztás
index = KIVÁLASZT(i>=1,T(elemek[i]))
```

```csharp
// Másolás
tömb = MÁSOL(i=1..elemszám, f(elemek[i]))
```

```csharp
// Kiválogatás
(kivElemszám,kivElemek) = KIVÁLOGAT(i=1..elemszám, T(elemek[i]))
```

### Saját függvény készítése

```csharp
Fv: függvénynév:TÍPUS->TÍPUS,           // Deklaráció egy bemenő paraméterrel
    függvénynév(PARAMÉTER1)=(/* Függvény leírása */)

Fv: függvénynév:TÍPUS x TÍPUS->TÍPUS,   // Deklaráció több paraméterrel
    függvénynév(PARAMÉTER1,PARAMÉTER2)=(/* Függvény leírása */)
```

### Specifikáció felépítése

**Ezek sorrendje nem felcserélhető!**

```csharp
Be: // Bemenet
Sa: // Segédváltozó
Ki: // Kimenet
Fv: // Függvény
Fv: // További függvény
Ef: // Előfeltétel
Uf: // Utófeltétel
```

### Egyéb tudnivalók

- A specifikáció készítő a nagybetűs függvényneveket, változó neveket nem fogadja el, illetve típusként értelmezi azokat.

---

#### Lambda kifejezésekről

A C# algoritmusban, hogy felhasználható, általánosabb példákat tudjak nyújtani, lambda kifejezéseket használtam, amelyek egyszerű, egy célra használatos függvények.
Ugyan úgy van bemeneti illetve visszatérési értéke mint a normál függvényeknek csak rövidebben leírható.

Bővebb leírást a [Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) oldalán találsz.

**Általánosan:**

```csharp
(paraméterek) => kifejezés
```

**C#-kóddal**

```csharp
Func<int, bool> parosE = elem => elem % 2 == 0;
```

Például a [megszámolás](#megszámolás) specifikációban ilyet használunk csak a parosE helyett függvény helyett a függvény megkapja paraméterként ezt a kifejezést.

```csharp
Megszamolas(elemszam, elemek, (elem) => elem % 2 == 0);
```

#### Ternáris kifejezés

Tulajdonképpen egy if-else kifejezés, egyszerű, kompakt kifejezésekre használjuk, [bővebben](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator).

```csharp
kifejezés ? igaz_ág : hamis_ág;
```

---

## Alapvető programozási tételek

Az algoritmusok célja, hogy egy problémára a lehető leghatékonyabb módon megoldást nyújtsanak.
**Tudnivalók:**

- A **specifikáció készítő**ben és **pszeudokód**ban az **index**elés **1**-től kezdődik.
- **C#** kódban az **index**elés **0**-tól kezdődik.
- Az **elemek.Length** mindig az **elemszámot** jelenti.
  Mivel a C# egy objektumorientált nyelv, a legtöbb adattípus osztályként van megvalósítva, és az objektumoknak vannak tulajdonságai. Ebben az esetben a tömbök hosszát kérdezzük le a beépített tulajdonsággal.
  A függvényekben **int** **típus** szerepel **példa**ként, de ez **lecserélhető** bármilyen típusra, **ahol az adott algoritmushoz szükséges műveletek elvégezhetők**.
  Például összegzésnél olyan típust kell használni az elemeknél, ahol az összeadás operátor értelmezett. _Ez összetett típusok vagy osztályok esetében nem mindig magától értetődő._
  Néhány helyen a specifikáció miatt visszavezetést adtam meg, de a pszeudokódban az általános alakot használtam.

### Összegzés

**Specifikáció** - (https://tinyurl.com/wtfwtsds)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: osszeg∈N
Ef: elemszam > 0
Uf: osszeg=SZUM(i=1..elemszam,elemek[i])
```

**Pszeudokód**

```
Változó
    i:Egész
osszeg:=0
Ciklus i:=1-től elemszam-ig
    osszeg:=osszeg + elemek[i]
Ciklus vége
```

**C# algoritmus**

```csharp
int Osszegzes(int[] elemek)
{
    int osszeg = 0;
    for (int i = 0; i < elemek.Length; i++)
    {
        osszeg += elemek[i];
    }
    return osszeg;
}
```

**Használat**

```csharp
int osszeg = Osszegzes(elemek);
```

---

### Megszámolás

**Specifikáció** - (https://tinyurl.com/mssate38)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: darab∈N
Ef: elemszam > 0
Uf: darab=DARAB(i=1..elemszam,elemek[i] % 2 = 0)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] % 2 = 0
```

**Pszeudokód**

```
Változó
    i:egész
darab:=0
Ciklus i:=1-től elemszam-ig
    Ha(T(elemek[i])) akkor
        darab:=darab + 1
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
int Megszamolas(int[] elemek,Func<int, bool> Tulajdonsag)
{
    int darab = 0;
    for (int i = 0; i < elemek.Length; i++)
    {
        if (Tulajdonsag(elemek[i]))
        {
            darab++;
        }
    }
    return darab;
}
```

**Használat**

```csharp
int darab = Megszamolas(elemek, elem => elem % 2 == 0);
```

---

### Maximum kiválasztás

**Specifikáció** - (https://tinyurl.com/ep9hcteu)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: maxIndex∈N, maxErtek∈N
Ef: elemszam > 0
Uf: (maxIndex,maxErtek)=MAX(i=1..elemszam,elemek[i])
```

**Pszeudokód**

```
Változó
    i:Egész
maxIndex:=1
maxErtek:=elemek[1]
Ciklus i:=2-től elemszam-ig
    Ha (elemek[i] > maxErtek) akkor
        maxIndex:=i
        maxErtek:=elemek[i]
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
(int, int) MaxKivalasztas(int[] elemek)
{
    int maxIndex = 0;
    int maxErtek = elemek[0];
    for (int i = 1; i < elemek.Length; i++)
    {
        if (elemek[i] > maxErtek)
        {
            maxIndex = i;
            maxErtek = elemek[i];
        }
    }
    return (maxIndex, maxErtek);
}
```

**Használat**

```csharp
(int maxIndex, int maxErtek) = MaxKivalasztas(elemek);
```

---

### Minimum kiválasztás

**Specifikáció** - (https://tinyurl.com/3pbb39b3)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: minIndex∈N, minErtek∈N
Ef: elemszam > 0
Uf: (minIndex,minErtek)=MIN(i=1..elemszam,elemek[i])
```

**Pszeudokód**

```
Változó
    i:Egész
minIndex:=1
minErtek:=elemek[1]
Ciklus i:=2-től elemszam-ig
    Ha (elemek[i] < minErtek) akkor
        minIndex:=i
        minErtek:=elemek[i]
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
(int,int) MinKivalasztas(int[] elemek)
{
    int minIndex = 0;
    int minErtek = elemek[0];
    for (int i = 1; i < elemek.Length; i++)
    {
        if (elemek[i] < minErtek)
        {
            minIndex = i;
            minErtek = elemek[i];
        }
    }
    return (minIndex,minErtek);
}
```

**Használat**

```csharp
(int minIndex, int minErtek) = MinKivalasztas(elemek);
```

---

### Feltételes maximum keresés

**Specifikáció** - (https://tinyurl.com/4ajcmeef)

```csharp
Be: elemszam∈N, elemek∈Z[1..elemszam]
Ki: van∈L, maxIndex∈N, maxErtek∈Z
Ef: elemszam > 0
Uf: (van,maxIndex,maxErtek)=MAXHA(i=1..elemszam,elemek[i],elemek[i] < 0)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] < 0
```

**Pszeudokód**

```
Változó
    i:Egész
van:=hamis
Ciklus i:=1-től elemszam-ig
    Ha T(elemek[i]) akkor
        Ha van akkor
            Ha elemek[i] > maxErtek akkor
                maxIndex:=i
                maxErtek:=elemek[i]
            Elágazás vége
        Különben
            maxIndex:=i
            maxErtek:=elemek[i]
            van:=igaz
        Elágazás vége
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
(bool, int, int) FeltetelesMaximum(int[] elemek, Func<int, bool> Tulajdonsag)
{
    bool van = false;
    int maxIndex = -1;
    double maxErtek = -1;
    for (int i = 0; i < elemek.Length; i++)
    {
        if (Tulajdonsag(elemek[i]))
        {
            if (van)
            {
                if (elemek[i] > maxErtek)
                {
                    maxIndex = i;
                    maxErtek = elemek[i];
                }
            }
            else
            {
                maxIndex = i;
                maxErtek = elemek[i];
                van = true;
            }
        }
    }
    return (van, maxIndex, maxErtek);
}
```

**Használat**

```csharp
(bool van, int maxIndex, int maxErtek) = FeltetelesMaximum(elemek, elem => elem < 0);
```

---

### Feltételes minimum keresés

**Specifikáció** - (https://tinyurl.com/3ybnuj9y)

```csharp
Be: elemszam∈N, elemek∈Z[1..elemszam]
Ki: van∈L, minIndex∈N, minErtek∈Z
Ef: elemszam > 0
Uf: (van,minIndex,minErtek)=MINHA(i=1..elemszam,elemek[i],elemek[i] >= 0)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] >=0
```

**Pszeudokód**

```
Változó
    i:Egész
van:=hamis
Ciklus i:=1-től elemszam-ig
    Ha T(elemek[i]) akkor
        Ha van akkor
            Ha elemek[i] < minErtek akkor
                minIndex:=i
                minErtek:=elemek[i]
            Elágazás vége
        Különben
            minIndex:=i
            minErtek:=elemek[i]
            van:=igaz
        Elágazás vége
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
 (bool, int, int) FeltetelesMinimum(int[] elemek, Func<int, bool> Tulajdonsag)
 {
     bool van = false;
     int minIndex = -1;
     double minErtek = -1;
     for (int i = 0; i < elemek.Length; i++)
     {
         if (Tulajdonsag(elemek[i]))
         {
             if (van)
             {
                 if (elemek[i] < minErtek)
                 {
                     minIndex = i;
                     minErtek = elemek[i];
                 }
             }
             else
             {
                 minIndex = i;
                 minErtek = elemek[i];
                 van = true;
             }
         }
     }
     return (van, minIndex, minErtek);
 }
```

**Használat**

```csharp
(bool van, int minIndex, int minErtek) = FeltetelesMinimum(elemek, elem => elem >= 0);
```

---

### Keresés

**Specifikáció** - (https://tinyurl.com/4h989vcn)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: van∈L,index∈Z
Ef: elemszam > 0
Uf: (van,index)=KERES(i=1..elemszam,elemek[i] = 10)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] = 10
```

**Pszeudokód**

```
Változó
    i:Egész
i:=1
Ciklus amíg i <= elemszam és nem T(elemek[i])
    i:=i + 1
Ciklus vége
Ha i <= elemszam akkor
    van:=igaz
    index:=i
Különben
    van:=hamis
Elágazás vége
```

**C# algoritmus**

```csharp
(bool, int) Kereses(int[] elemek, Func<int, bool> Tulajdonsag)
{
    bool van;
    int i = 0;
    int index = -1;
    while ((i < elemek.Length) && !Tulajdonsag(elemek[i]))
        i++;
    if (i < elemek.Length)
    {
        van = true;
        index = i;
    } else
    {
        van = false;
    }
    return (van, index);
}
```

**Használat**

```csharp
(bool van, int index) = Kereses(elemek, elem => elem == 10);
```

---

### Eldöntés

**Specifikáció** - (https://tinyurl.com/42m7c9h6)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: van∈L
Ef: elemszam > 0
Uf: van=VAN(i=1..elemszam,elemek[i] = 10)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] = 10
```

**Pszeudokód**

```
Változó
    i:Egész
i:=1
Ciklus amíg i <= elemszam és nem T(elemek[i])
    i:= i + 1
Ciklus vége
Ha i <= elemszam akkor
    van:=igaz
Különben
    van:=hamis
Elágazás vége
```

**C# algoritmus**

```csharp
bool Eldontes(int[] elemek, Func<int, bool> Tulajdonsag)
{
    int i = 0;
    while (i < elemek.Length && !Tulajdonsag(elemek[i]))
        i++;
    return (i < elemek.Length);
}
```

**Használat**

```csharp
bool van = Eldontes(elemek, elem => elem == 10);
```

---

### Mind eldöntés

**Specifikáció** - (https://tinyurl.com/mr3u84uk)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: mind∈L
Ef: elemszam > 0
Uf: mind=MIND(i=1..elemszam,elemek[i] = 5)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] = 5
```

**Pszeudokód**

```
Változó
    i:Egész
i:=1
Ciklus amíg i <= elemszam és T(elemek[i])
    i:= i + 1
Ciklus vége
Ha i <= elemszam akkor
    mind:= hamis
Különben
    mind:= igaz
Elágazás vége
```

**C# algoritmus**

```csharp
bool MindEldontes(int[] elemek, Func<int, bool> Tulajdonsag)
{
    int i = 0;
    while (i < elemek.Length && Tulajdonsag(elemek[i]))
        i++;
    return (i == elemek.Length);
}
```

**Használat**

```csharp
bool mind = MindEldontes(elemek, elem => elem == 5);
```

---

### Kiválasztás

Ez az algoritmus feltételezi, hogy az adott elem biztosan létezik. C# kódban azonban a biztonság kedvé-ért -1 a visszatérési érték amennyiben túl mennénk az indexekkel.

**Specifikáció** - (https://tinyurl.com/5f3u35a5)

```csharp
Be: elemek∈N[1..5]
Ki: kivIndex∈N
Ef: -
Uf: kivIndex=KIVÁLASZT(i>=1,elemek[i] = 7)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] = 7
```

**Pszeudokód**

```
Változó
    i:Egész
i:=1
Ciklus amíg nem T(elemek[i])
    i:= i + 1
Ciklus vége
```

**C# algoritmus**

```csharp
int Kivalaszt(int[] elemek, Func<int, bool> Tulajdonsag)
{
    int i = 0;
    while (i < elemek.Length && !Tulajdonsag(elemek[i]))
        i++;
    return (i < elemek.Length) ? i : -1;
}
```

**Használat**

```csharp
int kivIndex = Kivalaszt(elemek, elem => elem == 7);
```

---

### Másolás

**Specifikáció** - (https://tinyurl.com/3see3wk7)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: negyzetSzamok∈N[1..elemszam]
Fv: negyzet: N->N,
    negyzet(szam)=(szam*szam)
Ef: elemszam > 0
Uf: (negyzetSzamok)=MÁSOL(i=1..elemszam,negyzet(elemek[i]))
```

**Visszavezetés**

```
f(elemek[i]) ~ negyzet(elemek[i])
fvelemek ~ negyzetSzamok
```

**Pszeudokód**

```
Változó
    i:Egész
Ciklus i:=1-től elemszam-ig
    fvelemek[i]:=f(elemek[i])
Ciklus vége
```

**C# algoritmus**

```csharp
int[] Masolas(int[] elemek,Func<int, int> Fuggveny)
{
    int[] fvElemek = new int[elemek.Length];
    for (int i = 0; i < elemek.Length; i++)
    {
        fvElemek[i] = Fuggveny(elemek[i]);
    }
    return fvElemek;
}
```

**Használat**

```csharp
int[] fvElemek = Masolas(elemek, elem => elem * elem);
```

```csharp
int Negyzet(int szam)
{
    return szam * szam;
}
int[] fvElemek = Masolas(elemek, elem => Negyzet(elem));
```

---

### Kiválogatás

Kiválogatásnál mivel a képzésben tömbökkel dolgozunk, a kimeneti tömb mindig ugyan olyan hosszú mint a bemeneti tömb. Ha nem akarjuk kiírni az üres értékeket akkor kiírásnál csak a kivDb-ig szabad elmenni. Egy újabb másolással, **Listával** vagy LINQ-val el lehet tüntetni ezeket a felesleges értékeket, de a képzésen ezek használata tilos, így a kiírást kell megfelelően kezelni.

**Specifikáció** - (https://tinyurl.com/27shssyu)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: kivDb∈N, kivIndexek∈N[1..kivDb]
Ef: elemszam > 0
Uf: (kivDb,kivIndexek)=KIVÁLOGAT(i=1..elemszam,elemek[i] < 4, i)
```

**Visszavezetés**

```
T(elemek[i]) ~ elemek[i] < 4
```

**Pszeudokód**

```
Változó
    i:Egész
kivDb:=0
Ciklus i:=1-től elemszam-ig
    Ha T(elemek[i]) akkor
        kivDb:= kivDb + 1
        kivIndexek[kivDb]:= i
    Elágazás vége
Ciklus vége
```

**C# algoritmus**

```csharp
(int, int[]) Kivalogatas(int[] elemek, Func<int,bool> Tulajdonsag)
{
    int[] kivIndexek = new int[elemek.Length];
    int kivDb = 0;
    for (int i = 0; i < elemek.Length; i++)
    {
        if (Tulajdonsag(elemek[i]))
        {
            kivIndexek[kivDb++] = i;
        }
    }
    return (kivDb, kivIndexek);
}
```

**Használat**

```csharp
(int kivDb, int[] kivIndexek) = Kivalogatas(elemek, elem => elem > 20);
```

**[Oldal elejére](#programozási-tételek)**
