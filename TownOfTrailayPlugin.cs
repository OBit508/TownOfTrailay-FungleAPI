using BepInEx;
using BepInEx.Unity.IL2CPP;
using FungleAPI;
using FungleAPI.PluginLoading;
using HarmonyLib;

namespace TownOfTrailay
{
    [BepInProcess("Among Us.exe")]
    [BepInPlugin(ModId, PluginName, PluginVersion)]
    [BepInDependency(FungleAPIPlugin.ModId)]
    public class TownOfTrailayPlugin : BasePlugin, IFungleBasePlugin
    {
        public const string PluginName = "TownOfTrailay_FungleAPI";
        public const string PluginVersion = "0.0.1";
        public const string Owner = "tot_team";
        public const string ModId = "com." + Owner + "." + PluginName;

        public static Harmony Harmony = new Harmony(ModId);

        public string ModName => "TownOfTrailay";
        public string ModVersion => PluginVersion;

        public static ModPlugin Plugin => FunglePlugin<TownOfTrailayPlugin>.Plugin;
        public override void Load()
        {

        }
    }
}
