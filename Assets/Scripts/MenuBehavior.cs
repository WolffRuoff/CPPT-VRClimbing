using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class handles the behavior for managing the main "Start Game" menu
public class MenuBehavior : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] pauseButtons;

    public void StartGameButton(){
        SceneManager.LoadScene("MainGameScene");
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        foreach (GameObject button in pauseButtons)
        {
            button.SetActive(false);
        }
        GameObject.FindObjectOfType<RayController>().SetRaying(false);
    }
}
