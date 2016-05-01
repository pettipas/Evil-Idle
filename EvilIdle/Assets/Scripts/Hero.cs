using UnityEngine;
using System.Collections;

public class Hero : Clickable {

    public ParticleSystem system;
    public Button levelUpButton;
    public HeroData data;
    public int dps;
    public Animator animator;
    public GameObject viewRoot;
    public bool seenByUser;
    public Material mat;

    public void Hide(){
        viewRoot.SetActive(false);
    }

    public void ShowUnclickable(){
        viewRoot.SetActive(true);
        viewRoot.transform.SetLayer(8);
    }

    public void ShowClickable(){
        viewRoot.SetActive(true);
        viewRoot.transform.SetLayer(9);
    }

    public override void ShowClick()
    {
        animator.Play("hero_flash",0,0);
        system.Play();
    }
}
