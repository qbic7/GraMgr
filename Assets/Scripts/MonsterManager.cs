using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour {

    [SerializeField] private GameObject cpu;
    [SerializeField] private Button button;

    private GameObject terrexGO;

    SkillManager skillManagerCpu;
    MonsterStats terrex;

    private bool terrexExist;

    public void terrexAdd()
    {
        if (skillManagerCpu.getIsSummoned())
        {
            terrexExist = true;
            terrexGO = GameObject.FindGameObjectWithTag("Terrex");
            terrex = terrexGO.GetComponent<MonsterStats>();
            button.interactable = true;
            skillManagerCpu.setIsSummoned(false);
        }
    }

    public void terrexRemove()
    {
        if(terrexExist && terrex.getIsDead())
        {
            terrexExist = false;
            button.interactable = false;
        }
    }

    private void Awake()
    {
        skillManagerCpu = cpu.GetComponent<SkillManager>();
    }
	
	// Update is called once per frame
	void Update () {
        terrexAdd();
        terrexRemove();
	}
}
