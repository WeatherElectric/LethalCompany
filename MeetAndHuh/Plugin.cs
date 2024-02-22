using System.Reflection;
using BepInEx;
using UnityEngine;
using LethalLib.Modules;

namespace MeetAndHuh
{
    public class ModInfo
    {
        public const string PluginGuid = "SoulWithMae.MeetAndHuh";
        public const string PluginName = "MeetAndHuh";
        public const string PluginVersion = "1.0.0";
    }
    
    [BepInPlugin(ModInfo.PluginGuid, ModInfo.PluginName, ModInfo.PluginVersion)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    public class Plugin : BaseUnityPlugin
    {
        private static AssetBundle _assets;
        private void Awake()
        {
            Logger.LogInfo($"Plugin {ModInfo.PluginGuid} is loaded, version {ModInfo.PluginVersion}");
            _assets = AssetLoader.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MeetAndHuh.Resources.Assets.pack");
            Logger.LogInfo("Loaded asset bundle. Registering items.");
            const int rarity = 60;
            Item stoony = _assets.LoadAsset<Item>("Assets/Meet And Huh/Stoonyangle.asset");
            Item mae = _assets.LoadAsset<Item>("Assets/Meet And Huh/Maeball.asset");
            Item nico = _assets.LoadAsset<Item>("Assets/Meet And Huh/Nicocube.asset");
            Item dex = _assets.LoadAsset<Item>("Assets/Meet And Huh/Harlowcan.asset");
            Item ham = _assets.LoadAsset<Item>("Assets/Meet And Huh/Hamblob.asset");
            Item z = _assets.LoadAsset<Item>("Assets/Meet And Huh/Zenithcone.asset");
            NetworkPrefabs.RegisterNetworkPrefab(stoony.spawnPrefab);
            Items.RegisterScrap(stoony, rarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(mae.spawnPrefab);
            Items.RegisterScrap(mae, rarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(nico.spawnPrefab);
            Items.RegisterScrap(nico, rarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(dex.spawnPrefab);
            Items.RegisterScrap(dex, rarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(ham.spawnPrefab);
            Items.RegisterScrap(ham, rarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(z.spawnPrefab);
            Items.RegisterScrap(z, rarity, Levels.LevelTypes.All);
            Logger.LogInfo("Registered items.");
        }
    }
}