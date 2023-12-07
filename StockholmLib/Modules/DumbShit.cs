using System;
using System.Linq;
using Newtonsoft.Json;

namespace StockholmLib.Modules;

/// <summary>
/// Random nonsense.
/// </summary>
public static class DumbShit
{
    /// <summary>
    /// Gets a random IP address.
    /// </summary>
    /// <returns>String of IP</returns>
    public static string GetRandomIP()
    {
        var random = new Random();
        var ip = $"{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        return ip;
    }
    
    /// <summary>
    /// Gets a random MAC address.
    /// </summary>
    /// <returns>String of MAC</returns>
    public static string GetRandomMacAddress()
    {
        var random = new Random();
        byte[] macAddressBytes = new byte[6];
        macAddressBytes[0] = 0x01;
        macAddressBytes[0] |= 0x00;
        macAddressBytes[0] |= 0x5E;
        for (int i = 1; i < 6; i++)
        {
            macAddressBytes[i] = (byte)random.Next(256);
        }
        var macAddress = string.Join(":", (from z in macAddressBytes select z.ToString("X2")).ToArray());
        return macAddress;
    }
    
    private const string AddressAPI = "https://random-data-api.com/api/v2/addresses";
    // These are fake addresses.
    /// <summary>
    /// Gets a random address from a random data API.
    /// </summary>
    /// <returns>String of address</returns>
    public static string GetRandomAddress()
    {
        var json = JsonUtilities.GetJsonFromURL(AddressAPI);
        AddressData addressData = JsonConvert.DeserializeObject<AddressData>(json);
        return addressData.full_address;
    }
}

#region JSON Data

internal class AddressData
{
    public int id { get; set; }
    public string uid { get; set; }
    public string city { get; set; }
    public string street_name { get; set; }
    public string street_address { get; set; }
    public string secondary_address { get; set; }
    public string building_number { get; set; }
    public string mail_box { get; set; }
    public string community { get; set; }
    public string zip_code { get; set; }
    public string zip { get; set; }
    public string postcode { get; set; }
    public string time_zone { get; set; }
    public string street_suffix { get; set; }
    public string city_suffix { get; set; }
    public string city_prefix { get; set; }
    public string state { get; set; }
    public string state_abbr { get; set; }
    public string country { get; set; }
    public string country_code { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string full_address { get; set; }
}

#endregion