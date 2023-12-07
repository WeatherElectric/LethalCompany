using System.IO;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace StockholmLib.Modules;

/// <summary>
/// Utilities for JSON.
/// </summary>
public static class JsonUtilities
{
    /// <summary>
    /// Gets the JSON from a url.
    /// </summary>
    /// <param name="url"></param>
    /// <returns>JSON content</returns>
    public static string GetJsonFromURL(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest();
        while (!request.isDone)
        {
            Plugin.StaticLogger.LogInfo("Waiting for request to finish...");
        }
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Plugin.StaticLogger.LogError($"Error: {request.error}");
            return null;
        }
        var json = request.downloadHandler.text;
        request.Dispose();
        return json;
    }
    
    /// <summary>
    /// Reads JSON from a file or string of content.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="isFile"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Deserialized object of the json</returns>
    public static T ReadJson<T>(string json, bool isFile = false)
    {
        if (isFile)
        {
            json = File.ReadAllText(json);
        }
        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// Reads JSON from a url.
    /// </summary>
    /// <param name="url"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Deserialized object of the json</returns>
    public static T ReadJsonFromURL<T>(string url)
    {
        var json = GetJsonFromURL(url);
        return JsonConvert.DeserializeObject<T>(json);
    }
}