using System.Globalization;
using System.Resources;

namespace MVVMBase.Localization;

public class LocalizationManager : ILocalizationManager
{
    private readonly string emptyValue = "---";
    /// <summary>
    /// Cached resourceManagers for each ResourceSet supported requested.       
    /// </summary>
    private readonly List<ResourceManager> resourceManagers = new List<ResourceManager>();
    public string GetString(string key, params object[] parameters)
    {
        if(string.IsNullOrWhiteSpace(key))
        {
            return emptyValue;
        }
        foreach (var resourceManager in resourceManagers)
        {
            var str = GetRawString(resourceManager, key, CultureInfo.CurrentUICulture);
            str = GetFormattedString(str, parameters);
            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }
        }
        return $"?{key}?";
    }

    private string GetRawString(ResourceManager manager, string key, CultureInfo cultureInfo)
    {
        try
        {
            string unFormattedString = manager.GetString(key, cultureInfo) ?? String.Empty;
            return unFormattedString;
        }
        catch (MissingManifestResourceException)
        {
        }
        catch (NullReferenceException)
        {
        }
        return String.Empty;
    }

    private string GetFormattedString(string rawString, params object[] parameters)
    {
        try
        {
            string str = string.Format(rawString, parameters);
            return str;
        }
        catch (FormatException)
        {
            return rawString;
        }
    }
    public void AddResourceManager(ResourceManager resourceManager)
    {
        resourceManagers.Add(resourceManager);
    }
}