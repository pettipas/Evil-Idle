using UnityEngine;
using System.Collections;

public class GameInterpreter : MonoBehaviour {

    public Game data;
    
    public void Awake(){
        data.Init();
        data.NewGame();
        data.CreateExistingHeros();
        data.CreateWorld();
        data.CreateEconomy();
       
    }
}
