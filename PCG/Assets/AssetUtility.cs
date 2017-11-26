using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetUtility
{
    public static void CreateAsset<T>() where T: ScriptableObject
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
        {
            path = "Assets";
        }
        else if ( Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }
        CreateAsset<T>(path);
    }

    public static void CreateAsset<T>(string path) where T :ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string assetPath = AssetDatabase.GenerateUniqueAssetPath(path + "/New" + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPath);

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}

