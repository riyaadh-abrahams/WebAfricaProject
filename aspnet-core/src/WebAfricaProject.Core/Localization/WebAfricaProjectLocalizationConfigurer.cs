using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace WebAfricaProject.Localization
{
    public static class WebAfricaProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(WebAfricaProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(WebAfricaProjectLocalizationConfigurer).GetAssembly(),
                        "WebAfricaProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
