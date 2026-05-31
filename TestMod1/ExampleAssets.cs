using UnityEngine;

namespace TestMod1;

using MiraAPI.Utilities.Assets;

public class ExampleAssets
{
    public static LoadableResourceAsset ExampleButton { get; } = new("TestMod1.Resources.dyna3.png");
    
    static AssetBundle myBundle = AssetBundle.LoadFromFile("tufbundle-win.bundle");

    public static LoadableBundleAsset<GameObject> MyPrefab = new("ezgif.com-gif-to-sprite-converter.prefab", myBundle);


}