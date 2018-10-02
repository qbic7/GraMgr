using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {

    [SerializeField] private Text textDamage;
    Animation anim;

    public void restoreHP(float hp)
    {
        textDamage.text = "+" + hp;
        textDamage.color = Color.green;
        anim.Play();
    }

    public void loseHP(float hp)
    {
        textDamage.text = "-" + hp;
        textDamage.color = Color.red;
        anim.Play();
    }

    public void restoreMP(float mp)
    {
        textDamage.text = "+" + mp;
        textDamage.color = Color.blue;
        anim.Play();
    }

    public void freeze()
    {
        textDamage.text = "Freezed";
        textDamage.color = Color.cyan;
        anim.Play();
    }

    private void Awake()
    {
        anim = GetComponentInChildren<Animation>();
    }
}
