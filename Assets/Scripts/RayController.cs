using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class RayController : MonoBehaviour
{
    bool isRaying;

    // Start is called before the first frame update
    void Start()
    {
        isRaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ray in GameObject.FindGameObjectsWithTag("RayInteractor"))
        {
            ray.GetComponent<RayInteractor>().enabled = isRaying;
        }
    }

    public void SetRaying(bool val)
    {
        isRaying = val;
    }
}
