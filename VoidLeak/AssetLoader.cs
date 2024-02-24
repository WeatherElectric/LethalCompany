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
    public static void LoadItems()
    {
        Item apollo = _assets.LoadAsset<Item>($"{AssetsPath}/Apollo.asset");
        Item blueApollo = _assets.LoadAsset<Item>($"{AssetsPath}/BlueApollo.asset");
        Item goldenApollo = _assets.LoadAsset<Item>($"{AssetsPath}/GoldApollo.asset");
        Item crablet = _assets.LoadAsset<Item>($"{AssetsPath}/Headset.asset");
        Item crowbar = _assets.LoadAsset<Item>($"{AssetsPath}/Crowbar.asset");
        Item bottle = _assets.LoadAsset<Item>($"{AssetsPath}/Bottle.asset");
        Item spawnGun = _assets.LoadAsset<Item>($"{AssetsPath}/SpawnGun.asset");
            
        NetworkPrefabs.RegisterNetworkPrefab(apollo.spawnPrefab);
        Items.RegisterScrap(apollo, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(blueApollo.spawnPrefab);
        Items.RegisterScrap(blueApollo, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(goldenApollo.spawnPrefab);
        Items.RegisterScrap(goldenApollo, SuperExpensiveItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(crablet.spawnPrefab);
        Items.RegisterScrap(crablet, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(crowbar.spawnPrefab);
        Items.RegisterScrap(crowbar, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(bottle.spawnPrefab);
        Items.RegisterScrap(bottle, CheapItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(spawnGun.spawnPrefab);
        Items.RegisterScrap(spawnGun, ExpensiveItemRarity, Levels.LevelTypes.All);
    }
}