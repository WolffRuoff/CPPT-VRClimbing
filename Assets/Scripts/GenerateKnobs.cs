using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateKnobs : MonoBehaviour
{
    public GameObject wall;

    public GameObject knob1;
    public GameObject knob2;
    public GameObject knob3;

    public GameObject easy1;
    public GameObject medium1;
    public GameObject hard1;

    public GameObject winButton;

    public Material rightMaterial;
    public Material leftMaterial;

    // Start is called before the first frame update
    void Start()
    {
        GlobalBehavior.rightColor = rightMaterial;
        GlobalBehavior.leftColor = leftMaterial;
        System.Random random = new System.Random();
        int i = 2;
        bool right = true;
        GameObject currentKnob = easy1;
        while (i <= 15) {
            int num = random.Next(0, 3);
            if (i % 2 == 0) {
                // even vs. odd : can determine material for color, as well as right vs. left
                right = true;
            } else {
                right = false;
            }
            if (num == 0) {
                if (right) {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 2f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 3.5f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob1, newPos, Quaternion.identity);
                } else {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 2f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 3.5f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob1, newPos, Quaternion.identity);
                }
            } else if (num == 1) {
                if (right) {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 2.25f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 3f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob2, newPos, Quaternion.identity);
                } else {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 2.25f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 3f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob2, newPos, Quaternion.identity);
                }
            } else {
                if (right) {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 1.5f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 4f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob3, newPos, Quaternion.identity);
                } else {
                    Vector3 newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 1.5f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 4f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob3, newPos, Quaternion.identity);
                }
            }
            if (right) {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.rightColor;
                currentKnob.tag = "RightKnob";
            } else {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.leftColor;
                currentKnob.tag = "LeftKnob";                
            }
            currentKnob.name = "E" + i;
            currentKnob.transform.parent = wall.transform;
            i += 1;
        }
        GameObject win = Instantiate(winButton, new Vector3(currentKnob.transform.position.x, currentKnob.transform.position.y + 0.5f, currentKnob.transform.position.z), Quaternion.identity);
        win.transform.parent = wall.transform;
    }
}
