using UnityEngine;
using System.Collections;
using System;

public abstract class HeroData : ScriptableObject {
    
    public int initialCost;
    public string heroName;
    public int heroLevel;
    public static double costMult = 1.07;
    public GameObject heroViewPrefab;

    public void Init(){
        heroLevel = 0;
    }

    public abstract int Cost{
        get;
    }

    public abstract int GetDPS {
        get;
    }

    public abstract int GetDPC {
        get;
    }

    public string ID {
        get{
            return name + initialCost + "";
        }
    } 

    public Hero Create(Quaternion rot, Vector3 position){
        GameObject h = heroViewPrefab.Duplicate(position,rot);
        Hero heroComp = h.GetComponent<Hero>();
        heroComp.data = this;
        return heroComp;
    }
}
