using UnityEngine;
using System.Collections;

public class HeroCost : MonoBehaviour {

    public Number[] money = new Number[4];
    public Hero hero;

    public void Update(){
        UpdateNumbers();
    }

    [ContextMenu("Test")]
    public void UpdateNumbers(){
        string current = hero.data.Cost.ToString("D4");
        for(int i = 0; i < money.Length;i++){
            money[(money.Length-1)-i].NumberValue = int.Parse(current[i].ToString());
        }
    }
}
