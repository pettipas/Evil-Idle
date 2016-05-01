using UnityEngine;
using System.Collections;
using UnityEditor;

public class EvilDomainEditor : Editor {

    [MenuItem("Evil/EconomyData")]
    static void NewEconomyData(){
        EconomyData data = ScriptableObject.CreateInstance<EconomyData>();
        AssetDatabase.CreateAsset(data,"Assets/_EconomyData.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Evil/WorldData")]
    static void NewWorldData(){
        WorldData data = ScriptableObject.CreateInstance<WorldData>();
        AssetDatabase.CreateAsset(data,"Assets/_WorldData.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Evil/MonsterData")]
    static void NewMonsterData(){
        MonsterData data = ScriptableObject.CreateInstance<MonsterData>();
        AssetDatabase.CreateAsset(data,"Assets/_MonsterData.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Evil/NewGame")]
    static void NewGame(){
        Game data = ScriptableObject.CreateInstance<Game>();
        AssetDatabase.CreateAsset(data,"Assets/_Game.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Evil/ClickHero")]
    static void NewClickHeroData(){
        ClickHeroData data = ScriptableObject.CreateInstance<ClickHeroData>();
        AssetDatabase.CreateAsset(data,"Assets/_ClickHero.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Evil/DPSHero")]
    static void NewDPSHeroData(){
        DPSHeroData data = ScriptableObject.CreateInstance<DPSHeroData>();
        AssetDatabase.CreateAsset(data,"Assets/_DPSHero.asset");
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }
}
