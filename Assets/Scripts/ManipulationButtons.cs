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

    public void changeColor()
    {
        Material color1 = blue;
        Material color2 = orange; 
        if(this.transform.parent.gameObject.name == "Purple/Yellow"){
            color1 = purple;
            color2 = yellow;
        }
        else if (this.transform.parent.gameObject.name == "Navy/Green"){
            color1 = navy;
            color2 = green;
        }
        else if(this.transform.parent.gameObject.name == "Blue/Orange"){
            color1 = blue;
            color2 = orange;
        }
        GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");

        foreach(GameObject knob in knobs){

            int color = Random.Range(0,2);

            if(color == 0){
                knob.GetComponent<MeshRenderer>().sharedMaterial = color1;
            }
            else if(color == 1){
                knob.GetComponent<MeshRenderer>().sharedMaterial = color2;
            }
        }
    }

}
