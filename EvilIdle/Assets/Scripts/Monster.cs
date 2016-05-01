using UnityEngine;
using System.Collections;

public class Monster : Clickable {

    public float hp;
    public float maxhp;

    public Animator animator;
    public ProgressBar pBar;

    public Material mat;
    public Transform eyes;
    public Color color;

    public FiveDidgetNumber hpView;
    public FiveDidgetNumber maxHpView;

    public void Awake(){
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        mat.color = color;
        eyes.localScale += new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    Color cachedColor;
    public override void ShowClick()
    {
        animator.Play("take_damage",0,0);
    }

    public bool Dead {
        get{
            return hp <=0;
        }
    }

    public void Update(){

        if(animator.GetCurrentAnimatorStateInfo (0).IsName("default")){
            mat.color = color;
        }

        if(hp == 0){
            return;
        }

        if(hp < 0){
            hp = 0;
            pBar.amount = 0.01f;
            return;
        }
        hpView.current = (int)hp;
        maxHpView.current = (int)maxhp;
        pBar.amount = (float)hp/maxhp;
    }
}
