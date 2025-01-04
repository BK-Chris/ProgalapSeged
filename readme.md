# Programozási tételek

>Segédanyag az [Eötvös Loránd Tudomány Egyetem](https://www.inf.elte.hu/) - Programtervező Informatikus (FOSZK) - Programozási Alapismeretek (IK-19fszPAEG) - 2024/25/I. félévben oktatott tantárgyához.

A képzés során az alapvető programozási tételek, ezek algoritmusának megírását és használatáról tanulunk. A képzés során egy [specifikációs szoftvert](https://progalapfsz.elte.hu/specifikacio/) is használunk. A program jelentős segítséget nyújt az elméleti feladatok gyors megoldásában, lehetővé téve, hogy hamarabb áttérjünk az algoritmusok megírására és a kódolásra. Ezen kívűl a szoftver lehetőséget biztosít tesztesetek vizsgálatára, amely elősegíti a korai felismerését annak, hogy a megoldás helyes irányba halad-e.
Az itt felsorolt algoritmusok a modernebb programozási nyelvekben kivétel nélkül megtalálhatóak, azonban ezeknek az ismerete és működése nélkülözhetetlen tudás a továbbiakban azok számára akik ezt a pályát választják.
Ez a dokumentum egy [korábbi segédanyag](https://github.com/BK-Chris/_seged/) átdolgozása, itt csak általános megoldásokat találsz.

## Tartalom

- [Specifikáció kisokos](#specifikáció-kisokos)
   - [Jelzések](#jelzések)
   - [Gyakori beéptett függvények](#gyakori-beépített-függvények)
   - [Saját függvény készítése](#saját-függvény-készítése)
   - [Specifikáció felépítése](#specifikáció-felépítése)
   - [Egyebek](#egyebek)
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
- [Egyéb algoritmusok](#egyeb-algoritmusok)

## Specifikáció kisokos
### Jelzések
| Jelek | Jelentése |
| :---: | :--- |
| ∈ | Eleme |
| ∀ | Minden |
| ∃ | Létezik |
| L | Logikai |
| R | Valós szám |
| N | Természetes egész szám |
| Z | Egész szám |
| S | Szöveg |

- **Tömb:** elemek∈TÍPUS[1..10]
- **Struktúra:** STRUKTÚRA=(ELEM_1:TÍPUS x ELEM_2:TÍPUS)
- **T(elem)**: Valamilyen tulajdonságú elem. Ez lehet egy függvény valamilyen visszatérési értékkel vagy egy logikai állítás is például *elemek[i] > 0.*
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

### Egyebek

- A specifikácó készítő a nagybetűs függvényneveket, változó neveket nem fogadja el, illetve típusként értelmezi azokat.

----

## Alapvető programozási tételek

Az algoritmusok célja, hogy egy problémára a lehető leghatékonyabb módon megoldást nyújtson.

> Néhány helyen a specifikáció miatt írtam visszavezetést, de a pszeudo kódba az általános alakot adtam meg.

> - A specifikáció készítőben és pszeudokódban az indexelés 1- től kezdődik.
> - C# kódban az indexelés 0- tól kezdődik.

### Összegzés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OvQrCQBCEX%2BWYSuEIRkizEAvBSrSRNF5SHHEjh%2FmR3NkkpM9z%2BiRyCSHCFrszs99uD%2Fvm3BQm1840NQhHJsElV7bT1Xccr3Ka%2BOV7FQbB4mVpm9ZnQ6KxtuOnt71yKtZ1cRA7ryXFkopv9%2BSyMfEfR854ZbItJBxbZ0Gqx0M7DcISIxF51BwmoSIp1pp%2BmS%2BQ2EeQqHXFIECiZfspHSgcsuEHnX8s8%2B4AAAA%3D)
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

```

---
### Megszámolás

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OzQqCQBDHX2UYCAoGUcvLgIFSp6BD0Gn1sNkKS2rhbpfEu8%2FZk8RqUreZ%2F8dvpkPzUIUudSGtvjfImCoGVanavGT9HoYjjZu6uVkEnjd7edZmzUEzXGUrL851wr78tWELvtPO5TcU75JTki51%2FIehiS50DgsIIQZ%2FhYRWGWuQRYdXaSUyznGGyCGnEoMICEKCNcGGIBpfGi8xhEjYyFohIxK2yjwrixz0ef8BneZHwPMAAAA%3D)
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

```

---

### Maximum kiválasztás

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OzwqCQBCHX2WYU8IgWXkZMCjoEFG3IDAPi46w1Fq4G0ji3efsScJsqdv8%2BX7zTYv2Lrkuda6cvlXIuBYGuYqxT2VefX%2BgTyeXoU6jMPS77Fyfq51mMKrZVoU0I2xUs6ndiA%2FEpvydgyVMh9mxZJj4GPlEkOxXp4lO%2Fhw0qlOdBUjoxDqLnLZYKKeQ0WMM8XB2hBnSiGBGMCdYEMSfP73sS3olQ4yElTKCjEhYi31cHXLUZd0b7PqvgBoBAAA%3D)
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

```

---


### Minimum kiválasztás

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OvQrCQBCEX2XZysAinj%2FNghZCiiCms0pSHLqBw9wpuRNEsc9z%2BiSSxEO7nd1vZvaJ%2FipHU5ujDubikHErDNKI9Q9t312X06Dk3M%2BFmk7jrSrb0u0MgzUucye5j7A1Lm3DiPdEWv%2FiYAOzfneoGSbRRtGRrPdZPjHrvw4aqwtTJUgYxAePXDzxpINGxogxrPrYEWYoFMGcYEGwJFgNf8YyBvWVQyWDQkKnrSAjErbib01AVq%2Fq9QHhfC1VGgEAAA%3D%3D)
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

```
---

### Feltételes maximum keresés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2PTWrDQAyFryK0SkAOHkM3oimkEGjpz65Q6nghEhmGxtPimRjTkP2c0ycptjukOz1Jn97TGf237m1t9xLsl0PGe2XQozb%2BR5ohxlealH4OMX6UZrVKs2rX7tyTZejEDTE%2BEzTSP7qD9jPVSL9tw8yNq9v6ehfuIB97bzXDohNHCaVELdcvm%2FeHzcKu%2F1nSnKS01bWCW8iXSBjUB49cnvEgQZAxQQw3o9UMMJRZQZAZgpzAEBTTG504htCedBQpC0PxJ6dEDJlBQieNIiMStupPx4BsLtXlF2rMCQRHAQAA)
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

```
---

### Feltételes minimum keresés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2PwWoCQQyGXyXkpBBlV%2BklsEILQqXVWy9d9zBoFoY6adkZF1G8z3Puk5Td7WBv%2BZN8%2Bf%2Fc0P%2FIwdb2YIL9VmR8EQY5ifNX47oYdzQo%2Bepi%2FCzz%2BTzNqn2z1zfL0BrtYnwncFY3epTLSDmr6yaMXL%2B6rh93YQVZ3%2FuoGSatUUooJWpabDe71%2BeJLf5Z0piktNWjglUB2RQJg%2FjgkcsbHk0wyJgohqfeayQYytmCYJYTZAQ5wWL4ozXKEJqz9CKFYVj%2BySESQ4aEapwgIxI24s%2BngJzfq%2FsvAXEHmEcBAAA%3D)
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

```
---

### Keresés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OQYvCQAyF%2F0rISSGKs6uXQD0IPSkedtmLtYegKQy2ozizZVnxPr%2Bzv0SmRfSWl%2FfyvdzQX%2FRgK3uQYM8OGVfKoLU2%2Fl%2BaLsYt9UpPaS7MdPr0yv1179aWoRXXxbgh647618W4S0ZevSiwhFna%2FVQMo1bckBxn6%2Fwr%2Fx7Z7A1KQ1dhS8jAzMZIGNQHj1zc8ChBkPGZZVgk6nDBUBiCD4JPgjnBov%2BuFcdQSe01qb6VYWKQ0EmjyIiEV%2FW%2FdUA29%2FL%2BAJ0N7gMNAQAA)
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

```
---
### Eldöntés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OQQuCQBCF%2F8owp4JBtPIyYFDQqfBWF%2FWw2AhLuoW7eUi8%2Bzv9JaEidXvvzXsf06J9Sa4LnSunnwYZj8IgpVT2o6qh72OanDxGnQSet9yytE7NWTM0ygx9fxntqfhtYQ%2F%2BmF2LqRLdDvFKR38AmrmJziCCwF8joRPrLHLS4l05hYxLlyEcWfOCIQkINgRbgh1BOH3SKMNQqNIKEhpVCTIiYS32XTrkoMu6L%2BUsPeLsAAAA)
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

```
---

### Mind eldöntés

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OsQqDQAyGXyVkauGQOrgE7FDaobR163Q6HBrhqHct3rlU3H1On6ScIhYy5E%2F%2B%2F0t6dB8uda1L5fXbIuGJCbhh477KTOOYiVnxK%2FQyjqJ1V%2BRtbm%2BawGhbTeN4D%2FpSb2E4wiHMnvXiSR%2FX7LzT6R9DLGipC0gh2aNAz847JNljpbxCwtVKkATYEiCQiYCt5l%2FCDQLfdowCrTKMhCiwZdc1HikeiuEH%2BULHvO4AAAA%3D)
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
Ciklus amíg i <= elemszam és nem T(elemek[i])
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

```
---

### Kiválasztás

Ez az algoritmus feltételezi, hogy az adott elem biztosan létezik.

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACqtWKi5ITc5My0xOLMnMz1OyUnJKtVJIzUnNTc1%2B1NHhF22op2caG1MUk%2BedaaWQnVnmmZeSWgGSAYm5plkp6IIYoWkISVtvz7DDjT6OwVEhGpl2toY6ENOiM2MVbBXMNZV0lEpSi0uKlayiq5VSEksSlayUICqsFKJNdRRMdRTMwSTEWpipVgrGSjpKeYm5qUpWSko6SkWpxaU5JUpWhrWxtQBTYnZtxQAAAA%3D%3D)
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

```
---

### Másolás

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACm2PwUrDUBBFf%2BUyq0TG0tRGcCBdCLpR46K4SrN41El52KTS9xRM6cJd%2F8s%2F8UvkJcRacDUzdw5z7%2BzIverSVnZpvN00JHStAl1r7VpTfx8OOXeTvoS%2BSEajYVcutovmzgoaXX206uetqTf%2FU7fvv5QgP5%2FlHFQAgxoFNM66ctb1AbipjkkwwzhoT5UgOnGMs4evz%2FnjfWSzP748XO7DF7aMY2Ly6rwjKXb0bLwhoYEXpOF8TwuKhDFhXDCmjLR74sS0J6aMK0ZyyZikJTE1plYSIqature1J0n25f4HzKrnAWMBAAA%3D)
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

```
---

### Kiválogatás

**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACk2OzWrCUBCFX2WYlYFBjD%2BbQQstSpGUdqPdXLO4NRMYYtLivQ2l4qI738s38UlKbpS4OzPnO3PmgO5Ltprr1nr9rJDxSRhkJ6X7teXldHqlMEnRaBP3%2Bzcv3ew3VaIMhdbzj5YstF5Wmfx0dDADusi7u%2FAAg2a3zhl6AaEuGs2S5fv57%2BXt%2BXHV09ldJbWfGE1hCmMCjZDQi%2FMO2Rwws94i441mmDQdbYbBDAliamIjgkl4KTQzjK762s9gYoIhwThFwsqWgoxIuBf3vfPI8TE9%2FgN%2FJqenNwEAAA%3D%3D)
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

```
---
## Egyéb algoritmusok

### Egyedi elemek kiválogatása
> Kiválogatás + Eldöntés
**Specifikáció** [LINK](https://progalapfsz.elte.hu/specifikacio/?data=H4sIAAAAAAAACmWPTU7DMBCFrzKaVSxNIwLNZqRUKiIg1CpsoJvUC9M6kpWfotpEiKoLdr0XN%2BEkyA4pQmys5zdv%2FD0f0L7ojanMRjmz65DxWjPoRrf2XbVfp1NB4aZrr8skjseZXO%2FX3cIw1Ka%2FeR6StenzP%2BEwC8nbnqHfNS5nKCazJXkPAAYvMt1Wv4ksWs2LyGRJHAdjktDALo2EDEbtR1II%2F0Je%2FZaFGVx476liiAKYzn1EtrhffX4sH%2B7mjwNg3KJOt2MJQWeGFEjotHUWuTzgVjmFjOMSQ%2BpJQ5ihvCS4IpiGMw3fDXyG6Y%2FO%2FyVTiYSdajUyIuFe29fGISdHefwGKjJcp5QBAAA%3D)
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

```

#### **[FEL](#programozási-tételek)**