#if UNITY_EDITOR
using System;
using System.Collections.Generic;

static class CloudSaveNetworkField
{
    static readonly string[] RefererNetworks = { "organic", "facebook", "instagram" };

    public static string ResolveNetwork(string referer, string namingJson)
    {
        var fromReferer = ParseNetworkFromReferer(referer);
        if (!string.IsNullOrEmpty(fromReferer))
            return fromReferer;

        return ParseNetworkFromNaming(namingJson);
    }

    public static void ApplyToRow(Dictionary<string, string> row)
    {
        if (row == null)
            return;

        row.TryGetValue("referer", out var referer);
        row.TryGetValue("naming", out var naming);
        row["network"] = ResolveNetwork(referer, naming);
    }

    static string ParseNetworkFromReferer(string referer)
    {
        if (string.IsNullOrWhiteSpace(referer))
            return string.Empty;

        for (var i = 0; i < RefererNetworks.Length; i++)
        {
            var network = RefererNetworks[i];
            if (referer.IndexOf(network, StringComparison.OrdinalIgnoreCase) >= 0)
                return network;
        }

        return string.Empty;
    }

    static string ParseNetworkFromNaming(string namingJson)
    {
        if (string.IsNullOrWhiteSpace(namingJson))
            return string.Empty;

        return CloudSaveResponseParser.ReadJsonStringField(namingJson, "network");
    }
}
#endif
