using SteamIndexer;

var indexer = new WindowsSteamIndxer();

indexer.getDirectoryies();


Console.WriteLine(indexer.GamesList);