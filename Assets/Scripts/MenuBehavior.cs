using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject pauseButtons;

    public void StartGameButton(){
        SceneManager.LoadScene("TestScene");
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        pauseButtons.SetActive(false);
        GameObject.FindObjectOfType<RayController>().SetRaying(false);
        // GlobalBehavior.replay = false;
    }

}
