Namn: [ Niklas Häll ]

# Inlämningsrapport

## Inledning

### Hur uppfattade du uppgiften initialt?

Första intrycket var inte så trevlig, dokumentationen var rörig.
- Fragmenterad (samma information fast på olika sätt på olika ställen, för många sektioner).
- Mappar kallades upprepade gånger för "namespace", fast det är tydligt att vi jobbar i ett enda namespace så skapade det ett rörigt och väldigt komplext intryck.
- Lite nitpick, men om Clean Code är något vi skall sträva efter så borde klasserna heta CarImplementation och MotorcycleImplementation, inte "Impl". Jag döpte om dem.
- Vissa segment är förvirrande. "using Models" är tydligt, men "namespace Factories" är det inte. I det här fallet menades "WhateverNamespaceName.Factories". Otydligt.
- En del andra småfel som påverkar helhetsintrycket: i .md-filen Motorcycle.Impl har vi titeln "Car implementation", fyra filer har trasiga klassdiagram (unable to render rich display - CarImpl.md, ICar.md, Imotorcycle.md, IVehicle.md), och slutligen så har reflections.md-filen problem med teckenuppsättningar: å, ä och ö står som �.

Ovanstående var första-intrycket, det var lite som när vi kör bil i dimma. Jag såg vägmarkeringarna och förstod var jag skulle, men sikten grumlades av störande element. När det gäller själva uppgiften så tyckte jag den var tydlig: Vi har färdig kod och instruktioner för arkitekturen, så det är bara att skapa layouten, lägga in elementen och sedan börja knyta ihop dem.

Här kommer direkt en varningsklocka från erfarenhet från tidigare uppgifter: Det är alltid lättast att bygga element ett i taget, och se till att hålla bort alla varningar och felmeddelanden direkt. Då blir det mycket lättare att felsöka och revertera en implementation som blivit fel.

I detta projekt är det naturligt att börja med att lägga in Program-koden med Main-segmentet direkt, och då kan det lätt bli rörigt om vi skall lägga till en klass/interface/metod i taget, vi kommer inte kunna köra main om inte hela layouten finns! Det är också väldigt svårt att jobba i någon annans kod, innan du satt dig in i den.

Nu kommer vi till planering/genomförande ->

--- Skriv ovanför och ta inte bort denna raden ---

## Planering och genomförande

### Vilka steg tog du för att lösa uppgiften?

Intro: Som nämnts ovan så tänkte jag igenom riskerna med att skapa hela projektet vs att jobba modulärt. Det är alltid önskvärt att jobba modulärt. Eftersom vi egentligen har ett större ramverk redan så valde jag att skapa alla klasser och interface, de kan ju finnas utan kod initialt och sedan bygger vi på därifrån. Vid behov kan jag kommentera bort kod i Program/Main och sedan arbeta "modulärt" på det här sättet.

1. Läste igenom allt projekt-underlag för att få en övergripande bild.

2. Skapade mapp- och filstrukturen och började ta grundtemplates från materialet vi hade tillgång till. Vi hade ju punkten "Steg-för-steg-arbetsgång" så de klasserna skapade jag tidigt.

3. Satte upp en ny github-repository och initialiserade projektets mapp genom bash (git init, git remote add origin etc).

4. Började dokumentera i denna fil, och valde sedan att omgående kopiera mitt privata repository till att göra ett internt repo inom CLO24 istället.

5. Skapade properties och metoder i CarImpl.cs

6. Skapade en branch, feature/creating-mechanics och började jobba i den.

7. Kopierade koden från CarImpls.cs till MotorcycleImpl.cs och modifierade den för att passa bättre till en motorcykel.. passade på att byta Impl till Implementation, så vi håller Clean Code så gott vi kan.

8. Jag kom hit innan jag hittade den smått gömda filen project.md! Där finns steg för steg-guider som mer eller mindre visar på allt jag skrev ovanför, haha. Nu är det dags för buggfixande, jag har 6 st errors och 0 warnings. Det var följande:
- CS0246, råkade göra ett ínt istället för int!
- CS0738, kunde inte implementera ICar.Doors för att int var felstavat, se ovan.
- CS1061, saknade metoderna CreateCar och CreateMotorcycle

