using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehavior : MonoBehaviour
{
    public void WinPressed(){
        Debug.LogWarning("Called WinPressed");
        if (GlobalBehavior.gameStarted) {
            GlobalBehavior.enableReplay = true;
            GameObject.FindObjectOfType<RayController>().SetRaying(true);
        }
        else
        {
            Debug.LogWarning("Gamestarted " + GlobalBehavior.gameStarted);
        }
    }
}
