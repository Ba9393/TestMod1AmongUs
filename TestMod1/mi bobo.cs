using System.Collections;
using System.Threading.Tasks;
using BepInEx;
using Epic.OnlineServices;
using MiraAPI;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using Reactor.Networking.Attributes;
using Reactor.Networking.Rpc;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using UnityEngine;

namespace TestMod1;

public static class mi_bobo
{
    public static IEnumerator KimJongUn(Vector2 mouseWorld, PlayerControl origin)
    {
        System.Console.WriteLine("mouseWorld: " + mouseWorld + ", origin: " + origin + " so tuff innit bruv");
        bool isTheBomber = origin == PlayerControl.LocalPlayer;
        
        GameObject FallingBomb = UnityEngine.Object.Instantiate(ExampleAssets.MySecondPrefab.LoadAsset());
        FallingBomb.name = "FallingBomb";
        FallingBomb.transform.position = new Vector2(mouseWorld.x, mouseWorld.y + 10.0f);
        FallingBomb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        
        for (var i = 0; i < 50; i++) 
        {
            FallingBomb.transform.position -= new Vector3(0.0f, 0.2f);
            FallingBomb.transform.rotation = Quaternion.Euler(FallingBomb.transform.rotation.x, FallingBomb.transform.rotation.y, FallingBomb.transform.rotation.z + i * 4);
            yield return new WaitForSeconds(0.01f);
        }
        
        FallingBomb.Destroy();
        
        GameObject ExplosionAnim = UnityEngine.Object.Instantiate(ExampleAssets.MyThirdPrefab.LoadAsset());
        ExplosionAnim.name = "ExplosionAnim";
        ExplosionAnim.transform.position = mouseWorld;
        ExplosionAnim.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);

        if (isTheBomber)
        {
            // kil 😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱😱

            int dist = 1;

            var targets = Helpers.GetClosestPlayers(mouseWorld, dist);

            foreach (var player in targets)
            {
                if (player != PlayerControl.LocalPlayer)
                {
                    PlayerControl.LocalPlayer.RpcCustomMurder(player, !player.ProtectedByGa(),
                        true, false, false, false, true);
                }
            }
        }
        
        yield return new WaitForSeconds(1.083f); // wait for anim to end
        ExplosionAnim.Destroy();
    }
    
    public enum CustomRpcCalls : uint
    {
        AbsoluteBalls
    }
    
    [MethodRpc((uint) CustomRpcCalls.AbsoluteBalls)]
    public static void RpcRenderBomb(this PlayerControl player, Vector2 mouseWorld, PlayerControl origin)
    {
        System.Console.WriteLine("mouseWorld: " + mouseWorld + ", origin: " + origin);
        Coroutines.Start(KimJongUn(mouseWorld, origin));
    }
}