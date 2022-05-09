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

    public GameObject danger;

    public GameObject winButton;

    public Material rightMaterial;
    public Material leftMaterial;

    private int rotateLevel = -1;

    private HashSet<int> createdLevels = new HashSet<int>();

    // Start is called before the first frame update
    void Start()
    {
        rotateLevel = GlobalBehavior.rotateLevel;
        if (rotateLevel == 0) {
            CreateKnobsForLevel(easy1, "E", 3f);
            createdLevels.Add(0);
        } else if (rotateLevel == 1) {
            CreateKnobsForLevel(medium1, "M", 4f);
            createdLevels.Add(1);
        } else if (rotateLevel == 2) {
            CreateKnobsForLevel(hard1, "H", 5f);
            createdLevels.Add(2);
        }
    }

    void Update() {
        if (GlobalBehavior.rotateLevel != rotateLevel) {
            rotateLevel = GlobalBehavior.rotateLevel;
            if (rotateLevel == 0 && !createdLevels.Contains(0)) {
                CreateKnobsForLevel(easy1, "E", 3f);
                createdLevels.Add(0);
            } else if (rotateLevel == 1 && !createdLevels.Contains(1)) {
                CreateKnobsForLevel(medium1, "M", 4f);
                createdLevels.Add(1);
            } else if (rotateLevel == 2 && !createdLevels.Contains(2)) {
                CreateKnobsForLevel(hard1, "H", 5f);
                createdLevels.Add(2);
            }            
        }
    }

    public void CreateKnobsForLevel(GameObject startKnob, string levelLetter, float difficulty) {
        GameObject[] knobs = { knob1, knob2, knob3 };
        GlobalBehavior.rightColor = rightMaterial;
        GlobalBehavior.leftColor = leftMaterial;
        System.Random random = new System.Random();
        int i = 2;
        bool right = true;
        GameObject currentKnob = startKnob;

        GameObject prevKnob = currentKnob;
        float prevPos = prevKnob.transform.position.x;
        // float prevRight = prevLeft+difficulty*.1f;

        while (i <= 15) {
            if (i % 2 == 0) {
                // even vs. odd : can determine material for color, as well as right vs. left
                right = true;
            } else {
                right = false;
            }
            Vector3 newPos;
            float randX = (float)(random.NextDouble() * (difficulty) - (difficulty / 3));
            float randY = (float)(random.NextDouble() * (1.75f) + difficulty);

            if (right && randX * GlobalBehavior.rightSpawnPos.x + currentKnob.transform.position.x <= prevPos)
                randX = randX * -1;
            else if (!right && currentKnob.transform.position.x - randX * GlobalBehavior.leftSpawnPos.x >= prevPos)
                randX = randX * -1;

            if (i % 3 == 0) {
                GameObject newDangerKnob = Instantiate(danger);
                newDangerKnob.transform.position = new Vector3(prevPos - 0.45f, prevKnob.transform.position.y, prevKnob.transform.position.z);
                newDangerKnob.transform.parent = prevKnob.transform.parent;
                GlobalBehavior.dangerKnobs.Add(newDangerKnob);
            }

            if (right)
            {
                float newX = prevPos + (GlobalBehavior.rightSpawnPos.x * randX);
                if (newX > 1.3f) {
                    newX = newX - 1f;
                } else if (newX < -2.0f) {
                    newX = newX + 0.5f;
                }
                float newY = currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * randY;
                if (newY > 15f) {
                    break;
                }
                newPos = new Vector3(newX, newY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
            else
            {
                float newX = prevPos - (GlobalBehavior.leftSpawnPos.x * randX);
                if (newX > 1.3f) {
                    newX = newX - 1f;
                } else if (newX < -2.0f) {
                    newX = newX + 0.5f;
                }
                float newY = currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * randY;
                if (newY > 15f) {
                    break;
                }
                newPos = new Vector3(newX, newY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
            if (right) {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.rightColor;
                currentKnob.tag = "RightKnob";
            } else {
                currentKnob.GetComponent<Renderer>().material = GlobalBehavior.leftColor;
                currentKnob.tag = "LeftKnob";
            }
            currentKnob.name = levelLetter + i;
            currentKnob.transform.parent = prevKnob.transform.parent;
            currentKnob.transform.position = newPos;
            prevPos = currentKnob.transform.position.x;
            prevKnob = currentKnob;
            i += 1;
        }
        GameObject win = Instantiate(winButton, new Vector3(currentKnob.transform.position.x, currentKnob.transform.position.y + 0.5f, currentKnob.transform.position.z), Quaternion.identity);
        win.name = "Win";
        win.transform.parent = wall.transform;
        win.transform.Rotate(-90f, -90f, 90f);
        win.transform.localScale = new Vector3(1f, 1f, .5f);
    }
}