9. Testkör programmet: Det funkade bra!

10. Så nu ville jag bara testa att printa ut Drive()-metoden med:
![testrun_withdrivemethod](image-1.png)

11. Eftersom vi hade fyra metoder som var gemensamma så återanvände jag dem:
IsEngineOn, StartEngine, StopEngine, Drive. De samlade jag i en klass som jag kallade VehicleFoundation. Det blev mycket mindre kod, mer kontroll med alla metoder i en, och följer Clean Code.

12. Uppdaterade Readme.md

13. Nu har vi ett fungerande program som kan köra Program.cs. Vi skulle inte ändra interfacet, och det gjorde jag inte men har valt att använda VehicleFoundation, som nämns i punkt 11. Vi anropar IVehicle. Nästa steg är att se hur vi kan optimera koden utan att göra den alltför abstrakt och oläsbar! I det här läget kollar jag med ChatGPT vad den tycker om koden enligt Clean Code-principer:

![cleancode_validation_according_to_chatgpt](image-2.png)
- Här ger även ChatGPT ett par förslag till "förbättringar" av koden, se punkt 2 under implementeringsval!

14. Clean Code: Sätter default values för att undvika null i CarImplementation och MotorcycleImplementation-konstruktorerna.

15. Inkapsling A: Konstruktorn VehicleFoundation public -> protected. Klasserna MotorcycleFactory och CarFactory var redan internal, men satte även metoderna där internal.

16. Inkapsling B: Det här blir ett rejält ingrepp i koden! Jag vill göra alla properties private set, så de inte kan modifieras utifrån. För att kunna göra dem "private set" samtidigt som jag jobbar med interface så skapar vi ett mellansteg där Brand, Model, Year, Mileage får bli InternalBrand, etc. I konstruktorn VehicleFoundation så gör vi sedan InternalBrand = brand, etc.
- Som en följd av detta behöver vi även justera koden på rätt många ställen: Brand får heta InternalBrand, etc. Se utmaningar punkt 4.

17. Refaktorering av Main: Vi gör flera funktioner för varje fordon vi printar, det går att bryta ner i metoder för att hålla Program/Main mer ren. Skapade metoderna:
- CreateAndDisplayVehicles: Skapar instanserna och kör metoderna för att skapa fordon
- CreateVehicle: Skapar fordon
- DisplayVehicleDetails: Printar ut informationen om varje fordon

18. Skapade VehicleTypeName i VehicleFoundation. La till raden nedan i Car/Motorcycle där de justerar Vehicle till Car eller Motorcycle.
```cs
protected virtual string VehicleTypeName => "Vehicle";
```
Detta gör att jag kan printa ut fordonstypen på ett lätt/snyggare sätt. När jag justerade ToString() i VehicleFoundation-klassen skulle jag kunnat lägga till fordonsspecifika detaljer som till exempel Door (Car) eller EngineType (Motorcycle). Det är en möjlighet att få programmet att växa där senare.

19. Mergeade branchen med main. Nu har vi ett bra program som funkar med refaktorerade metoder i Main, och vi har kommit till steg 13 i project.md-filen vi jobbar efter: Polymorfism. Steg ett där är att "döda" vår Main och skapa en ny. Så jag skapar en helt ny branch för detta, då har vi kvar branchen feature/creating-mechanics som vi kan återskapa om vi behöver. Nu gör vi branchen feature/endgame

20. Det här är en större punkt eftersom det är en partiell re-write av Program.cs. Jag skriver ner de justeringar jag gjort nedan:
- Skapar metoden CreateVehicleList: här lägger vi till fordon
- Skapade en List som använder information i IVehicle och tar emot vehicles.Add
- Skapar metoden DisplayAllVehicles(vehicles) som skriver ut ovanstående lista
- Sedan kommer Fabriken:
IVehicle CreateVehicle(CarFactory, bilspecifika parametrar)
IVehicle CreateVehicle(MotorcycleFactory, motorcykelspecifika parametrar) etc.
Den fabriken går att utöka såklart, jag planerar att lägga till Truck eller Bus. (Edit; Det blev Tractor).
- Skapar metoden DisplayVehicleDetails: skriver ut till konsollen

