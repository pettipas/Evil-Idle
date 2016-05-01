using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Game : ScriptableObject {

    public EconomyData econ;
    public static float HERO_HEIGHT_GAP = 16.0f;
    public int heroIndex;
    public int worldIndex;

    public SpawnPositions visualStructurePrefab;
    SpawnPositions structureInstance;

    public GameObject currentWorldInstance;
    public List<Hero> currentHeroInstances = new List<Hero>();
    public List<Monster> currentMonsterInstance = new List<Monster>();

    public List<HeroData> heroData = new List<HeroData>();
    public List<WorldData> worldData = new List<WorldData>();

    public void AdvanceWorld(){
        if(worldData[worldIndex].WorldComplete == false){
            return;
        }
        worldData[worldIndex].Hide();
        worldIndex++;
        if(worldIndex >= worldData.Count){
            worldIndex =  worldData.Count-1; 
        }
        worldData[worldIndex].Show(structureInstance.worldStartPosition, structureInstance.monsterPosition,worldIndex);
    }

    public void GoBackOneWorld(){
        worldData[worldIndex].Hide();
        worldIndex--;
        if(worldIndex < 0){
            worldIndex =  0; 
        }worldData[worldIndex].Show(structureInstance.worldStartPosition, structureInstance.monsterPosition,worldIndex);
    }

    public void ShowHeros(){
        for(int i = 0; i < currentHeroInstances.Count;i++){
            Hero prev = null;
            Hero cur = currentHeroInstances[i];
            if(i > 0){
                prev = currentHeroInstances[i-1];
            }
            if((prev == null && econ.bucks < cur.data.Cost)
                ||  (prev != null && econ.bucks > prev.data.Cost  && econ.bucks < cur.data.Cost)
                ||  (cur.seenByUser && econ.bucks < cur.data.Cost)
            ){
                cur.ShowUnclickable();
                cur.seenByUser = true;
            }else if (econ.bucks >= cur.data.Cost){
                cur.ShowClickable();
            }else if(cur.data.heroLevel == 0 && !cur.seenByUser) {
                cur.Hide();
            }
        }
    }

    public void NewGame(){
        currentMonsterInstance.Clear();
        currentHeroInstances.Clear();
        econ.bucks = 0;
        heroData.ForEach(x=>{
            x.Init();
        });
    }

    public void Init(){
        heroIndex = 0;
        worldIndex = 0;
        structureInstance = visualStructurePrefab.Duplicate(visualStructurePrefab.transform.position);
    }

    public void TryDestroyMonster(){
        if(worldData[worldIndex].CurrentMonster.Dead){
            float value = worldData[worldIndex].CurrentMonster.maxhp/15.0f;
            econ.bucks+=Mathf.CeilToInt(value);
            worldData[worldIndex].CreateNextMonster(structureInstance.monsterPosition);
        }
    }

    public void AttackCurrentMonster(){
        worldData[worldIndex].AttackCurrentMonster(CurrentDPS);
    }

    public float CurrentClickDamage{
        get{
            return heroData[0].GetDPC;
        }
    }

    public float CurrentDPS{
        get{
            int totalDPS = 0;
            for(int i = 1; i < heroData.Count; i++){
                totalDPS+=heroData[i].GetDPS;
            }
            return totalDPS;
        }
    }

    public void CreateEconomy(){
        econ.Create(structureInstance.economyPostion.position, structureInstance.economyPostion.rotation);
    }

    public void CreateExistingHeros(){
        for(int i = 0; i < heroData.Count;i++ ){
            Hero h = heroData[i].Create(structureInstance.herosStartPosition.rotation,HeroPosition(i, structureInstance.herosStartPosition.position));
            currentHeroInstances.Add(h);
        }
    }

    public Vector3 HeroPosition(int index, Vector3 refPosition){
        return new Vector3(refPosition.x,refPosition.y - (HERO_HEIGHT_GAP * index) ,refPosition.z);
    }

    public void CreateWorld(){
        worldData[worldIndex].CreateWorld(structureInstance.worldStartPosition,structureInstance.monsterPosition,worldIndex);
    }
}
