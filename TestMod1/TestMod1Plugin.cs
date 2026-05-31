using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace TestMod1;

[BepInAutoPlugin("ba.test1", "Bomber Mod")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)] // The Mira API dependency attribute
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class ExamplePlugin : BasePlugin, IMiraPlugin
{
    public Harmony Harmony { get; } = new(Id);

    public string OptionsTitleText => "Bomber Mod";

    public ConfigFile GetConfigFile() => Config;
    
    //[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    //public static class PlayerControlPatch
    //{
    //    public static void Postfix(PlayerControl __instance)
    //    {
    //        System.Console.WriteLine(PlayerControl.LocalPlayer.GetTruePosition());
    //    }
    //}

    public override void Load()
    {
        Harmony.PatchAll();
    }
}