21. Skapar dokumentet factorystructure.sql och bifogar i Docs-foldern. Fick hjälp av ChatGPT. Infogar den här:

![factory_chart](factorystructure.png)

22. NÖRD DELUXE! Jag har gjort en random-shuffle-List som printar fordonen i random order.. mest för att det är kul. Ville också göra något som kanske ingen annan gör. Använde Fisher-Yates algoritm. Skälet: Jag vet hur jag gör en Random rng = new Random(), men jag ville ha en enkel algoritm som kan cykla igenom vår List av fordon. Bad ChatGPT om en lösning; den här byter plats på objekten så den går att köra som en "sorteringsalgoritm" i en egen metod! Snyggt! Har kommenterat den rad för rad i programmet om någon skulle undra vad den gör.

23. Koden komplett, vi skulle kunna lämna in det nu, men jag vill gärna visa att verktygen fungerar och skapa något annat så jag lägger till fordonet Tractor.
- ITractor.cs, TractorImplementation.cs, TractorFactory.cs och den nödvändiga koden i Program.

24. Ville lägga till en fordons-specific metod till, så åtminstone en av dem har två. Det vore tråkigt att lägga till en generisk färg (den påverkar alla) så jag skapade vikt i ton på traktorn.

25. Går igenom Reflections.md och kommentarerna i programmet. Städar upp inför inlämning. Flyttar ordning på metoder och kod-block så de följer Clean Code (ligger i den ordning de körs), samt för att se till att de ligger likadant i sina syskonklasser (konsekvent, lättare att läsa, lättare att hitta).

26. När jag går igenom koden en sista gång så tänker jag på två saker:
- TractorImplementation hade missat en rad som Car- och Motorcycle- hade:
```cs
protected override string VehicleTypeName => "Tractor";
```
Har lagt till den raden! Annars hade vi skrivit ut "Vehicle" istället för Tractor..
- Jag saknar en exception check i Main på t ex Doors, Weight, etc. Löser det genom att skapa ett try-catch-block. Se implementeringsval nr 4.

27. Programmering är verkligen lustigt, det går alltid hitta saker att förfina! Nu bytte jag ut if-else-styckena i DisplayOriginalAndModifiedVehicles + DisplayVehicleDetails mot switch statements. Det blir kortare kod, lättare att implementera, och en jättevinst: med "default" så har vi en automatisk default-statement den faller tillbaka på om koden inte fungerar! Tydligt!

28. Refakturering av Program.cs och skapande av VehicleInitializer.cs-klassen. Se implementeringsval nr 5.

29. Jag avslutade med att uppdatera detta dokument, ladded up den + kod och kollade sedan så allt stämde med .gitignore. Det gjorde det inte, så fick lägga till ignore på några filer och ta bort lite filer från mitt repository.

--- Skriv ovanför och ta inte bort denna raden ---

## Utmaningar och lösningar

### Vilka utmaningar stötte du på under projektet?

1. Den absolut första utmaningen var att jobba med (halv-)färdig kod och en layout som jag inte skapat själv.

2. Den andra utmaningen var att jag råkade skapa en copy efter jag gjorde en fork i Git, så jag hade en extra kopia av projektet nestlad inuti min mappstruktur.

3. När jag slog ihop fyra metoder till VehicleFoundation.cs så fick jag varningar om non-nullable-deklarationer (CS8618). De låg i properties från IVehicle när de initialiseras.

4. Ny instans av Brand, Model etc. Detta skapar följproblem i formen av att: Vi kan inte fritt använda Ctrl+R och byta namn på alla, vi har ju nästlat in originalvariabeln bakom skydd, men här är felkodsrutan och/eller ChatGPT väldigt väldigt bra hjälpmedel.

5. Följproblem av ovan instansiering: Nu når vi inte Drive()-metoden.

6. Noterade att "modify"-linjen på doors/engine är statisk. Modify-strängen ligger som en separat repeterad kodsträng! Alla modifierade dörrar blir 5 st och alla modifierade motorer Inline-4..

