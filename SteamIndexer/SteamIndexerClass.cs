using Gameloop.Vdf;

namespace SteamIndexer
{
    public class WindowsSteamIndxer
    {
        public List<GameObject> GamesList = new List<GameObject>();

        private List<String> SteamLibrariesList = new List<String> { "C:\\Program Files (x86)\\Steam\\steamapps" };

        public void addSteamLibrary(String libraryDir)
        {
            SteamLibrariesList.Add(libraryDir);
        }

        public void getDirectoryies()
        {
            SteamLibrariesList.ForEach(lib =>
            {
                var directories = Directory.GetFiles(lib).Where(x => x.Contains(".acf")).ToList();
                directories.ForEach(d =>
                {
                    dynamic game = VdfConvert.Deserialize(File.ReadAllText(d));
                    GamesList.Add(new GameObject(
                        game.Value.name.Value,
                        game.Value.appid.Value,
                        game.Value.installdir.Value,
                        game.Value.LauncherPath.Value
                    ));
                });
            });
        }
    }

    public class GameObject
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Directory { get; set; }
        public string LauncherPath { get; set; }

        public GameObject(string name, string id, string directory, string launcherPath)
        {
            Name = name;
            Id = id;
            Directory = directory;
            LauncherPath = launcherPath;
        }
    }
}