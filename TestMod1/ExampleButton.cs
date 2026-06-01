using System.Threading;
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

        GameObject FallingBomb = UnityEngine.Object.Instantiate(ExampleAssets.MyPrefab.LoadAsset());
        FallingBomb.name = "FallingBomb";
        FallingBomb.transform.position = new Vector2(mouseWorld.x, mouseWorld.y + 10.0f);
        
        for (var i = 0f; i < 100f; i++) 
        {
            FallingBomb.transform.position -= new Vector3(0.0f, 0.1f);
            // Thread.Sleep(100); doesnt work
        }

        //GameObject ExplosionAnim = UnityEngine.Object.Instantiate(ExampleAssets.MyPrefab.LoadAsset());
        //ExplosionAnim.name = "ExplosionAnim";
        //ExplosionAnim.transform.position = mouseWorld;
    }
}