7. Följdproblem på ovanstående: Koden ger inga felmeddelanden men den slumpar ändå inte fram en modifikation.

8. När jag gick igenom alla filer i slutet innan inlämning så noterade jag att jag ärvt IDriveable i IVehicle (IVehicle: IDriveable). Eftersom vi inte fick ändra i interface-definitionerna så måste jag lösa detta på ett annat sätt!

--- Skriv ovanför och ta inte bort denna raden ---

### Hur löste du dessa utmaningar?

1. Jag läste noga igenom dokumentationen flera gånger och skapaden en plan för implementation steg-för-steg.

2. git -ls -la och sedan rm -rf (namnetpåmappen). Det hade säkert gått lika bra att bara deletea mappen direkt i Windows, men vill ha för vana att använda Bash och CLI.

3. Det finns två lösningar: Antingen följande
```cs
public string Brand { get; set; } = string.Empty; // Defaults to an empty string 
```
Eller så löser vi det genom att skapa en konstruktor som sätter default-värden för Brand, Model, Year och Mileage (det gör vi i Motorcycle- och CarImplementation.cs idag).
string.Empty är en enkel lösning, den senare lösningen gör koden lättare att återanvända, men den blir svårare att läsa och jobbigare om vi skall in och pilla i koden. Jag väljer string.Empty-lösningen! Bonus: Då pillar vi inte på Implementation-filerna.

4. Jag fick 15 errors bara av denna lilla justering, men kopierade/klistrade hela felkodsrutan och frågade bara ChatGPT var jag behöver justera namnen på grund av den nya instansieringen. Ett annat alternativ hade varit att klicka varje felkod för att komma till rätt kod och justera den vägen.

5. Det går att instansiera den i Program/Main, genom att exempelvis köra följande:
```cs
IDriveable driveableCar = (IDriveable)car;
```
Dels blir det väldigt grötigt i Main (inte särskilt Clean Code!), dels fanns det en enklare lösning: Vi extendar IVehicle från public interface IVehicle till public interface IVehicle : IDriveable. Uppdatering! Se punkt 8, vi skulle inte ändra i Interfaces så jag har reverterat denna ändring och löst det på ett annat sätt istället!

6. Jag ser flera lösningar:
- Specifik modifikation: för varje fordon direkt i Program-klassen när fordonet skapas. Nackdel: Det blir repetativt om vi har många fordon.
- Randomiserad modifikation: Skapa en List för Door, en för EngineType, etc, och välj ett randomiserat värde från listan. Dynamiskt och intressanta variationer. Nackdel: Inte särskilt realistiskt kanske om en 100cc-MC får en Honda CBX 6-cylindrig motor..
- En kul grej? Vore om vi kunde återanvända ShuffleList, vi har redan den i Program för att randomisera vilken ordning vi presenterar fordonen. Kan vi använda även till detta? Träna på återanvända kod?
- Lösningen till slut!
Jag skapade metoden ApplyVehicleModifications, det är två statiska listor (door modification har 2, 3, 4, 5 dörrar och engine har fyra olika motoralternativ).
- Den återanvänder koden från ShuffleList! Mycket nöjd!

7. Bytte ut följande kod med koden nedanför:
```cs
car.Doors = carDoorModifications[new Random().Next(carDoorModifications.Count)];
// Ny kod nedanför
car.Doors = carDoorModifications[tempRandom.Next(carDoorModifications.Count)];
```
- Skillnaden är att vi skapar en separat ny random-instans för varje gång vi randomiserar koden, annars kan det ställa till det när vi kör ShuffleList simultant. Tog även bort det hardkodade default-värdet som jag satt i DisplayVehicleDetails. Dels skriver den över det slumpade värdet, dels så är den överflödig för vi slumpar ändå fram ett värde till variabeln..

8. Jag hade gjort en enkel lösning i DisplayVehicleDetails-metoden:
```cs
Console.WriteLine(vehicle.Drive());
```
Men nu när inte IDriveable kunde ärvas av IVehicle så löser jag det istället genom att göra en if-else-check:
```cs
if (vehicle is IDriveable driveableVehicle)
{
    Console.WriteLine(driveableVehicle.Drive());
}
else
{
    Console.WriteLine("This vehicle cannot be driven.");
}
```

