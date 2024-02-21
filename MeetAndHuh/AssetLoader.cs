using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MeetAndHuh;

public static class AssetLoader
{
    public static AssetBundle LoadEmbeddedAssetBundle(Assembly assembly, string name)
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