using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    [SerializeField] private Image img;
    [SerializeField] private Text playerWin, cpuWin;

    public void playerWinScreen()
    {
        img.enabled = true;
        playerWin.enabled = true;
    }

    public void cpuWinScreen()
    {
        img.enabled = true;
        cpuWin.enabled = true;
    }
}
