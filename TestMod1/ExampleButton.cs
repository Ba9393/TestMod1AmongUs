using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using Mono.Cecil;
using Rewired;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace TestMod1;

public class ExampleButton : CustomActionButton//<PlayerControl>
{
    public override string Name => "Bomb";
    public override float Cooldown => 0.0f;
    public override float InitialCooldown => 10.0f;
    public override LoadableAsset<Sprite> Sprite => ExampleAssets.ExampleButton;
    public override BaseKeybind Keybind => MiraGlobalKeybinds.PrimaryAbility;
    public override bool ZeroIsInfinite => true;
    
    public override bool Enabled(RoleBehaviour role)
    {
        return role is ExploderRole;
    }
    
    //public override PlayerControl? GetTarget()
    //{
    //    return PlayerControl.LocalPlayer.GetClosestPlayer(false, Distance);
    //}

    //public override void SetOutline(bool active)
    //{
    //    Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.Orange));
    //}
    
    protected override void OnClick()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // System.Console.WriteLine(mouseWorld);
        GameObject TestObj = UnityEngine.Object.Instantiate(ExampleAssets.MyPrefab.LoadAsset());
        TestObj.name = "TestObj";
        TestObj.transform.position = mouseWorld;
    }
}