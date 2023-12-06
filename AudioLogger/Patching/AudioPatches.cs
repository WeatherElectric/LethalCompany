using System;
using HarmonyLib;
using UnityEngine;

namespace AudioLogger.Patching;

public static class AudioPatches
{
    [HarmonyPatch(typeof(AudioSource))]
    internal static class PlayClipAtPointPatch
    {
        [HarmonyPatch("PlayClipAtPoint", typeof(AudioClip), typeof(Vector3), typeof(float))]
        [HarmonyPostfix]
        public static void Postfix(AudioClip clip, ref Vector3 position, float volume)
        {
            var clipName = clip.name;
            var positionString = position.ToString();
            Plugin.StaticLogger.LogInfo($"Playing {clipName} at position {positionString}");
        }
    }
    
    [HarmonyPatch(typeof(AudioSource))]
    internal static class PlayOneShotPatch
    {
        [HarmonyPatch("PlayOneShotHelper", typeof(AudioSource), typeof(AudioClip), typeof(float))]
        [HarmonyPostfix]
        public static void Postfix(AudioSource source, ref AudioClip clip, float volumeScale)
        {
            var clipName = clip.name;
            var objectName = source.gameObject.name;
            Plugin.StaticLogger.LogInfo($"Playing one-shot {clipName} from {objectName}");
        }
    }

    [HarmonyPatch(typeof(AudioSource))]
    internal static class PlayPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(AudioSource.Play), new Type[0])]
        public static void Postfix(AudioSource __instance)
        {
            var clipName = __instance.clip.name;
            var objectName = __instance.gameObject.name;
            Plugin.StaticLogger.LogInfo($"Playing {clipName} from {objectName}");
        }
    }
    
    [HarmonyPatch(typeof(AudioSource))]
    internal static class PlayDoublePatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(AudioSource.Play), typeof(ulong))]
        public static void Postfix(AudioSource __instance)
        {
            var clipName = __instance.clip.name;
            var objectName = __instance.gameObject.name;
            Plugin.StaticLogger.LogInfo($"Playing {clipName} from {objectName}");
        }
    }
}