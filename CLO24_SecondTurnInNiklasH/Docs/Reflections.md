Namn: [Niklas Häll]

# Inlämningsrapport

Information
OBS!!! ändra absolut inte på rubrikerna i denna fil!!!!

## Inledning

### Hur uppfattade du uppgiften initialt?

Första intrycket var inte så trevlig, dokumentationen var rörig.
- Fragmenterad (samma information fast på olika sätt på olika ställen, för många sektioner).
- Mappar kallades upprepade gånger för "namespace", fast det är tydligt att vi jobbar i ett enda namespace så skapade det ett rörigt och väldigt komplext intryck.
- Lite nitpick, men om Clean Code är något vi skall sträva efter så borde klasserna heta CarImplementation och MotorcycleImplementation, inte "Impl". Jag döpte om dem.
- Vissa segment är förvirrande. "using Models" är tydligt, men "namespace Factories" är det inte. I det här fallet menades "WhateverNamespaceName.Factories". Otydligt.
- En del andra småfel som påverkar helhetsintrycket: i .md-filen Motorcycle.Impl har vi titeln "Car implementation", fyra filer har trasiga klassdiagram (unable to render rich display - CarImpl.md, ICar.md, Imotorcycle.md, IVehicle.md), och slutligen så har reflections.md-filen problem med teckenuppsättningar: å, ä och ö står som �.

Ovanstående var första-intrycket, det var lite som när vi kör bil i dimma. Jag såg vägmarkeringarna och förstod var jag skulle, men sikten grumlades av störande element. När det gäller själva uppgiften så tyckte jag den var tydlig: Vi har färdig kod och instruktioner för arkitekturen, så det är bara att skapa layouten, lägga in elementen och sedan börja knyta ihop dem.

Här kommer direkt en varningsklocka från erfarenhet från tidigare uppgifter: Det är alltid lättast att bygga element ett i taget, och se till att hålla bort alla varningar och felmeddelanden direkt. Det är mycket lättare att felsöka och revertera en implementation som blivit fel.

I detta projekt är det naturligt att börja med att lägga in Program-koden med Main-segmentet direkt, och då kan det lätt bli rörigt om vi skall lägga till en klass/interface/metod i taget, vi kommer inte kunna köra main om inte hela layouten finns! Det är också väldigt svårt att jobba i någon annans kod, innan du satt dig in i den.

Nu kommer vi till planering/genomförande ->

--- Skriv ovanför och ta inte bort denna raden ---

## Planering och genomförande

### Vilka steg tog du för att lösa uppgiften?

Intro: Som nämnts ovan så tänkte jag igenom riskerna med att skapa hela projektet vs att jobba modulärt. Det är alltid önskvärt att jobba modulärt. Eftersom vi egentligen har ett större ramverk redan så valde jag att skapa alla klasser och interface först, de kan ju finnas utan kod initialt och sedan bygger vi på därifrån. Vid behov kan jag kommentera bort kod i Program/Main och sedan arbeta "modulärt" på det här sättet.

1. läste igenom allt inlämningsmaterial för att få en övergripande bild
2. Skapade mapp- och filstrukturen och började ta grundtemplates från materialet vi hade tillgång till. Vi hade ju punkten "Steg-för-steg-arbetsgång" så de klasserna skapade jag tidigt.
3. Satte upp en ny github-repository och initialiserade projektets mapp genom bash (git init, git remote add origin etc)
4. Började dokumentera i denna fil, och valde sedan att omgående brancha mitt privata repository till att göra ett internt repo inom CLO24 istället.
5. Skapade properties och metoder i CarImpl.cs
6. Skapade en branch, feature/creating-mechanics och började jobba i den
7. Kopierade koden från CarImpls.cs till MotorcycleImpl.cs och modifierade den för att passa bättre till en motorcykel.. passade på att byta Impl till Implementation, så vi håller Clean Code så gott vi kan.
8. Jag kom hit innan jag hittade den smått gömda filen project.md! Där finns steg för steg-guider som mer eller mindre visar på allt jag skrev ovanför, haha. Nu är det dags för buggfixande, jag har 6 st errors och 0 warnings. Det var följande:
- CS0246, råkade göra ett ínt istället för int!
- CS0738, kunde inte implementera ICar.Doors för att int var felstavat, se ovan.
- CS1061, saknade metoderna CreateCar och CreateMotorcycle
9. 

--- Skriv ovanför och ta inte bort denna raden ---

## Utmaningar och lösningar

### Vilka utmaningar stötte du på under projektet?

1. Den absolut första utmaningen var att jobba med färdig kod och en layout som jag inte skapat själv.
2. Den andra utmaningen var att jag råkade skapa en copy efter jag gjorde en fork i Git, så jag hade en extra kopia av projektet nestlad inuti min mappstruktur.

--- Skriv ovanför och ta inte bort denna raden ---

### Hur löste du dessa utmaningar?

1. Jag läste noga igenom dokumentationen flera gånger och skapaden en plan för implementation steg-för-steg
2. git -ls -la och sedan rm -rf (namnetpåmappen). Det hade säkert gått lika bra att bara deletea mappen direkt i Windows, men vill ha för vana att använda Bash och CLI.

--- Skriv ovanför och ta inte bort denna raden ---

### Beskriv några implementeringsval du gjort?

--- Skriv ovanför och ta inte bort denna raden ---

## Reflektion och utvärdering

### Vad lärde du dig genom att genomföra projektet?

--- Skriv ovanför och ta inte bort denna raden ---

### Vilka möjligheter ser du för framtida projekt baserat på denna erfarenhet?

--- Skriv ovanför och ta inte bort denna raden ---