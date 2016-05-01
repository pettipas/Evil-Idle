using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldData : ScriptableObject {
    public int worldIndex;
    public int monstersKilled;
    public int monsterIndex;
    public GameObject worldView;
    public List<MonsterData> worldMonsters = new List<MonsterData>();

    GameObject monsterInstance;
    GameObject worldViewInstance;

    public Monster CurrentMonster{
        get{
            return monsterInstance.GetComponentInChildren<Monster>();
        }
    }

    public void Hide(){
        worldViewInstance.SetActive(false);
        if(monsterInstance != null)
            monsterInstance.SetActive(false);
    }

    public void Show(Transform wp, Transform mp, int wi){
        worldIndex = wi;
        if(monsterInstance != null){
            monsterInstance.SetActive(true);
        }else {
            monsterInstance = worldMonsters[monsterIndex].Create(mp, wi);
        }

        if(worldViewInstance != null){
            worldViewInstance.SetActive(true);
        }else{
            monstersKilled = 0;
            worldViewInstance= worldView.Duplicate(wp.position, wp.rotation);
            worldViewInstance.GetComponentInChildren<World>().data = this;
        }
    }

    public bool WorldComplete{
        get{
            return monstersKilled >= 10;
        }
    }
 
    public GameObject CreateWorld(Transform wp, Transform mp, int wi) {
     
        worldIndex = wi;
        monsterInstance = worldMonsters[monsterIndex].Create(mp,worldIndex);

        monstersKilled = 0;
        worldViewInstance= worldView.Duplicate(wp.position, wp.rotation);
        worldViewInstance.GetComponentInChildren<World>().data = this;
        return worldViewInstance;
    }

    public void AttackCurrentMonster(float damage){
        CurrentMonster.hp-=damage;
    }

    public GameObject CreateNextMonster(Transform mp){
        monstersKilled++;
        if(monsterInstance) Destroy(monsterInstance);
        monsterIndex++;
        if(monsterIndex >= worldMonsters.Count){
            monsterIndex = 0;
        }
        monsterInstance = worldMonsters[monsterIndex].Create(mp, worldIndex);
        return monsterInstance;
    }
}
