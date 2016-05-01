using UnityEngine;
using System.Collections;

public class HeroLevel : MonoBehaviour {

    public Number[] didgets = new Number[3];
    public Hero hero;

    public void Update(){
        UpdateNumbers();
    }

    [ContextMenu("Test")]
    public void UpdateNumbers(){
        string current = hero.data.heroLevel.ToString("D3");
        for(int i = 0; i < didgets.Length;i++){
            didgets[(didgets.Length-1)-i].NumberValue = int.Parse(current[i].ToString());
        }
    }
}
