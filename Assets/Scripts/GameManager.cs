using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject playerGO, cpuGO;

    private GameObject monster;

    PlayerStats player, cpu;
    SkillManager skillManagerPlayer, skillManagerCpu;
    Turn turn;
    EndGame end_game;
    EnemyAI enemyAI;
    MonsterAI mAI;
    MonsterStats ms;

    private bool playerMoved = false, cpuMoved = false;

    //zarządzanie ruchem gracza oraz komputera
    public void switchMove()
    {
        if (!isGameOver())
        {
            if (playerMoved)
            {
                playerMoved = false;
                skillManagerPlayer.setSkillUsed(false);
                if (monsterExist("Terrex") && !monsterFreezed())
                {
                    mAI = monster.GetComponent<MonsterAI>();
                    mAI.attack();
                }
                if (!playerFreezed(cpu))
                {
                    enemyAI.enemyAI();
                }
                cpuMoved = true;
                cpu.setIsFreezed(false);
                if (ms != null && ms.getIsFreezed())
                    ms.setIsFreezed(false);
                turn.switchMove();
            }
            else if (cpuMoved)
            {
                cpuMoved = false;
                skillManagerCpu.setSkillUsed(false);
                if (monsterExist("Goblin") && !monsterFreezed())
                {
                    mAI = monster.GetComponent<MonsterAI>();
                    mAI.attack();
                }
                if (playerFreezed(player))
                {
                    playerMoved = true;
                    player.setIsFreezed(false);
                    turn.switchMove();
                }
                if (ms != null && ms.getIsFreezed())
                    ms.setIsFreezed(false);
            }
            else if (skillManagerPlayer.getSkillUsed())
            {
                playerMoved = true;
                turn.switchMove();
            }

            if (turn.getTurnChanged())
            {
                enemyAI.setSkillInPath();
                skillManagerPlayer.countdown();
                skillManagerCpu.countdown();
                turn.setTurnChanged(false);
            }
        }
        else
        {
            endGameLock();
        }
    }

    public bool monsterExist(string str)
    {
        monster = GameObject.FindGameObjectWithTag(str);
        if (monster)
        {
            return true;
        }
        return false;
    }

    public bool playerFreezed(PlayerStats ps)
    {
        if (ps.getIsFreezed())
            return true;
        else
            return false;
    }

    public bool monsterFreezed()
    {
        ms = monster.GetComponent<MonsterStats>();
        if (ms.getIsFreezed())
            return true;
        else
            return false;
    }

    public bool isGameOver()
    {
        if (player.getIsDead())
        {
            enemyAI.endGameReward(true);
            end_game.cpuWinScreen();
            return true;
        }else if (cpu.getIsDead())
        {
            enemyAI.endGameReward(false);
            end_game.playerWinScreen();
            return true;
        }
        return false;
    }

    public void endGameLock()
    {
        playerMoved = false;
        cpuMoved = false;
        for(int i = 0; i < skillManagerPlayer.getSkillsLength(); i++)
        {
            skillManagerPlayer.setCdLeft(i, -1);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void Awake()
    {
        player = playerGO.GetComponent<PlayerStats>();
        cpu = cpuGO.GetComponent<PlayerStats>();
        skillManagerPlayer = playerGO.GetComponent<SkillManager>();
        skillManagerCpu = cpuGO.GetComponent<SkillManager>();
        turn = gameObject.GetComponent<Turn>();
        end_game = gameObject.GetComponent<EndGame>();
        enemyAI = cpuGO.GetComponent<EnemyAI>();
    }

    // Use this for initialization
    void Start () {
        if (!turn.getPlayerTurn())
        {
            playerMoved = true;
        }else if (turn.getPlayerTurn())
        {
            cpuMoved = true;
        }
	}

    // Update is called once per frame
    void Update () {
        switchMove();
    }
}
