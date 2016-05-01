using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Number : MonoBehaviour {

	[SerializeField]protected int number;
	public Renderer[] numbers = new Renderer[10];
    bool ready;
	public void Awake(){
        Init();
        ShowNumber();
	}

    [ContextMenu("ShowNumber")]
    public void ShowNumber(){
        NumberValue = number;
    }

    [ContextMenu("Init")]
    public void Init(){
        for(int i = 0; i < 10;i++){
            foreach(Transform t in transform){
                if(int.Parse(t.name) == i){
                    numbers[i] = t.GetComponent<Renderer>();
                }
            }
        }
        numbers.ToList().ForEach(x=>{
            x.enabled =false;
        });
        ready = true;
    }

    public bool Ready{
        get{
            return ready;
        }set{
            ready = value;
        }
    }

	public int NumberValue{
		get{
			return number;
		}set{
			numbers.ToList().ForEach(x=>{
				x.enabled =false;
			});
			number = value;
			if(number >= numbers.Length
			   || number < 0){
				number = 0;
			}
			numbers[number].enabled = true;
		}
	}
}
