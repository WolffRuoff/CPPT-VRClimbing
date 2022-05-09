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
        GameObject[] knobs = { knob1, knob2, knob3 };
        GlobalBehavior.rightColor = rightMaterial;
        GlobalBehavior.leftColor = leftMaterial;
        System.Random random = new System.Random();
        int i = 2;
        bool right = true;
        GameObject currentKnob = easy1;

        GameObject prevKnob = currentKnob;
        float prevLeft = prevKnob.transform.position.x;
        float prevRight = 1000f;

        while (i <= 15) {
            int num = random.Next(0, 3);
            if (i % 2 == 0) {
                // even vs. odd : can determine material for color, as well as right vs. left
                right = true;
            } else {
                right = false;
            }
            Vector3 newPos;
            float randX = (float)(random.NextDouble() * (3) - 1.5);
            float randY = (float)(random.NextDouble() + 3f);
            if (right && randX * GlobalBehavior.rightSpawnPos.x + currentKnob.transform.position.x < prevLeft)
                randX = randX * -1;
            else if (!right && randX * GlobalBehavior.leftSpawnPos.x + currentKnob.transform.position.x > prevRight)
                randX = randX * -1;


            if (right)
            {
                newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * randX, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * randY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
            else
            {
                newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * randX, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * randY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
            /*if (num == 0) {
                if (right) {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 2f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 3.5f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob1);
                } else {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 2f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 3.5f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob1);
                }
            } else if (num == 1) {
                if (right) {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 2.25f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 3f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob2);
                } else {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 2.25f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 3f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob2);
                }
            } else {
                if (right) {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * 1.5f, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * 4f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob3);
                } else {
                    newPos = new Vector3(currentKnob.transform.position.x + GlobalBehavior.leftSpawnPos.x * 1.5f, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * 4f, currentKnob.transform.position.z);
                    currentKnob = Instantiate(knob3);
                }
            }*/
            currentKnob.transform.position = newPos;
            if (right) {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.rightColor;
                currentKnob.tag = "RightKnob";
                prevRight = currentKnob.transform.position.x;
            } else {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.leftColor;
                currentKnob.tag = "LeftKnob";
                prevLeft = currentKnob.transform.position.x;
            }
            currentKnob.name = "E" + i;
            currentKnob.transform.parent = prevKnob.transform.parent;
            prevKnob = currentKnob;
            i += 1;
        }
        GameObject win = Instantiate(winButton, new Vector3(currentKnob.transform.position.x, currentKnob.transform.position.y + 0.5f, currentKnob.transform.position.z), Quaternion.identity);
        win.transform.parent = wall.transform;
        win.transform.Rotate(-90f, -90f, 90f);
        win.transform.localScale = new Vector3(1f, 1f, .5f);
    }
}
