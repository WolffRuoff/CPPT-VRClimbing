using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationButtons : MonoBehaviour
{
    public GameObject climbingWall;

    public GameObject easyText;
    public GameObject mediumText;
    public GameObject hardText;
    public GameObject customText;

    public Material purple;
    public Material yellow;

    public Material orange;
    public Material blue;

    public Material navy;
    public Material green;


    public void Rotate()
    {
        GlobalBehavior.rotateLevel = (GlobalBehavior.rotateLevel + 1) % 4;
        climbingWall.transform.Rotate(0,90f,0);

        easyText.SetActive(false);
        mediumText.SetActive(false);
        hardText.SetActive(false);
        customText.SetActive(false);

        if(GlobalBehavior.rotateLevel == 0){
            easyText.SetActive(true);
        }
        else if(GlobalBehavior.rotateLevel == 1){
            mediumText.SetActive(true);
        }
        else if(GlobalBehavior.rotateLevel == 2){
            hardText.SetActive(true);
        }
        else if(GlobalBehavior.rotateLevel == 3){
            customText.SetActive(true);
        }
    }

    public void purpleYellow()
    {
        GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");
        // Material purple = (Material)Resources.Load("Wall_Purple", typeof(Material));
        // Material yellow = (Material)Resources.Load("Wall_Yellow", typeof(Material));

        foreach(GameObject knob in knobs){

            int color = Random.Range(0,2);

            if(color == 0){
                knob.GetComponent<MeshRenderer>().sharedMaterial = purple;
            }
            else if(color == 1){
                knob.GetComponent<MeshRenderer>().sharedMaterial = yellow;
            }
        }
    }

    public void OrangeBlue()
    {
        GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");
        // Material orange = (Material)Resources.Load("Wall_Orange", typeof(Material));
        // Material blue = (Material)Resources.Load("Wall_Blue", typeof(Material));

        foreach(GameObject knob in knobs){

            int color = Random.Range(0,2);

            if(color == 0){
                knob.GetComponent<MeshRenderer> ().sharedMaterial = orange;
            }
            else if(color == 1){
                knob.GetComponent<MeshRenderer> ().sharedMaterial = blue;
            }
        }
    }

    public void NavyGreen()
    {
        GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");
        // Material navy = (Material)Resources.Load("Wall_Navy", typeof(Material));
        // Material green = (Material)Resources.Load("Wall_Green", typeof(Material));

        foreach(GameObject knob in knobs){

            int color = Random.Range(0,2);

            if(color == 0){
                knob.GetComponent<MeshRenderer> ().sharedMaterial = navy;
            }
            else if(color == 1){
                knob.GetComponent<MeshRenderer> ().sharedMaterial = green;
            }
        }
    }

}
