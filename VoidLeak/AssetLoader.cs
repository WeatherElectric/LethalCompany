using System.IO;
using System.Linq;
using System.Reflection;
using LethalLib.Modules;
using UnityEngine;

namespace VoidLeak;

public static class AssetLoader
{
    private static AssetBundle _assets;
    
    private const int SmallItemRarity = 50;
    private const int BigItemRarity = 45;
    private const int ExpensiveItemRarity = 30;
    private const int DebugRarity = 100;

    public static void LoadBundle()
    {
        _assets = LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "VoidLeak.Resources.voidleak");
    }

    private const string AssetsPath = "Assets/VoidLeak";
    public static void LoadItems()
    {
        Item apollo = _assets.LoadAsset<Item>($"{AssetsPath}/Apollo.asset");
        Item blueApollo = _assets.LoadAsset<Item>($"{AssetsPath}/BlueApollo.asset");
        Item goldenApollo = _assets.LoadAsset<Item>($"{AssetsPath}/GoldApollo.asset");
        Item crablet = _assets.LoadAsset<Item>($"{AssetsPath}/Headset.asset");
            
        NetworkPrefabs.RegisterNetworkPrefab(apollo.spawnPrefab);
        Items.RegisterScrap(apollo, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(blueApollo.spawnPrefab);
        Items.RegisterScrap(blueApollo, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(goldenApollo.spawnPrefab);
        Items.RegisterScrap(goldenApollo, ExpensiveItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(crablet.spawnPrefab);
        Items.RegisterScrap(crablet, SmallItemRarity, Levels.LevelTypes.All);
    }

    private static AssetBundle LoadEmbeddedAssetBundle(Assembly assembly, string name)
    {
        string[] manifestResources = assembly.GetManifestResourceNames();
        AssetBundle bundle = null;
        if (manifestResources.Contains(name))
        {
            using Stream str = assembly.GetManifestResourceStream(name);
            using MemoryStream memoryStream = new MemoryStream();

            str?.CopyTo(memoryStream);
            byte[] resource = memoryStream.ToArray();
            
            bundle = AssetBundle.LoadFromMemory(resource);
        }
        return bundle;
    }

}