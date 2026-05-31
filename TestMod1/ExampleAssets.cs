using Il2CppSystem.Reflection;
using UnityEngine;

namespace TestMod1;

using MiraAPI.Utilities.Assets;

public class ExampleAssets
{
    public static LoadableResourceAsset ExampleButton { get; } = new("TestMod1.Resources.dyna3.png");
    
    static AssetBundle myBundle = AssetBundle.LoadFromFile(
        System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Resources", "tufbundle-win.bundle"));

    public static LoadableBundleAsset<Sprite> MySprite = new("ezgif.com-gif-to-sprite-converter_0.png", myBundle);
    public static LoadableBundleAsset<GameObject> MyPrefab = new("ezgif.com-gif-to-sprite-converter_0.prefab", myBundle);
}