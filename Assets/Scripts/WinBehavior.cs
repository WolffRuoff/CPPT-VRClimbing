using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehavior : MonoBehaviour
{

    public GameObject winText;
    public GameObject replayButton;

    public void WinPressed(){

        winText.SetActive(true);
        replayButton.SetActive(true);
        GlobalBehavior.replay = true;

        GameObject.FindObjectOfType<RayController>().SetRaying(true);
    }
}
