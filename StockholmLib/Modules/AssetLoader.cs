using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace StockholmLib.Modules;

/// <summary>
/// Manages assetbundle loading from embedded resources.
/// </summary>
public static class AssetLoader
{
        /// <summary>
        /// Loads an embedded assetbundle
        /// </summary>
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
                Plugin.StaticLogger.LogInfo("Loading assetBundle from data, please be patient...");
                byte[] resource = memoryStream.ToArray();
                
                Plugin.StaticLogger.LogInfo("Loading assetBundle from data, please be patient...");
                bundle = AssetBundle.LoadFromMemory(resource);
                Plugin.StaticLogger.LogInfo("Done!");
            }
            return bundle;
        }

        /// <summary>
        /// Loads an asset from an assetbundle
        /// </summary>
        public static T LoadPersistentAsset<T>(this AssetBundle assetBundle, string name) where T : UnityEngine.Object
        {
            Object asset = assetBundle.LoadAsset(name);

            if (asset != null)
            {
                asset.hideFlags = HideFlags.DontUnloadUnusedAsset;
                return asset as T;
            }

            return null;
        }

        /// <summary>
        /// Gets the raw bytes of an embedded resource
        /// </summary>
        public static byte[] GetResourceBytes(Assembly assembly, string name)
        {
            foreach (string resource in assembly.GetManifestResourceNames())
            {
                if (resource.Contains(name))
                {
                    using Stream resFilestream = assembly.GetManifestResourceStream(resource);
                    if (resFilestream == null) return null;
                    byte[] byteArr = new byte[resFilestream.Length];
                    // ReSharper disable once UnusedVariable
                    var read = resFilestream.Read(byteArr, 0, byteArr.Length);
                    return byteArr;
                }
            }
            return null;
        }
}