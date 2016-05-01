using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour {
    [Range(0,1)]
    public float amount;
    public Transform bar_geometry;

    public void Update(){
        bar_geometry.localScale = new Vector3 (amount==0?0.01f:amount,1,1);
    }
}
