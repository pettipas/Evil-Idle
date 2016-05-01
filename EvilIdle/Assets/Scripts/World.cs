using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    public Material mat;
    public Color color;
    public WorldData data;
    public FiveDidgetNumber num;

    public FiveDidgetNumber killed;
    public FiveDidgetNumber total;

    public void Awake(){
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        total.current = 10;
    }

    public void Update(){

        if(data.monstersKilled > 9){
            total.gameObject.SetActive(false);
            killed.gameObject.SetActive(false);
        }

        killed.current = data.monstersKilled; 
        num.current = data.worldIndex;
        mat.color = color;
    }
}
