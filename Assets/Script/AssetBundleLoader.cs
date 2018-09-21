using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour {

	public static GameObject LoadAssetBundle(string Path, string Name)
    {
        AssetBundle ab = AssetBundle.LoadFromFile(Path);
        GameObject Prefab = ab.LoadAsset<GameObject>(Name);
        return Prefab;
    }
}
