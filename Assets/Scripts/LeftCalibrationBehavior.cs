using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCalibrationBehavior : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public GameObject hand;

    public void OnSelect() {
        GlobalBehavior.leftSpawnPos = hand.transform.position;
    }

    public void OnDeselect() {
        Instantiate(cubeToSpawn, GlobalBehavior.leftSpawnPos, Quaternion.identity);
    }
}
