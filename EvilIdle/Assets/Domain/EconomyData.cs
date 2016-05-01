using UnityEngine;
using System.Collections;

public class EconomyData : ScriptableObject {

    [Range(0,1000)]
    public int bucks;
    public GameObject econView;

    public GameObject Create(Vector3 p, Quaternion rot){
        return econView.Duplicate(p, rot);
    }
}
