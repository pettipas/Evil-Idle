using UnityEngine;
using System.Collections;

public class MonsterData : ScriptableObject {
    
    public GameObject monsterPrefab;
    public float basevalue;

    public float basehp(int worldIndex){
        return 10 * Mathf.Pow(1.6f,worldIndex) + (worldIndex * 10);
    }

    //maybe we need to modify this based on world we are in to determine hp. i expect so
    public GameObject Create(Transform p,int wi){
        GameObject m = monsterPrefab.Duplicate(p.position, p.rotation);
        Monster mi =  m.GetComponentInChildren<Monster>();
        mi.hp = basehp(wi);
        mi.maxhp = basehp(wi);//multiply by world
        return m;
    }
}
