using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader
{
    //参数1是AssetBundle的路径，参数2是资源的名称
	public static GameObject LoadAssetBundle(string Path, string Name)
    {
        //1.卸载数据，如果有某个系统来管理加载好的数据就不要加下面这句了
        AssetBundle.UnloadAllAssetBundles(true);

        //2.加载数据
        AssetBundle ab = AssetBundle.LoadFromFile(Path);

        return ab.LoadAsset<GameObject>(Name);
    }
}
