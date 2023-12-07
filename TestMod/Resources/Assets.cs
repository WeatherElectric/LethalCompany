using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using WrongLibWithTheWrongTechnique.Modules;

namespace TestMod.Resources;

internal static class Assets
{
    public static List<AudioClip> Screams = new();
    private static AssetBundle _bundle;
    
    public static void Load()
    {
        _bundle = AssetLoader.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "TestMod.Resources.screams.bundle");
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream01.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream1.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream02.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream2.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream03.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream3.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream04.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream4.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream05.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream5.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream06.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream6.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream07.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream7.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream08.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream09.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream10.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream11.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream12.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream13.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream14.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream15.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream16.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream17.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream18.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream19.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream20.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream21.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream22.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream23.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream24.wav"));
        Screams.Add(_bundle.LoadPersistentAsset<AudioClip>("Assets/scream25.wav"));
    }
}