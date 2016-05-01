using UnityEngine;
using System.Collections;

public class FiveDidgetNumber : MonoBehaviour {

    public Number[] didgets = new Number[5];
    public int current = 0;
    public void Update(){
        UpdateNumbers();
    }

    bool killleadingzeros = false;
    [ContextMenu("Test")]
    public void UpdateNumbers(){
        killleadingzeros = true;
        string currentString = current.ToString("D5");
        for(int i = 0; i < didgets.Length;i++){
            didgets[i].NumberValue = int.Parse(currentString[i].ToString());
        }
    }
}
