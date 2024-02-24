using System.IO;
using System.Reflection;
using LethalLib.Modules;
using UnityEngine;

namespace VoidLeak;

public static class AssetLoader
{
    private static AssetBundle _assets;

    private const int CheapItemRarity = 75;
    private const int SmallItemRarity = 50;
    private const int BigItemRarity = 45;
    private const int ExpensiveItemRarity = 30;
    private const int SuperExpensiveItemRarity = 15;
    private const int DebugRarity = 100;

    public static void LoadBundle()
    {
        var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (assemblyLocation != null)
        {
            _assets = AssetBundle.LoadFromFile(Path.Combine(assemblyLocation, "voidleak"));
        }
        else
        {
            Plugin.mls.LogError("Failed to load asset bundle.");
            Plugin.mls.LogError("Check if the asset bundle is in the same directory as the plugin.");
        }
    }

    private const string AssetsPath = "Assets/VoidLeak";
    
    private const Levels.LevelTypes LowTierMoons = Levels.LevelTypes.AssuranceLevel | Levels.LevelTypes.ExperimentationLevel | Levels.LevelTypes.VowLevel;
    private const Levels.LevelTypes MidTierMoons = Levels.LevelTypes.MarchLevel | Levels.LevelTypes.OffenseLevel;
    private const Levels.LevelTypes HighTierMoons = Levels.LevelTypes.DineLevel | Levels.LevelTypes.TitanLevel | Levels.LevelTypes.RendLevel;
    public static void LoadItems()
    {
        Item apollo = _assets.LoadAsset<Item>($"{AssetsPath}/Apollo.asset");
        Item blueApollo = _assets.LoadAsset<Item>($"{AssetsPath}/BlueApollo.asset");
        Item goldenApollo = _assets.LoadAsset<Item>($"{AssetsPath}/GoldApollo.asset");
        Item crablet = _assets.LoadAsset<Item>($"{AssetsPath}/Headset.asset");
        Item crowbar = _assets.LoadAsset<Item>($"{AssetsPath}/Crowbar.asset");
        Item bottle = _assets.LoadAsset<Item>($"{AssetsPath}/Bottle.asset");
        Item spawnGun = _assets.LoadAsset<Item>($"{AssetsPath}/SpawnGun.asset");
        Item lunarLander = _assets.LoadAsset<Item>($"{AssetsPath}/LunarLander.asset");
        Item skull = _assets.LoadAsset<Item>($"{AssetsPath}/SkeleSkull.asset");
            
        NetworkPrefabs.RegisterNetworkPrefab(apollo.spawnPrefab);
        Items.RegisterScrap(apollo, SmallItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(blueApollo.spawnPrefab);
        Items.RegisterScrap(blueApollo, SmallItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(goldenApollo.spawnPrefab);
        Items.RegisterScrap(goldenApollo, SuperExpensiveItemRarity, LowTierMoons);
        Items.RegisterScrap(goldenApollo, ExpensiveItemRarity, MidTierMoons);
        Items.RegisterScrap(goldenApollo, BigItemRarity, HighTierMoons);
        
        NetworkPrefabs.RegisterNetworkPrefab(crablet.spawnPrefab);
        Items.RegisterScrap(crablet, SmallItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(crowbar.spawnPrefab);
        Items.RegisterScrap(crowbar, SmallItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(bottle.spawnPrefab);
        Items.RegisterScrap(bottle, CheapItemRarity, LowTierMoons);
        Items.RegisterScrap(bottle, SmallItemRarity, MidTierMoons);
        Items.RegisterScrap(bottle, BigItemRarity, HighTierMoons);
        
        NetworkPrefabs.RegisterNetworkPrefab(spawnGun.spawnPrefab);
        Items.RegisterScrap(spawnGun, ExpensiveItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(lunarLander.spawnPrefab);
        Items.RegisterScrap(lunarLander, ExpensiveItemRarity, Levels.LevelTypes.All);
        
        NetworkPrefabs.RegisterNetworkPrefab(skull.spawnPrefab);
        Items.RegisterScrap(skull, ExpensiveItemRarity, Levels.LevelTypes.All);
    }
}