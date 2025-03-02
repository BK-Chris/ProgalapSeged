# Algoritmusok

[Főoldal](../readme.md)

Az alapvető algoritmusokról bővebben [itt](prog_alap_ism.md#alapvető-programozási-tételek) olvashatsz.

## Tartalom

- [Keresés](#keresés)
  - [Bináris keresés](#bináris-keresés) _(logaritmikus keresés)_
- [Rendezés](#rendezés)
  - [Gyors rendezés](#gyors-rendezés-algoritmus)
- [Speciális](#speciális-algoritmusok)
  - [Egyedi elemek kiválogatása](#egyedi-elemek-kiválogatása)

## Keresés

### Bináris keresés

Csak rendezett elemek esetén működik, a lényege hogy, minden iterációnál megvizsgáljuk a sorozat középső elemét, ha a középső elem nagyobb mint a keresett elem akkor az alsó határt be állítjuk a közép indexre, ha a keresett elem kisebb akkor pedig a felső határt állítjuk be a középső indexre. Addig csináljuk "felezgetjük" a sorozatot amíg meg nem lesz az elem, vagy az alsóindex nagyobb vagy egyenlő lesz a felső határral azaz nem találtunk elemet.

**Pszeudokód**

```
Változó:
    rendezettElemek:Tömb

Függvény BinárisKeresés(rendezettElemek:Tömb,elem:Egész):(Logikai,Egész)
    Változó
        van:Logikai
        index:-1
        ah:Egész // Alsó határ
        fh:Egész // Felső határ
    van:= hamis
    ah:=0
    fh:=hossz(rendezettElemek) - 1
    Ciklus ((amíg ah <= fh) és nem (van))
        Változó
            középInd = (fh + ah) / 2
        Ha (rendezettElemek[középInd] = elem) akkor
            index:=középIndex
            van:= igaz
        Különben ha (rendezettElemek[középInd] < elem) akkor
            fh:=középInd - 1
        Különben
            ah:=középInd + 1
        Elágazás vége
    Ciklus vége
    BinárisKeresés:=(van, index)
Függvény Vége

(van:Logikai, index:Egész):= BinárisKeresés(rendezettElemek,elem)
```

**C# algoritmus**

```csharp
public static int BinarySearch<T>(List<T> items, T item) where T : IComparable<T>
{
    if (items.Count == 0) return -1;

    int lowerLimit = 0;
    int upperLimit = items.Count - 1;

    while (lowerLimit <= upperLimit)
    {
        int middleIndex = (lowerLimit + upperLimit) / 2;
        int comparison = items[middleIndex].CompareTo(item);

        if (comparison == 0)
            return middleIndex;
        else if (comparison < 0)
            lowerLimit = middleIndex + 1;
        else
            upperLimit = middleIndex - 1;
    }

    return -1;
}
```

**Használat**

```csharp
List<int> ints = [1, 2, 3, 4, 5];
int result1 = Kereses.BinarySearch(ints, 1);
// result1 == 0

List<char> chars = ['a', 'b', 'c', 'd', 'e'];
int result2 = Kereses.BinarySearch(chars, 'b');
// result2 == 1

List<int> ints2 = [];
int result3 = Kereses.BinarySearch(ints2, 1);
// result3 == -1
```

## Rendezés

### Gyors rendezés algoritmus

**Pszeudokód**

```
Változó
  tömb:Tömb

Eljárás GyorsRendezés(tömb:Tömb, balIndex:Egész, jobbIndex:egész)
  Változó
    középPont:Egész

  Ha (balIndex < jobbIndex) akkor
    középPont = Rendezés(tömb, balIndex,JobbIndex)
    GyorsRendezés(tömb, balIndex, középPont - 1)
    GyorsRendezés(tömb, középPont + 1, jobbIndex)
  Elágazás vége
Eljárás vége

Függvény Rendezés(tömb:Tömb, balIndex:Egész, jobbIndex:Egész):Egész
  Változó
    i:Egész
  i:= balIndex - 1
  Ciklus j:=balIndex-től jobbIndex-ig
    Ha tömb[j] < tömb[jobbIndex] akkor
      i:=i + 1
      Csere(tömb[i],tömb[j])
  Ciklus vége
  Csere(tömb[i + 1], tömb[jobbIndex])
  Rendezés:= (i + 1)
Függvény vége
```

**C# algoritmus**

```csharp
void GyorsRendezes(int[] tomb, int balIndex, int jobbIndex)
{
    if (balIndex < jobbIndex)
    {
        int pivot = ReszRendezes(tomb, balIndex, jobbIndex);
        GyorsRendezes(tomb, balIndex, pivot - 1);
        GyorsRendezes(tomb, pivot + 1, jobbIndex);
    }

    // Helyi függvény
    int ReszRendezes(int[] tomb, int balIndex, int jobbIndex)
    {
        int i = balIndex - 1;

        for (int j = balIndex; j < jobbIndex; j++)
        {
            if (tomb[j] < tomb[jobbIndex])
            {
                i++;
                (tomb[i], tomb[j]) = (tomb[j], tomb[i]);
            }
        }
        i++;

        (tomb[i], tomb[jobbIndex]) = (tomb[jobbIndex], tomb[i]);
        return i;
    }
}
```

**Használat**

Mivel a tömbök és listák referenciaként kerülnek átadásra, nincs szükség visszatérési értékre.

```csharp
GyorsRendezes(tomb, 0, tomb.Length - 1);
```

## Speciális

### Egyedi elemek kiválogatása

Az algoritmus a [kiválogatás](prog_alap_ism.md#kiválogatás) és [eldöntés](prog_alap_ism.md#eldöntés) kombinációját használja.

**Specifikáció** - (https://tinyurl.com/2p8b5fh8)

```csharp
Be: elemszam∈N, elemek∈N[1..elemszam]
Ki: kivDb∈N, kivElemek∈N[1..kivDb]
Fv: voltE: N->L,
    voltE(index)=(VAN(i=1..index-1,elemek[i] = elemek[index]))
Ef: elemszam > 0
Uf: (kivDb,kivElemek)=KIVÁLOGAT(i=1..elemszam,nem voltE(i), elemek[i])
```

**Visszavezetés**

```
// Kiválogatás
T(elemek[i]) ~ nem voltE(i)
// Eldöntés
elemszám ~ index-1
T(elemek[i]) ~ elemek[i] = elemek[index]
```

**Pszeudokód**

```
Változó
    i:Egész
kivDb:=0
Ciklus i:=1-től elemszam-ig
    Ha nem voltE(i) akkor
        kivDb:= kivDb + 1
        kivIndexek[kivDb]:= i
    Elágazás vége
Ciklus vége
Függvény voltE(index:Egész):Logikai
    Változó
        i:Egész
    i:=1
    Ciklus amíg (i <= index-1) és nem (elemek[i] = elemek[index])
        i:= i + 1
    Ciklus vége
    voltE:= (i <= index-1 )
Függvény vége
```

**C# algoritmus**

```csharp
(int, int[]) EgyediekKivalogatasa(int[] elemek)
{
    int[] kivElemek = new int[elemek.Length];
    int kivDb = 0;
    for (int i = 0; i < elemek.Length; i++)
    {
        if (!VoltE(i))
        {
            kivElemek[kivDb++] = elemek[i];
        }
    }
    return (kivDb, kivElemek);

    // Helyi függvény
    bool VoltE(int index)
    {
        int i = 0;
        while (i < index && elemek[i] != elemek[index])
            i++;
        return (i < index);
    }
}
```

**Használat**

```csharp
(int kivDb, int[] kivElemek) = EgyediekKivalogatasa(elemek);
```

---

**[Oldal elejére](#algoritmusok)**
