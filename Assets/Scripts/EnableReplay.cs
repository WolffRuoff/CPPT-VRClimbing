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
            winText.transform.position = center.transform.position;
            replayButton.transform.position = new Vector3(winText.transform.position.x, winText.transform.position.y - 0.5f, winText.transform.position.z);

            winText.SetActive(true);
            replayButton.SetActive(true);


            GlobalBehavior.enableReplay = false;
            GlobalBehavior.replay = true;
        }
    }
}
