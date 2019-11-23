using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ASPNetCoreVue.Localization
{
    public static class ASPNetCoreVueLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ASPNetCoreVueConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ASPNetCoreVueLocalizationConfigurer).GetAssembly(),
                        "ASPNetCoreVue.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
