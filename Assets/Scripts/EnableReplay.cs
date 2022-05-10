using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class triggers the UI to let a user replay the game once the 'win button' has been pressed.
public class EnableReplay : MonoBehaviour
{
    public GameObject winText;
    public GameObject replayButton;

    public GameObject center;

    // Update is called once per frame
    void Update()
    {
        if (GlobalBehavior.enableReplay) {
            winText.SetActive(true);
            replayButton.SetActive(true);

            winText.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0.45f);
            replayButton.transform.position = new Vector3(winText.transform.position.x, winText.transform.position.y - 0.15f, 0.45f);

            GlobalBehavior.enableReplay = false;
            GlobalBehavior.replay = true;
        }
    }
}
