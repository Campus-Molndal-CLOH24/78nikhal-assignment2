Namn: [Niklas Häll]

# Inlämningsrapport

Information
OBS!!! ändra absolut inte på rubrikerna i denna fil!!!!

## Inledning

### Hur uppfattade du uppgiften initialt?

Väldigt röriga förklaringar och fel i dokumentationen. En liten punktlista för att illustrera:
1. I intro.md står under Krav 1. Skapa följande klasser.. "I Models-namespace" (CarImpl och MotorcycleImpl), "I Factories-namespace" (CarFactory och MotorcycleFactory")
- Först och främst så är det tydligt i resten av dokumentationen att det är Models-MAPPEN och Factories-MAPPEN, inget separat namespace. Detta är bara förvirrande.
2. Kodexempel Program.cs använder i "intro.md": "using Factories;" och "using Models;". I Main.md-filen vi kopierar används "using Se.Dsve.Factories;", "using Se.Dsve.Models;" och sedan nämns "namespace Se.Dsve" längre ner:
- Det här är bara rörigt. Kombinerat med texten under punkt 1 så förvirrar det här garanterat många (jag fick frågor privat från andra studerande som inte förstod varför det är olika namespace). Jag förstår tanken dock, det är att vi skall inkludera mapparna Factories och Models, oavsett vad namespacet nu än råkar heta. Men kombinerar vi det med den konstiga fraseringen i punkt 1 så ökar detta på förvirringen..
3. Målet för VG-betyg är att följa Clean Code.
- Enligt Robert C. Martin skulle "CarImpl" "MotorcycleImpl" inte accepterats. Vad står det för? Implementation? Då borde vi skriva så? Samtidigt står det tydligt att vi inte skall ändra namn på saker så då betyder det att vi skall lämna in detta med en namngivning vi inte tycker följer Clean Code?
4. För att ytterligare spä på punkt 1 + 2: Tar vi kodexemplena i CarFactory.md som exempel: "using Models;" är självförklarande, men "namespace Factories"?
- Ytterligare element av förvirring på samma tema. Det är INTE ett annat namespace, det är en annan mapp/folder/filstruktur! Namespace är hela projektet, eller hur? Vi inkluderar mappen, inte ett nytt namespace.. Samma problem ser vi återigen i MotorcycleFactory.md och alla Interface-filerna.
5. Går vi in på CarImpl.md har vi titeln "Car Implementation" för denna fil. Går vi in på Motorcycle.Impl har vi titeln.. "Car implementation".
- Nåja, det är väl bara kopierad text där det missats uppdatera, hade det varit allt hade jag inte ens reagerat. Nu spär det på förvirringen, tyvärr.
6. Trasiga .md-filer: "CarImpl.md". Får felmeddelande under "Klassdiagram":
- Unable to render rich display

Parse error on line 3:
... +int Doors { get; set; } }
----------------------^
Expecting 'STRUCT_STOP', 'MEMBER', got 'OPEN_IN_STRUCT'

For more information, see https://docs.github.com/get-started/writing-on-github/working-with-advanced-formatting/creating-diagrams#creating-mermaid-diagrams
7. Samma på ICar.md, IMotorcycle.md, IVehicle.md, alla har samma felmeddelande:
- Unable to render rich display, parse error on line 3, samma som på punkt 6.
8. Får problem med denna Reflections.md
- Den byter alla å, ä och ö mot �. Inte när jag läser på GitHub, men när jag laddar ner filen och kör den här. Jag har tagit bort dem successivt vartefter jag går igenom dokumentet, men jag har haft samma problematik ibland att vissa program inte sparar i filer som är kompatibla med vanliga teckenuppsättningar. Kolla inställningarna i ert .md-program? Som på punkt 5, detta hade jag inte nämnt om det inte blev så mycket som dök upp, är det många saker som vi "hakar upp oss på" medan vi läser så är det svårt att läsa texten flytande, och då ökar risken för förvirring markant.

Ovanstående var första-intrycket, det var lite som när du kör i dimma. Jag såg vägmarkeringarna och förstod var jag skulle, men sikten grumlades av störande element. När det gäller själva uppgiften så tyckte jag den var tydlig: Vi har färdig kod och instruktioner för arkitekturen, så det är bara att skapa layouten, lägga in elementen och sedan börja knyta ihop dem.

Här kommer direkt en varningsklocka från erfarenhet från tidigare uppgifter: Det är alltid lättast att bygga element ett i taget, och se till att hålla bort alla varningar och felmeddelanden direkt. Det är mycket lättare att felsöka och revertera en implementation som blivit fel.

I detta projekt är det naturligt att börja med att lägga in Program-koden med Main-segmentet direkt, och då kan det lätt bli rörigt om vi skall lägga till en klass/interface/metod i taget, vi kommer inte kunna köra main om inte hela layouten finns! Det är också väldigt svårt att jobba i någon annans kod, innan du satt dig in i den.

Nu kommer vi till planering/genomförande ->

--- Skriv ovanför och ta inte bort denna raden ---

## Planering och genomförande

### Vilka steg tog du för att lösa uppgiften?

Intro: Som nämnts ovan så tänkte jag igenom riskerna med att skapa hela projektet vs att jobba modulärt. Det är alltid önskvärt att jobba modulärt. Eftersom vi egentligen har ett större ramverk redan så valde jag att skapa alla klasser och interface först, de kan ju finnas utan kod initialt och sedan bygger vi på därifrån. Vid behov kan jag kommentera bort kod i Program/Main och sedan arbeta "modulärt" på det här sättet.

Steg ett: läste igenom allt inlämningsmaterial för att få en övergripande bild
Steg två: Skapade mapp- och filstrukturen och började ta grundtemplates från materialet vi hade tillgång till. Vi hade ju punkten "Steg-för-steg-arbetsgång" så de klasserna skapade jag tidigt.
Steg tre: Satte upp en ny github-repository och initialiserade projektets mapp genom bash (git init, git remote add origin etc)
Steg fyra: Började dokumentera i denna fil, och valde sedan att omgående brancha mitt privata repository till att göra ett internt repo inom CLO24 istället.

--- Skriv ovanför och ta inte bort denna raden ---

## Utmaningar och lösningar

### Vilka utmaningar stötte du på under projektet?

--- Skriv ovanför och ta inte bort denna raden ---

### Hur löste du dessa utmaningar?

--- Skriv ovanför och ta inte bort denna raden ---

### Beskriv några implementeringsval du gjort?

--- Skriv ovanför och ta inte bort denna raden ---

## Reflektion och utvärdering

### Vad lärde du dig genom att genomföra projektet?

--- Skriv ovanför och ta inte bort denna raden ---

### Vilka möjligheter ser du för framtida projekt baserat på denna erfarenhet?

--- Skriv ovanför och ta inte bort denna raden ---