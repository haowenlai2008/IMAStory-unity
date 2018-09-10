using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Object = UnityEngine.Object;
public class CreateAssetBundles {
    static string AssetbundlePath = "Assets" + Path.DirectorySeparatorChar + "assetbundles" + Path.DirectorySeparatorChar;
    [MenuItem("Character Generator/Create Assetbundles")]
    static void Execute()
    {
        bool createdBundle = false;
        foreach (Object o in Selection.GetFiltered(typeof (Object), SelectionMode.DeepAssets))
        {
            if (!(o is GameObject)) continue;
            if (o.name.Contains("@")) continue;
            if (!AssetDatabase.GetAssetPath(o).Contains("/characters/"))
                continue;
            createdBundle = true;
        }
        if (!createdBundle)
        {
            EditorUtility.DisplayDialog("Character Generator", "未生成Assetbundle.请选择Project视图中的characters文件夹来生成所有角色或者选择单个子目录生成选定角色", "OK");
            return;
        }
    }
}
