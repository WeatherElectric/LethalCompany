using System.IO;
using System.Linq;
using System.Reflection;
using LethalLib.Modules;
using UnityEngine;

namespace MeetAndHuh;

public static class AssetLoader
{
    private static AssetBundle _assets;
    
    private const int SmallItemRarity = 60;
    private const int BigItemRarity = 45;

    public static void LoadBundle()
    {
        _assets = LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MeetAndHuh.Resources.Assets.pack");
    }

    private const string GeometryPath = "Assets/MeetAndHuh/Geometry";
    public static void LoadGeometry()
    {
        Item stoony = _assets.LoadAsset<Item>($"{GeometryPath}/Stoonyangle.asset");
        Item mae = _assets.LoadAsset<Item>($"{GeometryPath}/Maeball.asset");
        Item nico = _assets.LoadAsset<Item>($"{GeometryPath}/Nicocube.asset");
        Item dex = _assets.LoadAsset<Item>($"{GeometryPath}/Harlowcan.asset");
        Item ham = _assets.LoadAsset<Item>($"{GeometryPath}/Hamblob.asset");
        Item z = _assets.LoadAsset<Item>($"{GeometryPath}/Zenithcone.asset");
        Item des = _assets.LoadAsset<Item>($"{GeometryPath}/Dessphere.asset");
        Item amalgamation = _assets.LoadAsset<Item>($"{GeometryPath}/Amalgamation.asset");
            
        NetworkPrefabs.RegisterNetworkPrefab(stoony.spawnPrefab);
        Items.RegisterScrap(stoony, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(mae.spawnPrefab);
        Items.RegisterScrap(mae, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(nico.spawnPrefab);
        Items.RegisterScrap(nico, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(dex.spawnPrefab);
        Items.RegisterScrap(dex, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(ham.spawnPrefab);
        Items.RegisterScrap(ham, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(z.spawnPrefab);
        Items.RegisterScrap(z, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(des.spawnPrefab);
        Items.RegisterScrap(des, SmallItemRarity, Levels.LevelTypes.All);
        NetworkPrefabs.RegisterNetworkPrefab(amalgamation.spawnPrefab);
        Items.RegisterScrap(amalgamation, BigItemRarity, Levels.LevelTypes.All);
    }

    private const string MarrowPath = "Assets/MeetAndHuh/Marrow";
    public static void LoadMarrow()
    {
        
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