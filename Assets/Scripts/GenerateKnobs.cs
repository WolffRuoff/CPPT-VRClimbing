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
            float randX = (float)(random.NextDouble() * (difficulty) - 1.5);
            float randY = (float)(random.NextDouble() * 3f + difficulty);
            if (right && randX * GlobalBehavior.rightSpawnPos.x + currentKnob.transform.position.x < prevLeft)
                randX = randX * -1;
            else if (!right && randX * GlobalBehavior.leftSpawnPos.x + currentKnob.transform.position.x > prevRight)
                randX = randX * -1;


            if (right)
            {
                float newX = currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * randX;
                if (newX > 1.5f) {
                    newX = newX - 1f;
                    randY = randY + 0.25f;
                } else if (newX < -2.5f) {
                    newX = newX + 0.25f;
                }
                newPos = new Vector3(newX, currentKnob.transform.position.y + GlobalBehavior.rightUpSpawnPos.y * randY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
            else
            {
                float newX = currentKnob.transform.position.x + GlobalBehavior.rightSpawnPos.x * randX;
                if (newX > 1.5f) {
                    newX = newX - 0.75f;
                    randY = randY + 0.25f;
                } else if (newX < -2.5f) {
                    newX = newX + 0.25f;
                }
                newPos = new Vector3(newX, currentKnob.transform.position.y + GlobalBehavior.leftUpSpawnPos.y * randY, currentKnob.transform.position.z);
                currentKnob = Instantiate(knobs[random.Next(knobs.Length)]);
            }
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
            currentKnob.name = levelLetter + i;
            currentKnob.transform.parent = prevKnob.transform.parent;
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
