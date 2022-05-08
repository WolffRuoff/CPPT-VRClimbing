using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehavior : MonoBehaviour
{
    public void WinPressed(){
        if (GlobalBehavior.gameStarted) {
            GlobalBehavior.enableReplay = true;
            GameObject.FindObjectOfType<RayController>().SetRaying(true);
        }
    }
}
