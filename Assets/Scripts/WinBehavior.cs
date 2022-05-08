using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehavior : MonoBehaviour
{

    // public GameObject winText;
    // public GameObject replayButton;

    public void WinPressed(){
        GlobalBehavior.enableReplay = true;
        GameObject.FindObjectOfType<RayController>().SetRaying(true);
    }
}
