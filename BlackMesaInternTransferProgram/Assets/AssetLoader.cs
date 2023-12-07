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
                
                str.CopyTo(memoryStream);
                Plugin.StaticLogger.LogInfo("Loading assetBundle from data, please be patient...");
                byte[] resource = memoryStream.ToArray();
                
                Plugin.StaticLogger.LogInfo("Loading assetBundle from data, please be patient...");
                bundle = AssetBundle.LoadFromMemory(resource);
                Plugin.StaticLogger.LogInfo("Done!");
            }
            return bundle;
        }
        
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
        
        public static byte[] GetResourceBytes(Assembly assembly, string name)
        {
            foreach (string resource in assembly.GetManifestResourceNames())
            {
                if (resource.Contains(name))
                {
                    using (Stream resFilestream = assembly.GetManifestResourceStream(resource))
                    {
                        if (resFilestream == null) return null;
                        byte[] byteArr = new byte[resFilestream.Length];
                        resFilestream.Read(byteArr, 0, byteArr.Length);
                        return byteArr;
                    }
                }
            }
            return null;
        }
}