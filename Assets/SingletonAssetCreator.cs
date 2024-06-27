#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using FStudio.MatchEngine.FieldPositions;

[InitializeOnLoad]
public static class SingletonAssetCreator
{
    static SingletonAssetCreator()
    {
        CreateSingletonAsset<KickOffStage2_Starter>("KickOffStage2_Starter");
        CreateSingletonAsset<KickOffStage2>("KickOffStage2");

        CreateSingletonAsset<KickOffStage1_Starter>("KickOffStage1_Starter");
        CreateSingletonAsset<KickOffStage1>("KickOffStage1");        
    }

    private static void CreateSingletonAsset<T>(string assetName) where T : ScriptableObject
    {
        string assetPath = $"Assets/FootballSimulator/Resources/Singletons/{assetName}.asset";
        T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        if (asset == null)
        {
            asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"{assetName} asset created at {assetPath}");
        }
    }
}
#endif
