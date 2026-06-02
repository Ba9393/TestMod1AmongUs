using Il2CppSystem.Reflection;
using Reactor.Utilities;
using UnityEngine;

namespace TestMod1;

using MiraAPI.Utilities.Assets;

public class ExampleAssets
{
    public static LoadableResourceAsset ExampleButton { get; } = new("TestMod1.Resources.dyna3.png");
    
//    static AssetBundle myBundle = AssetBundle.LoadFromFile(
//        System.IO.Path.Combine(
//            System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
//            "Resources", "tufbundle-win.bundle")
//        "tufbundle");

    static AssetBundle myBundle = AssetBundleManager.Load("tufbundle");

    public static LoadableBundleAsset<Sprite> MySprite = new("ezgif.com-gif-to-sprite-converter_0.png", myBundle);
    public static LoadableBundleAsset<GameObject> MyPrefab = new("ezgif.com-gif-to-sprite-converter_0.prefab", myBundle);
    
    static AssetBundle mySecondBundle = AssetBundleManager.Load("dyna3bun");

    public static LoadableBundleAsset<GameObject> MySecondPrefab = new("dyna3.prefab", mySecondBundle);
    
    static AssetBundle myThirdBundle = AssetBundleManager.Load("workpls");

    public static LoadableBundleAsset<GameObject> MyThirdPrefab = new("spritesheet_0.prefab", myThirdBundle);
}