using UnityEngine;
using System.Collections;

public class ClickInputProcessor : MonoBehaviour {

    public float attackCooolDown = 1.0f;
    public float timer;

    public EconomyData econ;
    public Game game;

    public void Update(){

        game.ShowHeros();

        timer+=Time.deltaTime;

        if(timer > attackCooolDown && game.CurrentDPS > 0){
            timer=0;
            game.AttackCurrentMonster();
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit) && Input.GetMouseButtonUp(0)) {
            
            Button b = hit.transform.GetComponent<Button>();

            if(b != null){
                ProcessClick(b);
            }
        }
    }
    bool moving;
    public IEnumerator AdvanceWorld(){
        game.AdvanceWorld();
        moving = false;
        yield break;
    }

    public IEnumerator GoBackOneWorld(){
        game.GoBackOneWorld();
        moving = false;
        yield break;
    }

    public void ProcessClick( Button b ){

        if(b.inputEvent == InputEvent.AttackCurrent) {
            Monster monster = b.GetComponent<Monster>();
            monster.hp-=game.CurrentClickDamage;
            monster.ShowClick();
        }else if(b.inputEvent == InputEvent.NextUpgrade){
            
        }else if(b.inputEvent == InputEvent.LevelUp){
            Hero hero = b.GetComponentInParent<Hero>();
            if(econ.bucks >= hero.data.Cost){
                econ.bucks-= hero.data.Cost;
                hero.data.heroLevel++;
                hero.ShowClick();
            }
     
        }else if(b.inputEvent == InputEvent.PressedLeft){
            if(!moving){
                moving = true;
            }
            StartCoroutine(GoBackOneWorld());
            
        }else if(b.inputEvent == InputEvent.PressedRight){
            if(!moving){
                moving = true;
            }
            StartCoroutine(AdvanceWorld());
        }
    }

    public void LateUpdate(){
        game.TryDestroyMonster();
    }
}


public enum InputEvent{
    LevelUp,
    NextUpgrade,
    AttackCurrent,
    PressedRight,
    PressedLeft
}