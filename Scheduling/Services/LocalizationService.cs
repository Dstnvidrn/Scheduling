using System.Globalization;
using System.Resources;

public static class LocalizationService
{
    private static ResourceManager _resourceManager = new ResourceManager("Scheduling.Resources.Localization.Messages", typeof(LocalizationService).Assembly);

    public static string GetMessage(string key, string cultureCode)
    {
        var culture = new CultureInfo(cultureCode);
        return _resourceManager.GetString(key, culture) ?? $"[{key}]";
    }
    public static string GetDualMessage(string key)
    {
        string englishMessage = GetMessage(key, "en");
        string otherLanguageMessage = GetMessage(key, "es"); // Change "fr" to the desired language code
        return $"{englishMessage} / {otherLanguageMessage}";
    }
}
