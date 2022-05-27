namespace console_2048.StaticData;

public static class Configs
{
    private static readonly Dictionary<Type, Dictionary<string, Config>> _all;
    public static Library Library { get; }

    static Configs()
    {
        _all = new Dictionary<Type, Dictionary<string, Config>>();
        RegisterConfigs();
        Library = new Library();
    }

    private static void RegisterConfigs()
    {
        var declarations = new Declarations();
        
        foreach (var declaration in declarations.All)
        {
            foreach (var config in declaration.Configs)
            {
                Register(config);
            }
        }
    }

    public static T Get<T>(string id) where T : Config
    {
        return (T)_all[typeof(T)][id];
    }
    
    public static List<T> GetAll<T>() where T : Config
    {
        return _all[typeof(T)].Select(x => (T)x.Value).ToList();
    }

    public static Config Get(Type type, string id)
    {
        return _all[type][id];
    }

    private static void Register(Config config)
    {
        if (!_all.TryGetValue(config.GetType(), out var result))
        {
            result = new Dictionary<string, Config>();
            _all[config.GetType()] = result;
        }

        result[config.Name] = config;
    }
}