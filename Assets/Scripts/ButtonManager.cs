using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turnGO;
    [SerializeField] private int skillNumber;

    SkillManager skillManager;
    PlayerStats ps;
    Turn turn;

    //uniemożliwia użycie umiejętności, gdy przeciwnik wykonuje ruch
    public void buttonActive()
    {
        if (turn.getPlayerTurn())
        {
            if(skillNumber == 5 && monsterExist())
            {
                GetComponent<Button>().interactable = false;
            }
            else if (skillNumber == 6 && !monsterExist())
            {
                GetComponent<Button>().interactable = false;
            }
            else if (skillManager.getCdLeft(skillNumber) > 0 || skillManager.getCdLeft(skillNumber) < 0)
            {
                GetComponent<Button>().interactable = false;
            }
            else if (skillManager.getCdLeft(skillNumber) == 0 && !ps.getIsFreezed())
            {
                GetComponent<Button>().interactable = true;
            }

            setButtonText();
        }
        else
        {
            GetComponent<Button>().interactable = false;
            setButtonText();
        }
    }

    public bool monsterExist()
    {
        if (GameObject.FindGameObjectWithTag("Goblin"))
        {
            return true;
        }
        return false;
    }

    //ustawia cooldown na przyciskach
    public void setButtonText()
    {
        if (skillManager.getCdLeft(skillNumber) > 0)
        {
            GetComponentInChildren<Text>().text = skillManager.getCdLeft(skillNumber).ToString();
        }
        else if (skillManager.getCdLeft(skillNumber) == 0)
        {
            GetComponentInChildren<Text>().text = null;
        }
    }

    private void Awake()
    {
        skillManager = player.GetComponent<SkillManager>();
        ps = player.GetComponent<PlayerStats>();
        turn = turnGO.GetComponent<Turn>();
    }
	
	// Update is called once per frame
	void Update () {
        buttonActive();
	}
}
