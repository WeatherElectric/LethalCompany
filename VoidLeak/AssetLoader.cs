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
    private const int ExpensiveItemRarity = 30;

    public static void LoadBundle()
    {
        _assets = LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "VoidLeak.Resources.Assets.pack");
    }

    private const string AssetsPath = "Assets/VoidLeak";
    public static void LoadItems()
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