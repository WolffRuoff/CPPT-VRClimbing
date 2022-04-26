using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralKnobs : MonoBehaviour
{

    public float minHeight = -5;
    public float maxHeight = 5;

    public float leftBound = -5;
    public float rightBound = 5;

    public float calibrationDistance = 1f;

    public GameObject knobPrefab;

    private bool curSideLeft;

    // Start is called before the first frame update
    void Start()
    {
        GenerateKnobs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateKnobs()
    {
        float newX;
        float newY;
        float middle = (leftBound + rightBound) / 2;

        // Generate first knob on random side of wall
        float initRandom = Random.Range(leftBound, rightBound);
        if (initRandom > middle)
            curSideLeft = false;
        else
            curSideLeft = true;

        Vector3 initialPos = gameObject.transform.localPosition;
        initialPos += new Vector3(initRandom, minHeight, 0);

        GameObject g = Instantiate(knobPrefab, initialPos, Quaternion.identity);

        Vector3 newPos = initialPos;
        float angle;

        // Generate new knobs until we get to max height
        do
        {

            do
            {


                if (curSideLeft)
                {
                    angle = ((Random.Range(0, 80) * Mathf.PI)/ 180);

                }
                else
                {
                    angle = ((Random.Range(95, 180) *Mathf.PI)/ 180);

                }

                newX = newPos.x + (calibrationDistance * Mathf.Cos(angle));
                newY = newPos.y + (calibrationDistance * Mathf.Sin(angle));
                
            } while (newX < leftBound && newX > rightBound);
            newPos = new Vector3(newX, newY, newPos.z);
            g = Instantiate(knobPrefab, newPos, Quaternion.identity);
            curSideLeft = !curSideLeft;

        } while (newPos.y < maxHeight);
    }
}
