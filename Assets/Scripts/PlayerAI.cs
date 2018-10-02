using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {

    SkillManager skillManager;

    public void attackOpponent()
    {
        skillManager.attackOpponent();
    }

    public void attackMonster()
    {
        skillManager.attackMonster();
    }

    public void basicAttack()
    {
        skillManager.basicAttack();
    }

    public void strongAttack()
    {
        skillManager.strongAttack();
    }

    public void areaAttack()
    {
        skillManager.areaAttack();
    }

    public void heal()
    {
        skillManager.heal();
    }

    public void mana()
    {
        skillManager.mana();
    }

    public void summon()
    {
        skillManager.summon();
    }

    public void strengthenSummon()
    {
        skillManager.strengthenSummon();
    }

    public void freeze()
    {
        skillManager.freeze();
    }

    private void Awake()
    {
        skillManager = gameObject.GetComponent<SkillManager>();
    }
}
