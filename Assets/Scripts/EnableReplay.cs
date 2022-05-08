using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            winText.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 1f);
            replayButton.transform.position = new Vector3(winText.transform.position.x, winText.transform.position.y - 0.25f, winText.transform.position.z);

            GlobalBehavior.enableReplay = false;
            GlobalBehavior.replay = true;
        }
    }
}