--- Skriv ovanför och ta inte bort denna raden ---

### Beskriv några implementeringsval du gjort?

1. Det första riktigt stora implementeringsvalet jag gjorde vara skapandet av VehicleFoundation-klassen. Den har jag beskrivit ovan, men:
- Vi hade fyra metoder som var gemensamma för alla Vehicles: IsEngineOn, StartEngine, StopEngine, Drive. Nu samlas de ihop till en klass istället för i varje ny fordonstyp. DRY (Don't repeat yourself)
- Tänk modulärt: Vad händer om vi skapar fler gemensamma metoder och/eller fler vehicles? Säg att vi först skapar fler fordon: Tractor, Bus, Truck, Snowmobile, Bycycle etc. Sedan får vi för oss att vi vill ge alla fordon en gemensam metod: VehicleColour(). Behåller vi metoderna inom de respektive klasserna får vi skriva denna metod fem gånger till. Då har vi sju instanser av varje metod, som gör exakt samma sak! Detsamma gäller för alla fordon vi skapar, de kan lätt återanvända de gemensamma metoderna direkt från VehicleFoundation.
- Det gör också koden mer läsbar. Kan vi hålla koden kortare och kalla på samma kod upprepade gånger så är det verkligen Clean (Code).

2. ChatGPTs förslag till refaktorerings-optimisering:
- Den föreslår "constructor chaining", dvs jag skapar en konstruktor i CarImplementation som kallar på klassens konstruktor. Det ger en väldigt "clean" CarImplementation:
```cs
namespace CLO24_SecondTurnInNiklasH.Models
{
    using Interfaces;

    public class CarImplementation : VehicleFoundation, ICar
    {
        // Property specific to Car
        public int Doors { get; set; }

        // Constructor to initialize properties, calling the base class constructor
        public CarImplementation(string brand, string model, int year, double mileage, int doors)
            : base(brand, model, year, mileage)
        {
            Doors = doors;
        }

        // Additional car-specific methods can be added here if needed
    }
}
```
Jag valde att implementera den konstruktorn, men justerade koden vidare senare när jag satte åtkomstdirektiven mer begränsande ( get; private set; ), då skapades en InternalDoor-variabel som mellaninstans så hela Doors-biten justerades. Men: lösningen ovan, i princip, användes.

- Medan punkt ett här är ett implementeringsval som styrdes av planering, så var punkt två en konsekvens av refaktorering.
- Då vill jag gärna visa på ett exempel på en implementering som blev en konsekvens av en problemlösning med:

3. Se punkt 16 i utvecklingsstegen. Inkapslingen skapade problem med åtkomst, och jag ville verkligen skydda en del kod, bland annat genom private set. Lösning var att skapa ytterligare en instans av variablerna: Brand, Model, Year, Doors, engineType.
- Skapade InternalBrand, InternalModel, InternalYear, InternalMileage, InternalDoors, InternalWeight, InternalUtilityTool och InternalEngineType.
- Vi kan se hur det hanteras i VehicleFoundation, Tractor- Car- och MotorcycleImplementation:
```cs
var IVehicle.Brand // Eller fordonsspecifik
{
    get => InternalBrand;
    set => InternalBrand = value;
}
```
Vad de gör är att de hanterar get/set inom en egen instans, på så sätt finns ingen åtkomst utifrån där "fel" instans kan modifiera värdena.
Det gör att vi kan ha private set och hantera värdena i ett separat steg utanför den centrala instansen.

4. Skapade två try-catch block med exception handling i Program.cs. Så kan vi skapa snyggare error handling genom logging, och visa på olika användning av det (använder Exception två gånger och ArgumentException en gång, den hanterar inputvalidation specifikt för om argumentationen blir fel). Renare. Lättare felsöka.
- Det blir ett större ingrepp i Program.cs, men jag tycker att det är en bra vana att alltid göra exception handling. Det kommer från när jag skapade databaser och databasanslutningar. Att skapa ett try-catch-block där vi får en proper feedback (exception message) om någonting går fel är aldrig en dålig grej. Det finns så mycket att vinna. Felsökning i synnerhet.

5. Valde att skapa en ny klass: VehicleInitializer.cs där jag la all kod som är relaterad till att skapa fordon från Program.cs, så det enda Program.cs gör nu är att Main kallar VehicleInitializer.RunFactory-metoden, och sedan kör den FactoryShutdown när fabriken skall stängas.
- Det är egentligen ytterligare refaktorering. Att hålla koden clean. Men nu har vi all fordonskontroll i sin egen klass, och programfunktioner i program. Förutom att det är tydligt så skapar det även - återigen - bättre förutsättningar för att ha ett modulärt program. Det är lättare att lägga till/ta bort om vi segmenterar koden. Det här är också så jag gärna skriver program själv så skall jag sätta en personlig prägel på detta så är det här en bra illustration på "mitt" språk. Jag fick justera RunFactory och FactoryShutdown från private till internal för att kunna kalla på dem men det var en mindre justering.

6. Jag vill också skriva ett val jag INTE gjorde! Ett alternativ jag hade var att justera hela "fabriken", det vill säga:
```cs
// This below section is the "Factory". Utilizing the factory pattern to create vehicles, this can be expanded to include more vehicle types
private static IVehicle CreateVehicle(CarFactory factory, string brand, string model, int year, double mileage, int doors) // Note: doors
{
    return factory.CreateCar(brand, model, year, mileage, doors);
}

private static IVehicle CreateVehicle(MotorcycleFactory factory, string brand, string model, int year, double mileage, string engineType) // Note: engineType
{
    return factory.CreateMotorcycle(brand, model, year, mileage, engineType);
}

private static IVehicle CreateVehicle(TractorFactory factory, string brand, string model, int year, double mileage, string utilityTool, double weight) // Note: utilityTool, weight
{
    return factory.CreateTractor(brand, model, year, mileage, utilityTool, weight);
}
```
- Ett annat sätt att skriva den koden på hade kunnat vara följande:
```cs
public class VehicleParameters
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Mileage { get; set; }
    public int? Doors { get; set; } // Optional, for cars only
    public string EngineType { get; set; } // Optional, for motorcycles only
    public string UtilityTool { get; set; } // Optional, for tractors only
    public double? Weight { get; set; } // Optional, for tractors only
}
```
- ..och sedan välja att skapa objekten genom följande kod:
```cs
private static IVehicle CreateVehicle(IVehicleFactory factory, VehicleParameters parameters)
{
    return factory switch
    {
        CarFactory carFactory => carFactory.CreateCar(parameters.Brand, parameters.Model, parameters.Year, parameters.Mileage, parameters.Doors ?? 0),
        MotorcycleFactory motorcycleFactory => motorcycleFactory.CreateMotorcycle(parameters.Brand, parameters.Model, parameters.Year, parameters.Mileage, parameters.EngineType),
        TractorFactory tractorFactory => tractorFactory.CreateTractor(parameters.Brand, parameters.Model, parameters.Year, parameters.Mileage, parameters.UtilityTool, parameters.Weight ?? 0),
        _ => throw new ArgumentException("Unsupported vehicle factory.")
    };
}
```
- Så långt ser det rätt snyggt ut, eller hur? Något långa strängar i switchen och inte helt lättläst kanske, men mindre kod och lättare att lägga till objekt kanske? Men! Det absolut största skälet till att jag inte ville göra så här var för att det blir en otroligt massa text att skriva i form av följande:
```cs
vehicles.Add(CreateVehicle(carFactory, new VehicleParameters
{
    Brand = "Toyota",
    Model = "Corolla",
    Year = 2020,
    Mileage = 15000,
    Doors = 4
}));
```
- Så vinsten med denna kod hade varit att vi får en kortare "skapa fordon"-kod. Men nackdelen hade varit att vi hade fått oändligt många rader text för alla objekt vi lägger till! Det blir inte alls lättläst och väldigt jobbigt att scrolla. Hur vi än gör så går vi lite emot Clean Code i båda fallen, men jag vet att Uncle Bob nämner i Clean Code att ibland så är vi tvungna att repetera kod, även om avsikten bör vara att undvika det. Därför väljer jag att hellre ha de fåtalet extra strängarna i min switch när jag skriver ut fordonen. Om vi hade haft väldigt väldigt många fordonstyper, då hade jag övervägt en annan lösning.

--- Skriv ovanför och ta inte bort denna raden ---

## Reflektion och utvärdering

### Vad lärde du dig genom att genomföra projektet?

- Egentligen använde jag mestadels verktyg som jag redan använt tidigare, men två saker som jag faktiskt både velat göra och nu fick möjlighet till var:

1. Dels så var det kul att få börja jobba i ett projekt som redan var påbörjat, någon annans kod och struktur. Det kräver ett annat tänk och ger andra utmaningar än att starta från scratch. Bra erfarenhet inför framtiden och någonting jag gärna provar på fler gånger inom en snar framtid.

2. Dels har jag länge velat göra switch-statements istället för if-else-satser, jag ser många fördelar med det! Tydligt, säkrare, snyggare, mindre nestling, mindre minneskrävande. Nu fick jag ett ypperligt tillfälle att testköra det! Mycket mycket nöjd med den implementationen.

3. En liten bonus, den nämner jag i punkt tre i 'framtida projekt' nedanför.

4. Planeringen visste jag var viktig, av erfarenhet, men även att veta när det är dags att sätta punkt. Det här projektet hade kunnat växa hur mycket som helst. Det är viktigt att sätta ramverk, och jag tar med mig att även om jag redan vet det, och har erfarenhet, så var det ändå bra att ha en checklista "det här skall göras", och det här dokumentet som följer upp projektets utveckling.

Jag har redan gjort mer än vad vi skulle, men det har jag gjort för att tiden fanns och framförallt för att det var kul (och kul att utmana sig själv, med!). Har ändå med mig någonstans att struktur och ramar är absolut nödvändigt för att kunna lägga upp en plan, följa planen, avsluta den. Det blir som en naturlig agil mini-sprint, detta!

--- Skriv ovanför och ta inte bort denna raden ---

### Vilka möjligheter ser du för framtida projekt baserat på denna erfarenhet?

1. När jag skapade en extra instans av Brand, Model etc så öppnade det en massa dörrar med. Jag har såklart instansierat förut, men att göra det på detta sätt för att kunna köra get; private set och även hålla väldigt rena/refaktorerade interfaces/fabriker var riktigt trevligt. Jag tror att hade jag byggt vidare på detta projekt så hade jag nog gjort följande: Klämt ihop alla interfaces i ett enda .cs-dokument och alla factories i ett annat. Nu skulle vi inte röra de filerna, men jag ser en möjlighet att streamlinea kod/filer på det viset, i alla fall i ett sådant här projekt där filerna är så få.
- En sidofråga där är dock, är det risk att vi käkar mer minne om vi laddar in mer info? Skulle det varit fördelaktigt att ha kvar små kodblock i varsin fil i en Interfaces-folder, till exempel? Det kan vara en fördel med om de interfacen är en del av ett stort projekt, att de ligger i en mappstruktur som ingen av utvecklarna sedan skall röra. Bara använda.

2. Nu känns det naturligt att implementera unit testing, koden är så segmenterad redan att jag tror det vore både lätt och ett bra sätt att utveckla båda färdigheter och programmet i sig.

3. Det var kul att jobba med mappar/folders, där ser jag större möjligheter i framtida projekt. Jag brukar alltid ha en lång lista (segmenerat koden!) med .cs-filer, men när vi gör på det här sättet så kan vi ju välja "using" och bara implementera det vi behöver använda för stunden. Det skulle vara väldigt lätt att strukturera upp mina program på ett smartare sätt i framtiden! Bra erfarenhet.

4. Hela fabriken och strukturen med Interfaces var kul att prova, alla små kodexempel vi skrivit har tidigare inte lyckats göra riktigt nytta av de verktygen. Nu kunde vi se när det faktiskt kan göra skillnad. Jag kan se fabriks- eller andra strukturer göra nytta i olika projekt.

--- Skriv ovanför och ta inte bort denna raden ---