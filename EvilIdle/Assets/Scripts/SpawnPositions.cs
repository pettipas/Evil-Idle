using UnityEngine;
using System.Collections;

public class SpawnPositions : MonoBehaviour {

    public Transform monsterPosition;
    public Transform herosStartPosition;
    public Transform worldStartPosition;
    public Transform economyPostion;

    public void OnDrawGizmos(){
        
        Gizmos.color = Color.red;
        if(monsterPosition != null){
            Gizmos.DrawCube(monsterPosition.position,Vector3.one*5);
        }

        Gizmos.color = Color.green;
        if(herosStartPosition != null){
            Gizmos.DrawCube(herosStartPosition.position,Vector3.one*5);
        }

        Gizmos.color = Color.yellow;
        if(worldStartPosition != null){
            Gizmos.DrawCube(worldStartPosition.position,Vector3.one*5);
        }

        Gizmos.color = Color.green;
        if(economyPostion != null){
            Gizmos.DrawCube(economyPostion.position,Vector3.one*5);
        }
    }
}
