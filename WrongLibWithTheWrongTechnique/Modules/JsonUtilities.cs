using System.IO;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace WrongLibWithTheWrongTechnique.Modules.Json;

public static class JsonUtilities
{
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
    
    public static T ReadJson<T>(string json, bool isFile = false)
    {
        if (isFile)
        {
            json = File.ReadAllText(json);
        }
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static T ReadJsonFromURL<T>(string url)
    {
        var json = GetJsonFromURL(url);
        return JsonConvert.DeserializeObject<T>(json);
    }
}