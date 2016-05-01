using UnityEngine;
using System.Collections;

public class DPSDPC : MonoBehaviour {

    public Game game;
    public FiveDidgetNumber dps;
    public FiveDidgetNumber dpc;

    public void Update(){
        dps.current = (int)game.CurrentDPS;
        dpc.current = (int)game.CurrentClickDamage;
    }
}
