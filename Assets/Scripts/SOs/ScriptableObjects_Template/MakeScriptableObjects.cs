using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObjects
{
    [MenuItem("Assets/Create/Custom Scriptable Objects/EnemySO")]
    public static void CreateEnemyAsset()
    {
        EnemySO asset = ScriptableObject.CreateInstance<EnemySO>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/SOs/Enemies/NewEnemySO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Custom Scriptable Objects/PlayerSO")]
    public static void CreatePlayerAsset()
    {
        PlayerSO asset = ScriptableObject.CreateInstance<PlayerSO>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/SOs/Classes/NewPlayerSO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Custom Scriptable Objects/PotionSO")]
    public static void CreatePotionAsset()
    {
        PotionSO asset = ScriptableObject.CreateInstance<PotionSO>();
        
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/SOs/Potions/NewPotionSO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Custom Scriptable Objects/GeneratorSO")]
    public static void CreateMyAsset()
    {
        GeneratorSO asset = ScriptableObject.CreateInstance<GeneratorSO>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/SOs/Generators/NewGeneratorSO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}