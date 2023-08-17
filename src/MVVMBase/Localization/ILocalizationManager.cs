using System.Reflection;
using System.Resources;

namespace MVVMBase.Localization;

public interface ILocalizationManager
{
    string GetString(string key, params object[] parameters);
    void AddResourceManager(ResourceManager resourceManager);
}