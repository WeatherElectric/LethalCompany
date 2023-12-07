using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BlackMesaInternTransferProgram.Assets;

internal static class AssetLoader
{
    public static AssetBundle LoadEmbeddedAssetBundle(Assembly assembly, string name)
    {
        string[] manifestResources = assembly.GetManifestResourceNames();
        AssetBundle bundle = null;
        if (manifestResources.Contains(name))
        {
            Plugin.StaticLogger.LogInfo($"Loading embedded resource data {name}...");
            using Stream str = assembly.GetManifestResourceStream(name);
            using MemoryStream memoryStream = new MemoryStream();

            str?.CopyTo(memoryStream);
            Plugin.StaticLogger.LogInfo("Sending assetBundle data to memory...");
            byte[] resource = memoryStream.ToArray();
                
            Plugin.StaticLogger.LogInfo("Loading assetBundle from data, please be patient...");
            bundle = AssetBundle.LoadFromMemory(resource);
            Plugin.StaticLogger.LogInfo("Done!");
        }
        return bundle;
    }
        
    public static T LoadPersistentAsset<T>(this AssetBundle assetBundle, string name) where T : Object
    {
        Object asset = assetBundle.LoadAsset(name);

        if (asset != null)
        {
            asset.hideFlags = HideFlags.DontUnloadUnusedAsset;
            return asset as T;
        }

        return null;
    }
}