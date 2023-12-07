using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GameNetcodeStuff;
using UnityEngine;

namespace StockholmLib.Modules;

/// <summary>
/// Helper methods of various kinds.
/// </summary>
public static class HelperMethods
{
    /// <summary>
    /// Gets the name of the object without the (Clone) or [24] at the end.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>String of clean name</returns>
    public static string GetCleanObjectName(string name)
    {
        var regex = new Regex(@"\[\d+\]|\(\d+\)");
        name = regex.Replace(name, "");
        name = name.Replace("(Clone)", "");
        return name.Trim();
    }
}