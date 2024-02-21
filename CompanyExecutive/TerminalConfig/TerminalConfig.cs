using TerminalApi.Events;
using UnityEngine;

namespace CompanyExecutive;

public static class TerminalConfig
{
    public static void Init()
    {
        TerminalApi.TerminalApi.AddCommand("executive toggle", "Toggled pref.\n");
        TerminalApi.TerminalApi.AddCommand("executive consistent", "Toggled pref.\n");
        TerminalApi.TerminalApi.AddCommand("executive override", "Toggled pref.\n");
        TerminalApi.TerminalApi.AddCommand("executive give", "Added money to account.\n");
        Events.TerminalParsedSentence += OnCommandSent;
    }

    private static void OnCommandSent(object sender, Events.TerminalParseSentenceEventArgs e)
    {
        var terminal = Object.FindObjectOfType<Terminal>();
        if (e.SubmittedText.Contains("executive toggle"))
        {
            Plugin.Enabled.Value = !Plugin.Enabled.Value;
        }
        if (e.SubmittedText.Contains("executive consistent"))
        {
            Plugin.ConsistentGive.Value = !Plugin.ConsistentGive.Value;
        }
        if (e.SubmittedText.Contains("executive override"))
        {
            Plugin.OverrideMoney.Value = !Plugin.OverrideMoney.Value;
        }
        if (e.SubmittedText.Contains("executive give"))
        {
            if (!GameNetworkManager.Instance.isHostingGame) return;
            if (Plugin.OverrideMoney.Value)
                terminal.groupCredits = Plugin.MoneyToGive.Value;
            else
                terminal.groupCredits += Plugin.MoneyToGive.Value;
        }
    }
}