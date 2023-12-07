using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BlackMesaInternTransferProgram.Assets;

internal static class Resources
{
    private static AssetBundle _assetBundle;
    public static readonly List<AudioClip> Unknown = new();
    public static readonly List<AudioClip> Bludgeoning = new();
    public static readonly List<AudioClip> Gravity = new();
    public static readonly List<AudioClip> Blast = new();
    public static readonly List<AudioClip> Strangulation = new();
    public static readonly List<AudioClip> Suffocation = new();
    public static readonly List<AudioClip> Mauling = new();
    public static readonly List<AudioClip> Gunshots = new();
    public static readonly List<AudioClip> Crushing = new();
    public static readonly List<AudioClip> Drowning = new();
    public static readonly List<AudioClip> Abandoned = new();
    public static readonly List<AudioClip> Electrocution = new();

    public static void Load()
    {
        _assetBundle = AssetLoader.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "BlackMesaInternTransferProgram.Resources.Audio.bundle");
        
        #region Unknown
        
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream5.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream6.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream06.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream07.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream7.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream08.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream09.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream10.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream11.wav"));
        Unknown.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Unknown/scream12.wav"));
        
        #endregion
        
        #region Bludgeoning
        
        Bludgeoning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Bludgeoning/sci_pain3.wav"));
        Bludgeoning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Bludgeoning/sci_pain4.wav"));
        Bludgeoning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Bludgeoning/sci_pain9.wav"));
        Bludgeoning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Bludgeoning/scream11.wav"));
        Bludgeoning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Bludgeoning/stopattacking.wav"));
        
        #endregion
        
        #region Gravity
        
        Gravity.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Gravity/scream04.wav"));
        Gravity.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Gravity/scream06.wav"));
        Gravity.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Gravity/scream24.wav"));
        
        #endregion
        
        #region Blast
        
        Blast.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Blast/sci_fear6.wav"));
        Blast.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Blast/sci_pain4.wav"));
        Blast.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Blast/scream01.wav"));
        Blast.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Blast/scream3.wav"));
        Blast.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Blast/scream14.wav"));
        
        #endregion
        
        #region Strangulation
        
        Strangulation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Strangulation/sci_dragoff.wav"));
        Strangulation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Strangulation/sci_pain10.wav"));
        Strangulation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Strangulation/scream03.wav"));
        Strangulation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Strangulation/scream18.wav"));
        Strangulation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Strangulation/scream20.wav"));
        
        #endregion
        
        #region Suffocation
        
        Suffocation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Suffocation/c1a4_sci_tent.wav"));
        Suffocation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Suffocation/sci_die1.wav"));
        Suffocation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Suffocation/sci_die2.wav"));
        Suffocation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Suffocation/sci_die3.wav"));
        Suffocation.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Suffocation/sci_die4.wav"));
        
        #endregion
        
        #region Mauling
        
        Mauling.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Mauling/sci_pain1.wav"));
        Mauling.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Mauling/sci_pain5.wav"));
        Mauling.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Mauling/sci_pain6.wav"));
        Mauling.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Mauling/sci_pain7.wav"));
        Mauling.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Mauling/sci_pain8.wav"));
        
        #endregion
        
        #region Gunshots
        
        Gunshots.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Gunshots/scream09.wav"));
        Gunshots.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Gunshots/scream25.wav"));
        
        #endregion
        
        #region Crushing
        
        Crushing.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Crushing/sci_fear14.wav"));
        Crushing.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Crushing/sci_fear15.wav"));
        
        #endregion
        
        #region Drowning
        
        Drowning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Drowning/sci_die1.wav"));
        Drowning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Drowning/sci_die2.wav"));
        Drowning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Drowning/sci_die3.wav"));
        Drowning.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Drowning/sci_die4.wav"));
        
        #endregion
        
        #region Abandoned
        
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/c1a2_sci_darkroom.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/c1a3_sci_silo1a.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/c1a3_sci_silo2a.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/dontwantdie.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/evergetout.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/gottogetout.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/leavingme.wav"));
        Abandoned.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Abandoned/whyleavehere.wav"));
        
        #endregion
        
        #region Electrocution
        
        Electrocution.Add(_assetBundle.LoadPersistentAsset<AudioClip>("Assets/Electrocution/scream07.wav"));
        
        #endregion
    }
}