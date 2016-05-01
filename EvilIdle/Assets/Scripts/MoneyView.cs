using UnityEngine;
using System.Collections;
public class MoneyView : MonoBehaviour {
    
    public Number[] money = new Number[8];
    public EconomyData data;

    public void Update(){
        UpdateNumbers();
    }

    [ContextMenu("Test")]
    public void UpdateNumbers(){
        string current = data.bucks.ToString("D8");
        for(int i = 0; i < money.Length;i++){
            money[(money.Length-1)-i].NumberValue = int.Parse(current[i].ToString());
        }
    }
}
