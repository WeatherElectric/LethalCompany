using System.Text.RegularExpressions;

namespace WrongLibWithTheWrongTechnique.Modules;

public static class HelperMethods
{
    public static string GetCleanObjectName(string name)
    {
        Regex regex = new Regex(@"\[\d+\]|\(\d+\)"); // Stuff like (1) or [24]
        name = regex.Replace(name, "");
        name = name.Replace("(Clone)", "");
        return name.Trim();
    }
}