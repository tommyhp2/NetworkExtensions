using System;
using System.Linq;
using System.Xml;
using ColossalFramework;
using ICities;
using Transit.Framework;

namespace Transit.Addon.TM
{
    public partial class ToolModuleV2
    {
        static ToolModuleV2()
        {
            ActiveOptions = Options.None;
        }

        public static Options ActiveOptions { get; private set; }

        public override void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddCheckbox(
                "Realistic Speeds",
                null,
                ActiveOptions.IsFlagSet(Options.UseRealisticSpeeds),
                isChecked =>
                {
                    if (isChecked)
                    {
                        ActiveOptions |= Options.UseRealisticSpeeds;
                    }
                    else
                    {
                        ActiveOptions &= ~Options.UseRealisticSpeeds;
                    }

                    FireSaveSettingsNeeded();
                },
                true);

            OptionManager.makeSettings(helper);
        }

        public override void OnLoadSettings(XmlElement moduleElement)
        {
            foreach (var option in Enum.GetValues(typeof(Options))
                                       .OfType<Options>()
                                       .Where(o => o != 0))
            {
                bool? isEnabled = null;

                if (moduleElement != null)
                {
                    var nodeList = moduleElement.GetElementsByTagName(option.ToString().ToUpper());
                    if (nodeList.Count > 0)
                    {
                        var node = (XmlElement)nodeList[0];
                        var nodeValue = true;

                        if (bool.TryParse(node.InnerText, out nodeValue))
                        {
                            isEnabled = nodeValue;
                        }
                    }
                }

                if (isEnabled == null)
                {
                    // Default
                    if (option == Options.UseRealisticSpeeds)
                    {
                        isEnabled = false;
                    }
                    else
                    {
                        isEnabled = true;
                    }
                }

                if (isEnabled.Value)
                {
                    ActiveOptions = ActiveOptions | option;
                }
                else
                {
                    ActiveOptions = ActiveOptions & ~option;
                }
            }
        }

        public override void OnSaveSettings(XmlElement moduleElement)
        {
            base.OnSaveSettings(moduleElement);

            foreach (var option in Enum.GetValues(typeof(Options))
                                       .OfType<Options>()
                                       .Where(o => o != 0))
            {
                moduleElement.AppendElement(
                    option.ToString().ToUpper(),
                    ActiveOptions.HasFlag(option).ToString());
            }
        }
    }
}
