﻿using System.Reflection;
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
            const int stoonyRarity = 60;
            const int maeRarity = 60;
            const int nicoRarity = 60;
            Item stoony = _assets.LoadAsset<Item>("Assets/Meet And Huh/Pyrastoony.asset");
            Item mae = _assets.LoadAsset<Item>("Assets/Meet And Huh/Maeball.asset");
            Item nico = _assets.LoadAsset<Item>("Assets/Meet And Huh/Nicocube.asset");
            NetworkPrefabs.RegisterNetworkPrefab(stoony.spawnPrefab);
            Items.RegisterScrap(stoony, stoonyRarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(mae.spawnPrefab);
            Items.RegisterScrap(mae, maeRarity, Levels.LevelTypes.All);
            NetworkPrefabs.RegisterNetworkPrefab(nico.spawnPrefab);
            Items.RegisterScrap(nico, nicoRarity, Levels.LevelTypes.All);
            Logger.LogInfo("Registered items.");
        }
    }
}