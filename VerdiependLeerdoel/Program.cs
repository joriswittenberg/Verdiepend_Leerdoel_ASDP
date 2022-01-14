




using VerdiependLeerdoel.helpers;
using VerdiependLeerdoel.tables;

namespace VerdiependLeerdoel;

public class Program
{
    static void Main(string[] args)
    {

        MongoCRUD database = new MongoCRUD("ChipDistributionGame");
        testdata testdata = new testdata();

        //Game Settings zijn ingesteld
        var entities = testdata.getEntities();
        var rounds = testdata.GetRounds();
        var numberOfRounds = 1;
        var gameType = "LINEAR";
        var maxRoundTime = 10;

        //Game wordt gecreeërd
        var gameBase = database.createGame(numberOfRounds, gameType, maxRoundTime);
        database.insertRecord("Game", gameBase);

        //Spelers die joinen worden toegevoegd in de database
        database.addEntitiesInDatabase<Game>("Game", gameBase.GameId, entities);

        //Wanneer de ronde afgelopen is zal deze toegevoegd worden aan de database
        database.addRoundToDatabase<Game>("Game", gameBase.GameId, rounds);
    }

}

var watch = System.Diagnostics.Stopwatch.StartNew();

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine(elapsedMs);
