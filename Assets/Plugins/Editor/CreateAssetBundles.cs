using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Object = UnityEngine.Object;
public class CreateAssetBundles {
    static string AssetbundlePath = "Assets" + Path.DirectorySeparatorChar + "assetbundles" + Path.DirectorySeparatorChar;
    [MenuItem("Assets/Build AssetBundle")]
    static void BuildAssetsBundles()
    {
        if (Directory.Exists(AssetbundlePath) == false)
        {
            Directory.CreateDirectory(AssetbundlePath);
        }
        BuildPipeline.BuildAssetBundles(AssetbundlePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
