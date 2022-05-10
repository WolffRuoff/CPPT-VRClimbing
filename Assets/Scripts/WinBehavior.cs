using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages what happens when the win button gets pressed at the top of the user's climbing path
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
